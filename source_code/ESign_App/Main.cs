
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.security;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.X509;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Tls;

namespace ESign_App
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            GetPerUser();
            cbb_TypeSign.SelectedIndex = 0;
            txt_Pass.PasswordChar = '*';
        }

        string[] getPerUser = new string[] { };
        private void GetPerUser()
        {
            string getPerUser = File.ReadAllText("Get_File_User_Encode.txt");
            string Key = "9549304AAAABCDEFHH96857KKKABCDEF";
            this.getPerUser = Support.DecryptStringAES(getPerUser, Key).Split('|');
        }

        string id = "";

        private void btn_Check_Click(object sender, EventArgs e)
        {
            if (txt_Domain.Text == "")
            {
                txt_Check.Text = "--------------THÔNG TIN CHỮ KÝ----------";
                try { pic_Main.Image.Dispose(); pic_Sign.Image.Dispose(); } catch { }
                pan_SignSign.Enabled = false;
                pic_Main.Image = null;
                pic_Sign.Image = null;
                MessageBox.Show("Tên miền của tổ chức xác thực chưa được cung cấp, vui lòng bổ sung thông tin này và thực hiện lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<string> listID;
            try
            {
                txt_Check.Text = "--------------THÔNG TIN CHỮ KÝ----------";
                try { pic_Main.Image.Dispose(); pic_Sign.Image.Dispose(); } catch { }
                pan_SignSign.Enabled = false;
                pic_Main.Image = null;
                pic_Sign.Image = null;
                listID = Support.ListIDSSH(txt_Domain.Text, 22, getPerUser[0], getPerUser[1], "Crt_File_FTP");
            }
            catch
            {
                MessageBox.Show("Không tìm thấy miền xác minh mà bạn nhập vào", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (listID.Count == 0)
            {
                txt_Check.Text = "--------------THÔNG TIN CHỮ KÝ----------";
                try { pic_Main.Image.Dispose(); pic_Sign.Image.Dispose(); } catch { }
                pan_SignSign.Enabled = false;
                pic_Main.Image = null;
                pic_Sign.Image = null;
                MessageBox.Show("Tên miền của tổ chức xác thực hiện tại không có dữ liệu chữ ký nào", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (string item in listID)
            {
                if (item == txt_ID.Text)
                {
                    id = txt_ID.Text;
                    pan_SignSign.Enabled = true;
                    try { pic_Main.Image.Dispose(); pic_Sign.Image.Dispose(); } catch { }
                    try { File.Delete("pic.png"); } catch { }
                    try { File.Delete("sig.png"); } catch { }
                    Support.DownloadFileSSH(txt_Domain.Text, 22, getPerUser[0], getPerUser[1], $"Crt_File_FTP/{id}/.png", "sig.png");
                    Support.DownloadFileSSH(txt_Domain.Text, 22, getPerUser[0], getPerUser[1], $"Crt_File_FTP/{id}/..png", "pic.png");
                    pic_Main.Image = Image.FromFile("pic.png");
                    pic_Sign.Image = Image.FromFile("sig.png");


                    try { File.Delete("server.crt"); } catch { }
                    try { File.Delete("server.key"); } catch { }
                    try { File.Delete(".name"); } catch { }
                    Support.DownloadFileSSH(txt_Domain.Text, 22, getPerUser[0], getPerUser[1], $"Crt_File_FTP/{id}/server.crt", "server.crt");
                    Support.DownloadFileSSH(txt_Domain.Text, 22, getPerUser[0], getPerUser[1], $"Crt_File_FTP/{id}/server.key", "server.key");
                    Support.DownloadFileSSH(txt_Domain.Text, 22, getPerUser[0], getPerUser[1], $"Crt_File_FTP/{id}/.name", ".name");
                    string info = "--------------THÔNG TIN CHỮ KÝ----------\n";
                    string name = File.ReadAllText(".name");
                    info = info + "Chủ sở hữu: " + name + "\n";
                    X509Certificate2 cert = new X509Certificate2("server.crt");
                    string subjectCer = cert.Subject;
                    info = info + "Chủ thể chứng chỉ: " + subjectCer + "\n";


                    info = info + "Ngày tạo chứng chỉ: " + cert.NotBefore + "\n";
                    info = info + "Ngày hết hạn: " + cert.NotAfter + "\n";
                    txt_Check.Text = info;
                    return;
                }
            }
            txt_Check.Text = "--------------THÔNG TIN CHỮ KÝ----------";
            try { pic_Main.Image.Dispose(); pic_Sign.Image.Dispose(); } catch { }
            pic_Main.Image = null;
            pic_Sign.Image = null;
            pan_SignSign.Enabled = false;
            MessageBox.Show("Không tìm thấy bất kỳ dữ liệu chữ ký nào có ID mà bạn nhập vào", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        private void btn_Sign_Click(object sender, EventArgs e)
        {
            string place = "";
            if (!(cbb_TypeSign.SelectedIndex == 1))
            {
                place = "50,50,100,100";
            }
            else
            {
                place = "550,50,600,100";
            }
            if (txt_PDF.Text == "")
            {
                MessageBox.Show("Vui lòng chọn file .pdf để thực hiện ký", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int pageCount = 0;
            using (PdfReader reader = new PdfReader(txt_PDF.Text))
            {
                pageCount = reader.NumberOfPages;
            }
            pageCount--;

            try { File.Delete("res.txt"); } catch { }
            string source_var = $"server.key#server.crt#{txt_Pass.Text}#{txt_PDF.Text}#{place}#Signature by FXT Software#{pageCount}#{Support.GetHash(txt_PDF.Text)}#sig.png";
            File.WriteAllText("source_var.txt", source_var);
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo("./App_Sign.exe");
            process.Start();
            process.WaitForExit();

            try
            {
                string res = File.ReadAllText("res.txt");
                byte[] pdfBytes = File.ReadAllBytes("DocumentRes.pdf");
                using (SHA256 sha256 = SHA256.Create())
                {

                    byte[] documentHash = sha256.ComputeHash(pdfBytes);
                    string hashValue = System.Convert.ToBase64String(documentHash);
                    Support.UploadHashSSH(txt_Domain.Text, 22, getPerUser[0], getPerUser[1], "Hash_File_FTP.hash", hashValue);
                }
                MessageBox.Show("Thực hiện ký thành công, file lưu với tên DocumentRes.pdf. Nếu muốn thực hiện ký file pdf khác vui lòng di chuyển file DocumentRes.pdf đi nơi khác!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình ký, vui lòng kiểm tra thực hiện ký lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "File PDF (*.pdf)|*.pdf";
            open.Title = "Chọn file PDF";
            open.ShowDialog();
            txt_PDF.Text = open.FileName;
        }

        private void btn_ChoosePDF_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "File PDF (*.pdf)|*.pdf";
            open.Title = "Chọn file PDF";
            open.ShowDialog();
            txt_PDF2.Text = open.FileName;
        }

        private void btn_Ver_Click(object sender, EventArgs e)
        {
            try { pic_Main2.Image.Dispose(); pic_Sign2.Image.Dispose(); } catch { }
            pic_Main2.Image = null;
            pic_Sign2.Image = null;
            if (txt_Domain2.Text == "")
            {
                txt_Ver.Text = "---------THÔNG TIN XÁC MINH---------";
                MessageBox.Show("Tên miền của tổ chức xác thực chưa được cung cấp, vui lòng bổ sung thông tin này và thực hiện lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txt_PDF2.Text == "")
            {
                txt_Ver.Text = "---------THÔNG TIN XÁC MINH---------";
                MessageBox.Show("Vui lòng chọn file .pdf để xác minh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PdfReader reader = new PdfReader(txt_PDF2.Text);
            AcroFields af = reader.AcroFields;
            List<string> names = af.GetSignatureNames();
            if (names.Count == 0)
            {
                txt_Ver.Text = "---------THÔNG TIN XÁC MINH---------";
                try { pic_Main2.Image.Dispose(); pic_Sign2.Image.Dispose(); } catch { }
                pic_Main2.Image = null;
                pic_Sign2.Image = null;
                MessageBox.Show("File .pdf bạn đưa vào không có bất kỳ dữ liệu chữ ký nào được tìm thấy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PdfPKCS7 pk = af.VerifySignature(names[0]);
            try { File.Delete("./ver/Main.crt"); } catch { }
            File.WriteAllBytes("./ver/Main.crt", pk.Certificates[0].GetEncoded());

            List<string> listID;
            try
            {
                txt_Ver.Text = "---------THÔNG TIN XÁC MINH---------";
                listID = Support.ListIDSSH(txt_Domain2.Text, 22, getPerUser[0], getPerUser[1], "Crt_File_FTP");
            }
            catch
            {
                try { pic_Main2.Image.Dispose(); pic_Sign2.Image.Dispose(); } catch { }
                pic_Main2.Image = null;
                pic_Sign2.Image = null;
                MessageBox.Show("Không tìm thấy miền xác minh mà bạn nhập vào", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (listID.Count == 0)
            {
                try { pic_Main2.Image.Dispose(); pic_Sign2.Image.Dispose(); } catch { }
                pic_Main2.Image = null;
                pic_Sign2.Image = null;
                txt_Ver.Text = "---------THÔNG TIN XÁC MINH---------";
                MessageBox.Show("Tên miền của tổ chức xác thực hiện tại không có dữ liệu chữ ký nào", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (string name in listID)
            {
                if (name == "." || name == "..")
                    continue;
                try { File.Delete("./ver/Temp.crt"); } catch { }
                Support.DownloadFileSSH(txt_Domain2.Text, 22, getPerUser[0], getPerUser[1], $"Crt_File_FTP/{name}/server.crt", "./ver/Temp.crt");
                if (Support.CompareX509Certificates("./ver/Main.crt", "./ver/Temp.crt"))
                {
                    try { pic_Main2.Image.Dispose(); pic_Sign2.Image.Dispose(); } catch { }
                    pic_Main2.Image = null;
                    pic_Sign2.Image = null;
                    try { File.Delete("./ver/pic.png"); } catch { }
                    try { File.Delete("./ver/sig.png"); } catch { }
                    Support.DownloadFileSSH(txt_Domain2.Text, 22, getPerUser[0], getPerUser[1], $"Crt_File_FTP/{name}/..png", "./ver/pic.png");
                    Support.DownloadFileSSH(txt_Domain2.Text, 22, getPerUser[0], getPerUser[1], $"Crt_File_FTP/{name}/.png", "./ver/sig.png");
                    pic_Sign2.Image = Image.FromFile("./ver/sig.png");
                    pic_Main2.Image = Image.FromFile("./ver/pic.png");
                    Support.DownloadFileSSH(txt_Domain2.Text, 22, getPerUser[0], getPerUser[1], $"Crt_File_FTP/{name}/.name", "./ver/.name");


                    txt_Ver.Text = "---------THÔNG TIN XÁC MINH---------\n";
                    txt_Ver.Text = txt_Ver.Text + "Chủ sở hữu: " + File.ReadAllText("./ver/.name") + '\n';
                    txt_Ver.Text = txt_Ver.Text + "Chủ thể chứng chỉ: " + (new X509Certificate2("./ver/Main.crt")).Subject + '\n';

                    byte[] pdfBytes = File.ReadAllBytes(txt_PDF2.Text);
                    using (SHA256 sha256 = SHA256.Create())
                    {
                        string[] hashList = (Support.GetHashListSSH(txt_Domain2.Text, 22, getPerUser[0], getPerUser[1], "Hash_File_FTP.hash")).Split('\n');
                        byte[] documentHash = sha256.ComputeHash(pdfBytes);
                        string hashValue = System.Convert.ToBase64String(documentHash);
                        foreach (string hash in hashList)
                        {
                            if (hash == hashValue)
                            {
                                txt_Ver.Text = txt_Ver.Text + "Tính toàn vẹn: Tài liệu không bị sửa đổi";
                                return;
                            }
                        }
                        txt_Ver.Text = txt_Ver.Text + "Tính toàn vẹn: Tài liệu đã bị sửa đổi";
                    }
                    return;
                }
            }
            try { pic_Main2.Image.Dispose(); pic_Sign2.Image.Dispose(); } catch { }
            pic_Main2.Image = null;
            pic_Sign2.Image = null;
            txt_Ver.Text = "---------THÔNG TIN XÁC MINH---------\n" + "Không tìm thấy bất kỳ dữ liệu chữ ký nào khớp với dữ liệu trong miền xác thực \"" + txt_Domain2.Text + "\"";
            return;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { File.Delete("server.crt"); } catch { }
            try { pic_Sign.Image.Dispose(); } catch { }
            try { pic_Main.Image.Dispose(); } catch { }
            try {  File.Delete("sig.png"); } catch { }
            try { File.Delete("server.key"); } catch { }
            try { File.Delete("pic.png"); } catch { }
            try { File.Delete("source_var.txt"); } catch { }
            try { File.Delete(".name"); } catch { }
            try { File.Delete("res.txt"); } catch { }

            try { File.Delete("./ver/.name"); } catch { }
            try { File.Delete("./ver/Main.crt"); } catch { }
            try { File.Delete("./ver/Temp.crt"); } catch { }
            try { pic_Sign2.Image.Dispose(); File.Delete("./ver/sig.png"); } catch { }
            try { pic_Main2.Image.Dispose(); File.Delete("./ver/pic.png"); } catch { }
        }
    }
}