using System;

namespace _Root.Player.Domain
{
    public class PlayerEventSubscription : IDisposable
    {
        private readonly Action _disposeAction;
        private bool _isDisposed;

        public PlayerEventSubscription(Action disposeAction)
        {
            _disposeAction = disposeAction;
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _disposeAction?.Invoke();
                _isDisposed = true;
            }
        }
    }
}