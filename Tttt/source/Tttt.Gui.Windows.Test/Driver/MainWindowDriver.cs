using Codeer.Friendly.Windows.Grasp;

namespace Tttt.Gui.Windows.Test.Driver
{
    internal class MainWindowDriver
    {
        public WindowControl Window { get; }

        public MainWindowDriver(dynamic window)
        {
            Window = new WindowControl(window);
        }
    }
}