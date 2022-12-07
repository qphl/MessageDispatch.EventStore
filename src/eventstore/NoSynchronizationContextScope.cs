﻿namespace CorshamScience.MessageDispatch.EventStore
{
    using System;
    using System.Threading;

    internal static class NoSynchronizationContextScope
    {
        public static Disposable Enter()
        {
            var context = SynchronizationContext.Current;
            SynchronizationContext.SetSynchronizationContext(null);
            return new Disposable(context);
        }

        public struct Disposable : IDisposable
        {
            private readonly SynchronizationContext? synchronizationContext;

            public Disposable(SynchronizationContext? synchronizationContext)
            {
                this.synchronizationContext = synchronizationContext;
            }

            public void Dispose() =>
                SynchronizationContext.SetSynchronizationContext(synchronizationContext);
        }
    }
}
