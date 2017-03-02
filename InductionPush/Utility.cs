using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace InductionPush
{
    public class Utility
    {

        public static void Log(string logMessage, string loggingDirectory = @"\logs\")
        {
            if (!Directory.Exists(loggingDirectory))
            {
                Directory.CreateDirectory(loggingDirectory);
            }

            using (var writer = File.AppendText($"{loggingDirectory}{GenerateTimestamp()}.log"))
            {
                writer.WriteLine(logMessage);
            }
        }
        private static string GenerateTimestamp()
        {
            return DateTime.Now.ToShortDateString().Replace('/', '-');
        }

        public static string GetSecret(string secret, string secretDirectory = @"C:\secrets\")
        {
            var xml = XDocument.Load(secretDirectory + @"default.secret");
            return xml.Root.Descendants(secret).First().Value;
        }
    }
}