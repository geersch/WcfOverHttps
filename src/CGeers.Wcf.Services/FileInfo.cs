using System.IO;
using System.ServiceModel;

namespace CGeers.Wcf.Services
{
    [MessageContract]
    public class FileInfo
    {
        [MessageHeader(MustUnderstand = true)]
        public string FileName { get; set; }

        [MessageHeader(MustUnderstand = true)]
        public long Length { get; set; }

        [MessageBodyMember(Order = 1)]
        public Stream Stream { get; set; }
    }
}
