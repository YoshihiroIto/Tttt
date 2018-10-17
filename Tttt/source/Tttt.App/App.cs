using System;
using SimpleInjector;
using Tttt.Foundation;
using Tttt.Foundation.Interface;

namespace Tttt.App
{
    public class App : IDisposable
    {
        private readonly AppConfig _appConfig;
        private readonly Container _dic;
        private readonly ILogger _logger;

        private string _appConfigFilePath;

        public App(Container dic, ILogger logger, AppConfig appConfig)
        {
            _dic = dic;
            _logger = logger;
            _appConfig = appConfig;

            _logger?.Info("Start Application");
        }

        public void Dispose()
        {
            _appConfig.Save(_configRepos);

            _logger?.Info("End Application");
        }

        private LocalStorageRepository<AppConfig> _configRepos;

        public void Setup(CommandLine commandLine)
        {
            _appConfigFilePath = commandLine.AppConfigFilePath;

            _configRepos = _dic.GetInstance<LocalStorageRepository<AppConfig>>().Setup(_appConfigFilePath);

            _appConfig.Load(_configRepos);
        }
    }
}