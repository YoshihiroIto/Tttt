using System;
using Tttt.Foundation.Interface;

namespace Tttt.Foundation
{
    public class NullDisposableChecker : IDisposableChecker
    {
        public void Start(Action<string> showError)
        {
        }

        public void End()
        {
        }

        public void Clean()
        {
        }

        public void Add(IDisposable disposable)
        {
        }

        public void Remove(IDisposable disposable)
        {
        }
    }
}