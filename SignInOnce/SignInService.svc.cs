using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.Text;
using System.Reflection;

namespace SignInOnce
{   
    public class SignInService : ISignInService
    {
        // Create a logger for use in this class
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly bool isDebugEnabled = log.IsDebugEnabled;
        public BaseStatus showMe()
        {
            if (isDebugEnabled)
            {
                log.Debug(MethodBase.GetCurrentMethod().Name + " Start");
            }
            SignInStatus stat = new SignInStatus();
            stat.Status = "Ok";
            stat.AccessToken = "1234";
            //if (log.IsDebugEnabled) log.Debug("This is a debug message");
            if (log.IsInfoEnabled) log.Debug("showMe() is called");

            if (isDebugEnabled)
            {
                log.Debug(MethodBase.GetCurrentMethod().Name + " End");
            }
            return stat;
        }

        public BaseStatus showMe2()
        {            
            BaseStatus stat = new BaseStatus();
            stat.Status = "Ok";
            return stat;
        }

        public Credential showMe3(Credential str)
        {
            str.id += " rocks";
            return str;
        }


        public BaseStatus SignIn(SignInParams param)
        {
            if (isDebugEnabled)
            {
                log.Debug(MethodBase.GetCurrentMethod().Name + " Start");
            }
            
            BaseStatus status = new BaseStatus();
            status.Status = "-1";
           
            if (param.Connector != null && param.Login != null && param.Password != null)
            {
                if (param.Connector.Equals("GoogleDrive") && param.Login.Equals("user@gmail.com") && param.Password.Equals("123456"))
                {
                    SignInStatus sStatus = new SignInStatus();
                    sStatus.Status = "Ok";
                    sStatus.AccessToken = "12345678990abcdefgh";

                    if (isDebugEnabled)
                    {
                        log.Info(Resources.Language.SignInSuccess);
                        log.Debug(MethodBase.GetCurrentMethod().Name + " End");
                    }
                    return sStatus;
                }
                else
                {
                    if (isDebugEnabled)
                    {
                        log.Error(Resources.Language.SignInFailure);
                    }
                }
            }
            if (isDebugEnabled)
            {
                log.Debug(MethodBase.GetCurrentMethod().Name + " End");
            }
            return status;
        }

        
        public BaseStatus UploadFile(UploadFileParams param)
        {
            if (isDebugEnabled)
            {
                log.Debug(MethodBase.GetCurrentMethod().Name + " Start");
            }
            BaseStatus uploadStatus = new BaseStatus();
            uploadStatus.Status = "-1";

            if (param.AccessToken != null)
            {
                if (param.AccessToken.Equals("1234"))
                {
                    uploadStatus.Status = "Ok";
                    if (isDebugEnabled)
                    {
                        log.Info(Resources.Language.UploadFileSuccess);
                    }
                }
                else
                {
                    if (isDebugEnabled)
                    {
                        log.Error(Resources.Language.UploadFileFailure);
                    }
                }
            }
            if (isDebugEnabled)
            {
                log.Debug(MethodBase.GetCurrentMethod().Name + " End");
            }
            return uploadStatus;
        }

        public string EchoWithGet(string s)
        {
            return "Huy GET said " + s;
        }
        
        public string EchoWithPost(string s)
        {
            return "Huy POST said " + s;
        }
        public BaseStatus GetFolders(GetFolderParams param)
        {
           /* if (isDebugEnabled)
            {
                log.Debug(MethodBase.GetCurrentMethod().Name + " Start");
            }*/
            BaseStatus stat = new BaseStatus();
            stat.Status = "-1";

            /*if (param.AccessToken != null)
            {
                if (param.AccessToken.Equals("1234"))
                {
                    GetFolderStatus fStatus = new GetFolderStatus();
                    fStatus.Folder = new string[2];
                    fStatus.Status = "Ok";
                    fStatus.Folder[0] = "folder1";
                    fStatus.Folder[1] = "folder2";
                    if (isDebugEnabled)
                    {
                        log.Info(Resources.Language.GetFolderSuccess);
                        log.Debug(MethodBase.GetCurrentMethod().Name + " End");
                    }
                    return fStatus;
                }
                else
                {
                    if (isDebugEnabled)
                    {
                        log.Error(Resources.Language.GetFolderFailure);
                    }
                }
            }
            if (isDebugEnabled)
            {
                log.Debug(MethodBase.GetCurrentMethod().Name + " End");
            }*/
            return stat;
        }
    }
}
