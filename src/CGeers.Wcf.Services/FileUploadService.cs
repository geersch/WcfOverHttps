using System;
using System.Configuration;
using System.IO;
using System.ServiceModel;

namespace CGeers.Wcf.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Single)]
    public class FileUploadService : IFileUploadService
    {
        #region IFileUploadService Members

        public FileReceivedInfo Upload(FileInfo fileInfo)
        {
            try
            {
                // Determine to which directory the file needs to be uploaded
                string uploadDirectory = ConfigurationManager.AppSettings["uploadDirectory"];
                if (String.IsNullOrEmpty(uploadDirectory))
                {
                    throw new InvalidOperationException("Please specifiy an upload directory.");
                }

                // Try to create the upload directory if it does not yet exist
                if (!Directory.Exists(uploadDirectory))
                {
                    Directory.CreateDirectory(uploadDirectory);
                }

                // Check if a file with the same filename is already present in the upload directory
                // If this is the case then delete this file
                string path = Path.Combine(uploadDirectory, fileInfo.FileName);
                if (File.Exists(path))
                {
                    // Check if the file is read-only
                    if ((File.GetAttributes(path) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        File.SetAttributes(path, FileAttributes.Normal);
                    }
                    File.Delete(path);
                }

                // Read the incoming stream and save it to file
                const int bufferSize = 2048;
                byte[] buffer = new byte[bufferSize];
                using (FileStream outputStream = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    int bytesRead = fileInfo.Stream.Read(buffer, 0, bufferSize);
                    while (bytesRead > 0)
                    {
                        outputStream.Write(buffer, 0, bytesRead);
                        bytesRead = fileInfo.Stream.Read(buffer, 0, bufferSize);
                    }
                    outputStream.Close();
                }
                return new FileReceivedInfo
                           {
                               FileName = fileInfo.FileName,
                               Message = String.Empty,
                               UploadSucceeded = true
                           };
            }
            catch (Exception ex)
            {
                return new FileReceivedInfo
                           {
                               FileName = fileInfo.FileName,
                               Message = ex.Message,
                               UploadSucceeded = false
                           };
            }
        }

        #endregion
    }
}
