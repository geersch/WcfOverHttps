using System.ServiceModel;

namespace CGeers.Wcf.Services
{
    [MessageContract]
    public class FileReceivedInfo
    {
        [MessageHeader(MustUnderstand = true)]
        public string FileName { get; set; }

        [MessageHeader(MustUnderstand = true)]
        public string Message { get; set; }

        [MessageBodyMember(Order = 1)]
        public bool UploadSucceeded { get; set; }
    }
}
