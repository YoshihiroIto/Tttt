using System;
using System.IO;
using Mono.Options;

namespace Tttt.App
{
    public class CommandLine
    {
        public string AppConfigFilePath { get; set; } =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Tttt",
                "App",
                "AppConfig.json"
            );

        public static CommandLine Parse(string[] args)
        {
            var cl = new CommandLine();

            try
            {
                var options = new OptionSet
                {
                    {"config=", "config file path", v => cl.AppConfigFilePath = v}
                };

                options.Parse(args);
            }
            catch
            {
                // ignored
            }

            return cl;
        }
    }
}