using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrocIntens.Uttility
{
    internal class AppSettingLoader
    {
        public static IConfigurationRoot Configuration { get; set; }

        public AppSettingLoader() 
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();

            builder.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
        }
    }
}
