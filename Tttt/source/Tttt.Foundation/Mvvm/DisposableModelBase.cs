using Tttt.Foundation.Interface;

namespace Tttt.Foundation.Mvvm
{
    public class DisposableModelBase : DisposableNotificationObject
    {
        public DisposableModelBase(IDisposableChecker disposableChecker)
            : base(disposableChecker)
        {
        }
    }
}