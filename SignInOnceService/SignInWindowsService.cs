using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceProcess;
using System.Configuration;
using System.Configuration.Install;
using SignInOnce;
using System.ServiceModel.Description;

namespace SignInOnceService
{
    class SignInWindowsService : ServiceBase
    {
        public ServiceHost serviceHost = null;

        public SignInWindowsService()
        {
            ServiceName = "SignInService";
        }
        public static void Main()
        {
            ServiceBase.Run(new SignInWindowsService());
        }

        // Start the Windows service.
        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }
            // Create a ServiceHost for the SignInService type and 
            // provide the base address.            
            serviceHost = new ServiceHost(typeof(SignInService));
            //serviceHost = new ServiceHost(typeof(SignInService), new Uri("http://localhost/SignInOnceService/"));
            //serviceHost.AddServiceEndpoint(typeof(ISignInService), new BasicHttpBinding(), "Soap");
            //ServiceEndpoint endpoint = serviceHost.AddServiceEndpoint(typeof(ISignInService), new WebHttpBinding(), "Web");            
            //endpoint.Behaviors.Add(new WebHttpBehavior());           
            
            // Open the ServiceHostBase to create listeners and start 
            // listening for messages.
            serviceHost.Open();
        }
        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }
}
