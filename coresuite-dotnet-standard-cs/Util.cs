using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text.RegularExpressions;

namespace coresuite_dotnet_standard_cs
{
    public class Util
    {
        internal static IConfiguration DynamicPDFConfiguration;

        static Util()
        {
            var builder = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            DynamicPDFConfiguration = builder.Build();
        }

        // This is a helper function to get a full path to a file in the Resources folder.
        internal static string GetResourcePath(string inputFileName)
        {
            var exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return System.IO.Path.Combine(appRoot, "Resources", inputFileName);
        }
    }
}
