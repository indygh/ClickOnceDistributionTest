using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickOnceTestApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //Try to obtain the QueryString to show it in the form
            string queryString = "<Empty>";
            string version = $"Assembly Version:{Assembly.GetExecutingAssembly().GetName().Version.ToString()}{Environment.NewLine}";
            if (ApplicationDeployment.IsNetworkDeployed && ApplicationDeployment.CurrentDeployment.ActivationUri != null)
            {
                queryString = ApplicationDeployment.CurrentDeployment.ActivationUri.Query;
                version += $"Publish version:{ApplicationDeployment.CurrentDeployment.CurrentVersion}{Environment.NewLine}";
            }
            var myForm = new Form1();
            myForm.SetText($"{version}{Environment.NewLine}QueryString:{queryString}");

            Application.Run(myForm);
        }
    }
}
