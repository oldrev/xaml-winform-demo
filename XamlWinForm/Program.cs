using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OswaldTechnologies.Extensions.Hosting.WindowsFormsLifetime;
using Portable.Xaml;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XamlWinForm
{

    class Program
    {

        static void Main()
        {
            CreateHostBuilder().Build().Run();
        }

        public static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder(Array.Empty<string>())
                .ConfigureServices((hostContext, services) =>
                {
                    var form = XamlServices.Load("Form1.xaml") as Form;

                    services.AddSingleton<IHostLifetime, WindowsFormsLifetime>();
                    services.AddSingleton(form);
                    services.AddHostedService<WindowsFormsHostedService<Form>>();
                });
    }
}
