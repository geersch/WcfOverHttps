using System;
using System.ServiceModel;
using CGeers.Wcf.Services;

namespace ConsoleHost
{
    class Program
    {
        static void Main()
        {
            ServiceHost host = new ServiceHost(typeof(FileUploadService));
            host.Open();
            Console.WriteLine("FileUpload Service Host");
            Console.WriteLine("Service Started!");
            foreach (Uri address in host.BaseAddresses)
            {
                Console.WriteLine("Listening on " + address);
            }
            Console.WriteLine("Press any key to close the host...");
            Console.ReadKey();
            host.Close();
        }
    }
}
