using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Shareport
{
    internal static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>

        static void Main()
        {
#if (!DEBUG)
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new ShareportService()
            };
            ServiceBase.Run(ServicesToRun);
#else
            ShareportService serviceCall = new ShareportService();
            serviceCall.ExecuteService();
#endif
        }
    }
}
