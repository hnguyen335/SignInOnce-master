using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SignInOnce
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISignInService" in both code and config file together.
    

    [ServiceContract(Namespace = "https://localhost/SignInService")]
    [ServiceKnownType(typeof(BaseStatus))]
    [ServiceKnownType(typeof(SignInStatus))]
    [ServiceKnownType(typeof(GetFolderStatus))]
    public interface ISignInService
    {
        /*[OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        SignInStatus SignIn(string Connector, string Login, string Password);*/

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json,
                   RequestFormat = WebMessageFormat.Xml)]
        BaseStatus SignIn(SignInParams param);

        
        
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json)]
        BaseStatus UploadFile(UploadFileParams param);
        
        [OperationContract]
        [WebGet]
        string EchoWithGet(string s);

        
        
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        BaseStatus showMe();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        BaseStatus showMe2();

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json,
                   RequestFormat  = WebMessageFormat.Json)]
        Credential showMe3(Credential c);

        [OperationContract]
        [WebInvoke]
        string EchoWithPost(string s);

        [OperationContract]
        [WebInvoke (ResponseFormat = WebMessageFormat.Json)]
        BaseStatus GetFolders(GetFolderParams param);


    }

    [DataContract]
    public class Credential
    {
        [DataMember]
        public string id;
    }
    
    /////////////////////////////////////////////
    [DataContract]
    [KnownType(typeof(SignInStatus))]
    [KnownType(typeof(GetFolderStatus))]
    public class BaseStatus
    {
        [DataMember]
        public string Status { get; set; }        
    }

    [DataContract]
    public class SignInStatus : BaseStatus
    {       
        [DataMember]
        public string AccessToken { get; set; }        
    }

    [DataContract]
    public class GetFolderStatus : BaseStatus
    {
        [DataMember]
        public string[] Folder { get; set; }
    }

    public class SignInParams
    {
        public string Connector;
        public string Login;
        public string Password;
    }

    public class GetFolderParams
    {
        public string AccessToken;
    }

    public class UploadFileParams
    {
        public string   AccessToken;
        public string   Foldername;
        public string[] Filenames;
        public bool     Override;
    }
      


}
