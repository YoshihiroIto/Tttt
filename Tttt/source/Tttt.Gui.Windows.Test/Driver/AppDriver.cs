using System;
using System.Diagnostics;
using System.IO;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using RM.Friendly.WPFStandardControls;
using Tttt.Gui.Windows.Test.Helper;

namespace Tttt.Gui.Windows.Test.Driver
{
    internal class AppDriver : IDisposable
    {
        private static string ExePath
        {
            get
            {
                const string exe =
#if DEBUG
                    "../../../../Tttt.Gui.Windows/bin/Debug/Tttt.Gui.Windows.exe";
#else
                    "../../../../Tttt.Gui.Windows/bin/Release/Tttt.Gui.Windows.exe";
#endif

                return Path.GetFullPath(exe);
            }
        }

        public void Dispose()
        {
            //タイムアップ終了していない場合は自ら終了させる
            if (_killer.IsKilled == false)
                _killer.Kill();

            _killer.Dispose();
            _app.Dispose();
            _proc.Dispose();
        }

        public WindowControl MainWindow => _mainWindowDriver.Window;

        private readonly Process _proc;
        private readonly WindowsAppFriend _app;
        private readonly MainWindowDriver _mainWindowDriver;
        private readonly Killer _killer;

        public AppDriver()
            : this(null, 60 * 1000)
        {
        }

        public AppDriver(string args, int timeoutMs)
        {
            _proc = Process.Start(ExePath, args);
            _app = new WindowsAppFriend(_proc);
            _mainWindowDriver = new MainWindowDriver(_app.Type<System.Windows.Application>().Current.MainWindow);

            WPFStandardControls_3.Injection(_app);
            WPFStandardControls_3_5.Injection(_app);
            WPFStandardControls_4.Injection(_app);
            WindowsAppExpander.LoadAssembly(_app, GetType().Assembly);

            // ReSharper disable once PossibleNullReferenceException
            _killer = new Killer(timeoutMs, _proc.Id);
        }
    }
}