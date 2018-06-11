using SignInOnce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Web;
using System.ServiceModel;
using System.ServiceModel.Description;
namespace TestSoap
{
    class Program
    {
        
        static void Main(string[] args)
        {            
            ServiceHost host = new ServiceHost(typeof(SignInService), new Uri("http://localhost:8000"));
            host.AddServiceEndpoint(typeof(ISignInService), new BasicHttpBinding(), "Soap");
            ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(ISignInService), new WebHttpBinding(), "Web");
            endpoint.Behaviors.Add(new WebHttpBehavior());
            host.Open();
            Console.WriteLine("Service is running {0}", endpoint.Address);
            Console.WriteLine("Press enter to quit...");
            Console.ReadLine();
            host.Close();
        }
    }
}
