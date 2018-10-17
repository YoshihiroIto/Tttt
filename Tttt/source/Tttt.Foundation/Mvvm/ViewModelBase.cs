using Tttt.Foundation.Interface;

namespace Tttt.Foundation.Mvvm
{
    public class ViewModelBase : DisposableNotificationObject
    {
        public ViewModelBase(IDisposableChecker disposableChecker)
            : base(disposableChecker)
        {
        }
    }
}