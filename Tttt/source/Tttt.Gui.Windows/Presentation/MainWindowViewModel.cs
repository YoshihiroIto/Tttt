using Tttt.Foundation.Interface;
using Tttt.Foundation.Mvvm;

namespace Tttt.Gui.Windows.Presentation
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(IDisposableChecker disposableChecker)
            : base(disposableChecker)
        {
        }
    }
}