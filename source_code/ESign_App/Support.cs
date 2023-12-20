using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;

namespace ESign_App
{
    internal class Support
    {
        public static bool CompareX509Certificates(string filePath1, string filePath2)
        {
            X509Certificate2 cert1 = new X509Certificate2(filePath1);
            X509Certificate2 cert2 = new X509Certificate2(filePath2);

            byte[] cert1Hash = cert1.GetCertHash();
            byte[] cert2Hash = cert2.GetCertHash();

            return StructuralComparisons.StructuralEqualityComparer.Equals(cert1Hash, cert2Hash);
        }

        public static List<string> ListID(string ftpServer, string ftpPath, string ftpUsername, string ftpPassword)
        {
            List<string> directoryList = new List<string>();

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpServer + ftpPath);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
            request.UsePassive = false;

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    string line = reader.ReadLine();
                    while (!string.IsNullOrEmpty(line))
                    {
                        directoryList.Add(line);
                        line = reader.ReadLine();
                    }
                }
            }
            return directoryList;
        }

        public static List<string> ListIDSSH(string sshHost, int sshPort, string sshUsername, string sshPassword, string ftpPath)
        {
            List<string> directoryList = new List<string>();

            using (var client = new SftpClient(sshHost, sshPort, sshUsername, sshPassword))
            {
                client.Connect();

                var files = client.ListDirectory(ftpPath);

                foreach (var file in files)
                {
                    directoryList.Add(file.Name);
                }

                client.Disconnect();
            }

            return directoryList;
        }

        public static void DownloadFile(string ftpServer, string ftpFilePath, string ftpUsername, string ftpPassword, string localFilePath)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpServer + ftpFilePath);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
            request.UsePassive = false;

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                using (Stream ftpStream = response.GetResponseStream())
                {
                    using (Stream fileStream = File.Create(localFilePath))
                    {
                        byte[] buffer = new byte[1024];
                        int bytesRead;
                        while ((bytesRead = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fileStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
        }

        public static void DownloadFileSSH(string sshHost, int sshPort, string sshUsername, string sshPassword, string ftpFilePath, string localFilePath)
        {
            using (var client = new SftpClient(sshHost, sshPort, sshUsername, sshPassword))
            {
                client.Connect();

                using (var fileStream = File.Create(localFilePath))
                {
                    client.DownloadFile(ftpFilePath, fileStream);
                }

                client.Disconnect();
            }
        }

        public static string DecryptStringAES(string cipherText, string key)
        {
            byte[] fullCipher = Convert.FromBase64String(cipherText);
            byte[] iv = new byte[16];
            byte[] cipher = new byte[fullCipher.Length - 16];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, cipher.Length);

            string plaintext = null;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var ms = new System.IO.MemoryStream(cipher))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var sr = new System.IO.StreamReader(cs))
                {
                    plaintext = sr.ReadToEnd();
                }
            }

            return plaintext;
        }

        public static string GetHash(string pdfFilePath)
        {
            byte[] pdfBytes = File.ReadAllBytes(pdfFilePath);
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] documentHash = sha256.ComputeHash(pdfBytes);
                return System.Convert.ToBase64String(documentHash);
            }
        }

        public static void UploadHash(string ftpServer, string hashCode, string ftpUsername, string ftpPassword)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpServer);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
            request.UsePassive = false;

            string fileContent;
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                fileContent = reader.ReadToEnd();
            }
            fileContent = fileContent + "\n" + hashCode;
            request = (FtpWebRequest)WebRequest.Create(ftpServer);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
            request.UsePassive = false;
            byte[] data = System.Text.Encoding.UTF8.GetBytes(fileContent);
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(data, 0, data.Length);
            }
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                return;
            }
        }

        public static void UploadHashSSH(string sshHost, int sshPort, string sshUsername, string sshPassword, string ftpPath, string hashCode)
        {
            using (var client = new SftpClient(sshHost, sshPort, sshUsername, sshPassword))
            {
                client.Connect();

                var fileContent = client.ReadAllText(ftpPath);
                fileContent += "\n" + hashCode;
                client.WriteAllText(ftpPath, fileContent);

                client.Disconnect();
            }
        }

        public static string GetHashListSSH(string sshHost, int sshPort, string sshUsername, string sshPassword, string ftpPath)
        {
            string fileContent;

            using (var client = new SftpClient(sshHost, sshPort, sshUsername, sshPassword))
            {
                client.Connect();

                fileContent = client.ReadAllText(ftpPath);

                client.Disconnect();
            }

            return fileContent;
        }

        public static string GetHashList(string ftpServer, string ftpUsername, string ftpPassword)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpServer);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
            request.UsePassive = false;

            string fileContent;
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                fileContent = reader.ReadToEnd();
            }
            return fileContent;
        }
    }
}
