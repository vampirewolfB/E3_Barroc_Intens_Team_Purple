using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrocIntens.Utility
{
    internal class AppSettingLoader
    {
        // Variable waar alle appsettings in zitten.
        public static IConfigurationRoot Configuration { get; set; }

        // Laad de variablen uit het bestand en stops ze in configuration.
        public AppSettingLoader() 
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();

            builder.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
        }
    }
}
