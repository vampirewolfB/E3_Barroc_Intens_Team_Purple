using BarrocIntens.Utility.Database;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrocIntens.Utility
{
    internal class Logger
    {
        public static ILoggerFactory ContextLoggerFactory =>
            LoggerFactory.Create(b => b.AddDebug());
    }
}
