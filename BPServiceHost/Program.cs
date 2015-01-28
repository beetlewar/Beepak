using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Beepak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string address = "http://localhost:8000";
            using (var host = new WebServiceHost(typeof(Service), new Uri(address)))
            {
                try
                {
                    host.AddServiceEndpoint(typeof(IService), new WebHttpBinding(), "");
                    host.Open();

                    Console.WriteLine("Starting service at {0}", address);
                    Console.WriteLine("Press <ENTER> to terminate");
                    Console.ReadLine();

                    host.Close();
                }
                catch (CommunicationException cex)
                {
                    Console.WriteLine("An exception occurred: {0}", cex.Message);
                    Console.WriteLine("Press <Enter> to exit");
                    host.Abort();
                    Console.ReadLine();
                }
            }
        }
    }
}
