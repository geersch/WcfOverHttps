using System.ServiceModel;

namespace CGeers.Wcf.Services
{
    [ServiceContract(Namespace = "http://cgeers.wordpress.com/wcf/services")]
    public interface IFileUploadService
    {
        [OperationContract]
        FileReceivedInfo Upload(FileInfo fileInfo);
    }
}
