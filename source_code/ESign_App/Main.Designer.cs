namespace ESign_App
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            pan_Sign = new Panel();
            pan_SubSign = new Panel();
            pan_SignSign = new Panel();
            btn_Sign = new Button();
            btn_ChooseFile = new Button();
            label7 = new Label();
            cbb_TypeSign = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            txt_PDF = new TextBox();
            txt_Pass = new TextBox();
            label4 = new Label();
            label3 = new Label();
            pic_Sign = new PictureBox();
            pic_Main = new PictureBox();
            txt_Check = new RichTextBox();
            btn_Check = new Button();
            txt_ID = new TextBox();
            txt_Domain = new TextBox();
            label2 = new Label();
            label1 = new Label();
            lbl_Sign = new Label();
            pan_Ver = new Panel();
            pan_SubVer = new Panel();
            label10 = new Label();
            label11 = new Label();
            pic_Sign2 = new PictureBox();
            pic_Main2 = new PictureBox();
            btn_Ver = new Button();
            txt_Ver = new RichTextBox();
            btn_ChoosePDF = new Button();
            label9 = new Label();
            txt_PDF2 = new TextBox();
            txt_Domain2 = new TextBox();
            label8 = new Label();
            lbl_Ver = new Label();
            pan_Sign.SuspendLayout();
            pan_SubSign.SuspendLayout();
            pan_SignSign.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_Sign).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic_Main).BeginInit();
            pan_Ver.SuspendLayout();
            pan_SubVer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_Sign2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic_Main2).BeginInit();
            SuspendLayout();
            // 
            // pan_Sign
            // 
            pan_Sign.BackColor = SystemColors.ActiveCaptionText;
            pan_Sign.Controls.Add(pan_SubSign);
            pan_Sign.Dock = DockStyle.Left;
            pan_Sign.Location = new Point(0, 0);
            pan_Sign.Name = "pan_Sign";
            pan_Sign.Size = new Size(412, 361);
            pan_Sign.TabIndex = 0;
            // 
            // pan_SubSign
            // 
            pan_SubSign.BackColor = Color.White;
            pan_SubSign.Controls.Add(pan_SignSign);
            pan_SubSign.Controls.Add(label4);
            pan_SubSign.Controls.Add(label3);
            pan_SubSign.Controls.Add(pic_Sign);
            pan_SubSign.Controls.Add(pic_Main);
            pan_SubSign.Controls.Add(txt_Check);
            pan_SubSign.Controls.Add(btn_Check);
            pan_SubSign.Controls.Add(txt_ID);
            pan_SubSign.Controls.Add(txt_Domain);
            pan_SubSign.Controls.Add(label2);
            pan_SubSign.Controls.Add(label1);
            pan_SubSign.Controls.Add(lbl_Sign);
            pan_SubSign.Location = new Point(3, 3);
            pan_SubSign.Name = "pan_SubSign";
            pan_SubSign.Size = new Size(406, 355);
            pan_SubSign.TabIndex = 0;
            // 
            // pan_SignSign
            // 
            pan_SignSign.Controls.Add(btn_Sign);
            pan_SignSign.Controls.Add(btn_ChooseFile);
            pan_SignSign.Controls.Add(label7);
            pan_SignSign.Controls.Add(cbb_TypeSign);
            pan_SignSign.Controls.Add(label6);
            pan_SignSign.Controls.Add(label5);
            pan_SignSign.Controls.Add(txt_PDF);
            pan_SignSign.Controls.Add(txt_Pass);
            pan_SignSign.Enabled = false;
            pan_SignSign.Location = new Point(3, 289);
            pan_SignSign.Name = "pan_SignSign";
            pan_SignSign.Size = new Size(400, 63);
            pan_SignSign.TabIndex = 7;
            // 
            // btn_Sign
            // 
            btn_Sign.BackColor = Color.Black;
            btn_Sign.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Sign.ForeColor = Color.White;
            btn_Sign.Location = new Point(238, 32);
            btn_Sign.Name = "btn_Sign";
            btn_Sign.Size = new Size(151, 26);
            btn_Sign.TabIndex = 13;
            btn_Sign.Text = "Thực hiện ký";
            btn_Sign.UseVisualStyleBackColor = false;
            btn_Sign.Click += btn_Sign_Click;
            // 
            // btn_ChooseFile
            // 
            btn_ChooseFile.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ChooseFile.Location = new Point(163, 33);
            btn_ChooseFile.Name = "btn_ChooseFile";
            btn_ChooseFile.Size = new Size(40, 26);
            btn_ChooseFile.TabIndex = 18;
            btn_ChooseFile.Text = "...";
            btn_ChooseFile.UseVisualStyleBackColor = true;
            btn_ChooseFile.Click += btn_ChooseFile_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(12, 39);
            label7.Name = "label7";
            label7.Size = new Size(70, 15);
            label7.TabIndex = 17;
            label7.Text = "Chọn PDF:";
            // 
            // cbb_TypeSign
            // 
            cbb_TypeSign.FormattingEnabled = true;
            cbb_TypeSign.Items.AddRange(new object[] { "Type 1", "Type 2" });
            cbb_TypeSign.Location = new Point(80, 3);
            cbb_TypeSign.Name = "cbb_TypeSign";
            cbb_TypeSign.Size = new Size(77, 23);
            cbb_TypeSign.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(163, 6);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 14;
            label6.Text = "Mật khẩu:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(13, 6);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 15;
            label5.Text = "Vị trí:";
            // 
            // txt_PDF
            // 
            txt_PDF.Enabled = false;
            txt_PDF.Location = new Point(80, 35);
            txt_PDF.Name = "txt_PDF";
            txt_PDF.Size = new Size(77, 23);
            txt_PDF.TabIndex = 11;
            // 
            // txt_Pass
            // 
            txt_Pass.Location = new Point(239, 3);
            txt_Pass.Name = "txt_Pass";
            txt_Pass.Size = new Size(147, 23);
            txt_Pass.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(306, 195);
            label4.Name = "label4";
            label4.Size = new Size(84, 15);
            label4.TabIndex = 6;
            label4.Text = "Ảnh chữ ký:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(306, 104);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 6;
            label3.Text = "Ảnh hồ sơ:";
            // 
            // pic_Sign
            // 
            pic_Sign.BackColor = Color.Silver;
            pic_Sign.Location = new Point(306, 213);
            pic_Sign.Name = "pic_Sign";
            pic_Sign.Size = new Size(80, 70);
            pic_Sign.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_Sign.TabIndex = 5;
            pic_Sign.TabStop = false;
            // 
            // pic_Main
            // 
            pic_Main.BackColor = Color.Silver;
            pic_Main.Location = new Point(306, 125);
            pic_Main.Name = "pic_Main";
            pic_Main.Size = new Size(80, 66);
            pic_Main.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_Main.TabIndex = 5;
            pic_Main.TabStop = false;
            // 
            // txt_Check
            // 
            txt_Check.Enabled = false;
            txt_Check.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txt_Check.Location = new Point(13, 101);
            txt_Check.Name = "txt_Check";
            txt_Check.Size = new Size(287, 183);
            txt_Check.TabIndex = 4;
            txt_Check.Text = "--------------THÔNG TIN CHỮ KÝ----------";
            // 
            // btn_Check
            // 
            btn_Check.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Check.Location = new Point(269, 64);
            btn_Check.Name = "btn_Check";
            btn_Check.Size = new Size(123, 26);
            btn_Check.TabIndex = 3;
            btn_Check.Text = "Kiểm tra";
            btn_Check.UseVisualStyleBackColor = true;
            btn_Check.Click += btn_Check_Click;
            // 
            // txt_ID
            // 
            txt_ID.Location = new Point(113, 65);
            txt_ID.Name = "txt_ID";
            txt_ID.Size = new Size(150, 23);
            txt_ID.TabIndex = 2;
            // 
            // txt_Domain
            // 
            txt_Domain.Location = new Point(113, 35);
            txt_Domain.Name = "txt_Domain";
            txt_Domain.Size = new Size(279, 23);
            txt_Domain.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(9, 70);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 1;
            label2.Text = "ID chữ ký:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(9, 39);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 1;
            label1.Text = "Miền xác minh:";
            // 
            // lbl_Sign
            // 
            lbl_Sign.BackColor = Color.Black;
            lbl_Sign.Dock = DockStyle.Top;
            lbl_Sign.Font = new Font("Courier New", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Sign.ForeColor = Color.White;
            lbl_Sign.Location = new Point(0, 0);
            lbl_Sign.Name = "lbl_Sign";
            lbl_Sign.Size = new Size(406, 28);
            lbl_Sign.TabIndex = 0;
            lbl_Sign.Text = "Ký điện tử";
            lbl_Sign.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pan_Ver
            // 
            pan_Ver.BackColor = SystemColors.ActiveCaptionText;
            pan_Ver.Controls.Add(pan_SubVer);
            pan_Ver.Dock = DockStyle.Right;
            pan_Ver.Location = new Point(415, 0);
            pan_Ver.Name = "pan_Ver";
            pan_Ver.Size = new Size(369, 361);
            pan_Ver.TabIndex = 1;
            // 
            // pan_SubVer
            // 
            pan_SubVer.BackColor = Color.White;
            pan_SubVer.Controls.Add(label10);
            pan_SubVer.Controls.Add(label11);
            pan_SubVer.Controls.Add(pic_Sign2);
            pan_SubVer.Controls.Add(pic_Main2);
            pan_SubVer.Controls.Add(btn_Ver);
            pan_SubVer.Controls.Add(txt_Ver);
            pan_SubVer.Controls.Add(btn_ChoosePDF);
            pan_SubVer.Controls.Add(label9);
            pan_SubVer.Controls.Add(txt_PDF2);
            pan_SubVer.Controls.Add(txt_Domain2);
            pan_SubVer.Controls.Add(label8);
            pan_SubVer.Controls.Add(lbl_Ver);
            pan_SubVer.Location = new Point(3, 3);
            pan_SubVer.Name = "pan_SubVer";
            pan_SubVer.Size = new Size(363, 355);
            pan_SubVer.TabIndex = 0;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(280, 195);
            label10.Name = "label10";
            label10.Size = new Size(84, 15);
            label10.TabIndex = 26;
            label10.Text = "Ảnh chữ ký:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(280, 104);
            label11.Name = "label11";
            label11.Size = new Size(77, 15);
            label11.TabIndex = 27;
            label11.Text = "Ảnh hồ sơ:";
            // 
            // pic_Sign2
            // 
            pic_Sign2.BackColor = Color.Silver;
            pic_Sign2.Location = new Point(280, 213);
            pic_Sign2.Name = "pic_Sign2";
            pic_Sign2.Size = new Size(80, 70);
            pic_Sign2.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_Sign2.TabIndex = 24;
            pic_Sign2.TabStop = false;
            // 
            // pic_Main2
            // 
            pic_Main2.BackColor = Color.Silver;
            pic_Main2.Location = new Point(280, 125);
            pic_Main2.Name = "pic_Main2";
            pic_Main2.Size = new Size(80, 66);
            pic_Main2.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_Main2.TabIndex = 25;
            pic_Main2.TabStop = false;
            // 
            // btn_Ver
            // 
            btn_Ver.BackColor = Color.Black;
            btn_Ver.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Ver.ForeColor = Color.White;
            btn_Ver.Location = new Point(17, 322);
            btn_Ver.Name = "btn_Ver";
            btn_Ver.Size = new Size(337, 26);
            btn_Ver.TabIndex = 23;
            btn_Ver.Text = "Xác minh";
            btn_Ver.UseVisualStyleBackColor = false;
            btn_Ver.Click += btn_Ver_Click;
            // 
            // txt_Ver
            // 
            txt_Ver.Enabled = false;
            txt_Ver.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txt_Ver.Location = new Point(17, 101);
            txt_Ver.Name = "txt_Ver";
            txt_Ver.Size = new Size(260, 214);
            txt_Ver.TabIndex = 22;
            txt_Ver.Text = "---------THÔNG TIN XÁC MINH---------";
            // 
            // btn_ChoosePDF
            // 
            btn_ChoosePDF.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ChoosePDF.Location = new Point(314, 66);
            btn_ChoosePDF.Name = "btn_ChoosePDF";
            btn_ChoosePDF.Size = new Size(40, 26);
            btn_ChoosePDF.TabIndex = 21;
            btn_ChoosePDF.Text = "...";
            btn_ChoosePDF.UseVisualStyleBackColor = true;
            btn_ChoosePDF.Click += btn_ChoosePDF_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(17, 73);
            label9.Name = "label9";
            label9.Size = new Size(70, 15);
            label9.TabIndex = 20;
            label9.Text = "Chọn PDF:";
            // 
            // txt_PDF2
            // 
            txt_PDF2.Enabled = false;
            txt_PDF2.Location = new Point(121, 68);
            txt_PDF2.Name = "txt_PDF2";
            txt_PDF2.Size = new Size(187, 23);
            txt_PDF2.TabIndex = 19;
            // 
            // txt_Domain2
            // 
            txt_Domain2.Location = new Point(121, 39);
            txt_Domain2.Name = "txt_Domain2";
            txt_Domain2.Size = new Size(233, 23);
            txt_Domain2.TabIndex = 4;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(17, 44);
            label8.Name = "label8";
            label8.Size = new Size(105, 15);
            label8.TabIndex = 3;
            label8.Text = "Miền xác minh:";
            // 
            // lbl_Ver
            // 
            lbl_Ver.BackColor = Color.Black;
            lbl_Ver.Dock = DockStyle.Top;
            lbl_Ver.Font = new Font("Courier New", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Ver.ForeColor = Color.White;
            lbl_Ver.Location = new Point(0, 0);
            lbl_Ver.Name = "lbl_Ver";
            lbl_Ver.Size = new Size(363, 28);
            lbl_Ver.TabIndex = 1;
            lbl_Ver.Text = "Xác minh";
            lbl_Ver.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 361);
            Controls.Add(pan_Ver);
            Controls.Add(pan_Sign);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(800, 400);
            MinimumSize = new Size(800, 400);
            Name = "Main";
            Text = "Electronic Signature";
            FormClosing += Main_FormClosing;
            pan_Sign.ResumeLayout(false);
            pan_SubSign.ResumeLayout(false);
            pan_SubSign.PerformLayout();
            pan_SignSign.ResumeLayout(false);
            pan_SignSign.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_Sign).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic_Main).EndInit();
            pan_Ver.ResumeLayout(false);
            pan_SubVer.ResumeLayout(false);
            pan_SubVer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_Sign2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic_Main2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pan_Sign;
        private Panel pan_SubSign;
        private Panel pan_Ver;
        private Panel pan_SubVer;
        private Label lbl_Sign;
        private Label lbl_Ver;
        private TextBox txt_Domain;
        private Label label1;
        private Button btn_Check;
        private TextBox txt_ID;
        private Label label2;
        private RichTextBox txt_Check;
        private Label label4;
        private Label label3;
        private PictureBox pic_Sign;
        private PictureBox pic_Main;
        private Panel pan_SignSign;
        private Button btn_Sign;
        private ComboBox cbb_TypeSign;
        private Label label6;
        private Label label5;
        private TextBox txt_Pass;
        private Button btn_ChooseFile;
        private Label label7;
        private TextBox txt_PDF;
        private Button btn_ChoosePDF;
        private Label label9;
        private TextBox txt_PDF2;
        private TextBox txt_Domain2;
        private Label label8;
        private Label label10;
        private Label label11;
        private PictureBox pic_Sign2;
        private PictureBox pic_Main2;
        private Button btn_Ver;
        private RichTextBox txt_Ver;
    }
}