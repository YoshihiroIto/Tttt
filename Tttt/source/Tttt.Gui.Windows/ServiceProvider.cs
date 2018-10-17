using SimpleInjector;
using Tttt.App;
using Tttt.Foundation;
using Tttt.Foundation.Interface;
using ILogger = Tttt.Foundation.Interface.ILogger;

namespace Tttt.Gui.Windows
{
    public class ServiceProvider : Container
    {
        public ServiceProvider(string outputDir)
        {
            SetupContainer();

            ////////////////////////////////////////////////////////////////////////////////////////
            void SetupContainer()
            {
                RegisterSingleton<App.App>();
                RegisterSingleton<AppConfig>();
                RegisterSingleton<LocalStorage>();
                RegisterSingleton<ILogger>(() => new Logger(outputDir));

                RegisterSingleton<IDisposableChecker>(() =>
#if DEBUG
                    new DisposableChecker()
#else
                    new NullDisposableChecker()
#endif
                );

#if DEBUG
                Verify();
#endif
            }
        }
    }
}