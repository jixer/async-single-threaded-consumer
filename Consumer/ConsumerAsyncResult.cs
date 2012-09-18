using System;
using Microsoft.Samples;

namespace Cjam.Threading.Consumer
{
    internal class ConsumerAsyncResult : AsyncResult
    {
        public ConsumerAsyncResult(AsyncCallback callback, object state)
            : base(callback, state) { }

        public void SetComplete()
        {
            Complete(false);
        }

        internal void EndInvoke()
        {
            AsyncResult.End<ConsumerAsyncResult>(this);
        }
    }

    internal class ConsumerAsyncResult<T> : TypedAsyncResult<T>
    {
        public ConsumerAsyncResult(AsyncCallback callback, object state)
            : base(callback, state) { }

        public void SetComplete(T data)
        {
            Complete(data, false);
        }

        public void SetComplete(object data)
        {
            Complete((T)data, false);
        }

        internal T EndInvoke()
        {
            return TypedAsyncResult<T>.End(this);
        }
    }
}
