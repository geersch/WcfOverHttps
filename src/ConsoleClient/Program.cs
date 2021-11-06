using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using ConsoleClient.ServiceReferences;

namespace ConsoleClient
{
    class Program
    {
        static void Main()
        {
            ServicePointManager.ServerCertificateValidationCallback += customXertificateValidation;

            using (FileUploadServiceClient proxy = new FileUploadServiceClient())
            {
                proxy.ClientCredentials.UserName.UserName = "Christophe";
                proxy.ClientCredentials.UserName.Password = "WCFRocks!";

                FileStream inputStream = File.Open(@"c:\temp\uploadtest.txt", FileMode.Open);

                ServiceReferences.FileInfo fileInfo = 
                    new ServiceReferences.FileInfo("uploaded.txt", inputStream.Length, inputStream);
                FileReceivedInfo info = proxy.Upload(fileInfo);
                if (info.UploadSucceeded)
                {
                    Console.WriteLine(String.Format("File {0} uploaded", info.FileName));
                }
                else
                {
                    Console.WriteLine(String.Format("File {0} upload failed", info.FileName));
                    Console.WriteLine(info.Message);
                }
                Console.WriteLine();
                Console.ReadLine();
            }
        }

        private static bool customXertificateValidation(object sender, X509Certificate cert, 
            X509Chain chain, SslPolicyErrors error)
        {
            X509Certificate2 certificate = (X509Certificate2)cert;
            if (certificate.Subject == "CN=127.0.0.1" && !String.IsNullOrEmpty(certificate.Thumbprint) &&
                certificate.Thumbprint.ToLower() == "cfdf5d1140b94614d047dd77c7bd4d4d4422e1c9")
            {
                return true;
            }
            return false;
        }
    }
}
