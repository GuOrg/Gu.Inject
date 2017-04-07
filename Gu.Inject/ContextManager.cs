namespace Gu.Inject
{
    using System;

    internal class ContextManager : IDisposable
    {
        private Action onExit;

        public ContextManager(Action enter, Action exit)
        {
            this.onExit = exit;
            enter();
        }

        public void Dispose()
        {
            this.onExit?.Invoke();
            this.onExit = null;
        }
    }
}
