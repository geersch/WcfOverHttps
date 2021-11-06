﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleClient.ServiceReferences {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://cgeers.wordpress.com/wcf/services", ConfigurationName="ServiceReferences.IFileUploadService")]
    public interface IFileUploadService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://cgeers.wordpress.com/wcf/services/IFileUploadService/Upload", ReplyAction="http://cgeers.wordpress.com/wcf/services/IFileUploadService/UploadResponse")]
        ConsoleClient.ServiceReferences.FileReceivedInfo Upload(ConsoleClient.ServiceReferences.FileInfo request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="FileInfo", WrapperNamespace="http://cgeers.wordpress.com/wcf/services", IsWrapped=true)]
    public partial class FileInfo {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://cgeers.wordpress.com/wcf/services")]
        public string FileName;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://cgeers.wordpress.com/wcf/services")]
        public long Length;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://cgeers.wordpress.com/wcf/services", Order=0)]
        public System.IO.Stream Stream;
        
        public FileInfo() {
        }
        
        public FileInfo(string FileName, long Length, System.IO.Stream Stream) {
            this.FileName = FileName;
            this.Length = Length;
            this.Stream = Stream;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="FileReceivedInfo", WrapperNamespace="http://cgeers.wordpress.com/wcf/services", IsWrapped=true)]
    public partial class FileReceivedInfo {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://cgeers.wordpress.com/wcf/services")]
        public string FileName;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://cgeers.wordpress.com/wcf/services")]
        public string Message;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://cgeers.wordpress.com/wcf/services", Order=0)]
        public bool UploadSucceeded;
        
        public FileReceivedInfo() {
        }
        
        public FileReceivedInfo(string FileName, string Message, bool UploadSucceeded) {
            this.FileName = FileName;
            this.Message = Message;
            this.UploadSucceeded = UploadSucceeded;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IFileUploadServiceChannel : ConsoleClient.ServiceReferences.IFileUploadService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class FileUploadServiceClient : System.ServiceModel.ClientBase<ConsoleClient.ServiceReferences.IFileUploadService>, ConsoleClient.ServiceReferences.IFileUploadService {
        
        public FileUploadServiceClient() {
        }
        
        public FileUploadServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FileUploadServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FileUploadServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FileUploadServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ConsoleClient.ServiceReferences.FileReceivedInfo Upload(ConsoleClient.ServiceReferences.FileInfo request) {
            return base.Channel.Upload(request);
        }
    }
}
