using System;
using Microsoft.Samples;
using System.Threading;

namespace Cjam.Threading.Consumer
{
    public class AsyncConsumer : IDisposable
    {
        #region Private Members

        private InputQueue<WorkItem> _inputQueue;
        private Thread _workerThread;
        private AsyncConsumerState _state;
        private readonly object _stateLock;

        #endregion

        #region Properties

        public AsyncConsumerState State { get { return _state; } }

        #endregion

        #region Constructor

        public AsyncConsumer()
        {
            _stateLock = new object();
            SetState(AsyncConsumerState.Initializing);
            _inputQueue = new InputQueue<WorkItem>();
            _workerThread = new Thread(MainExecution);
            _workerThread.Start();

            if (_workerThread.IsAlive)
            {
                SetState(AsyncConsumerState.Active);
            }
            else
            {
                throw new Exception("Could not initialize consumer thread");
            }
        }

        #endregion

        #region Public Methods

        #region Async Invoke Methods

        public IAsyncResult BeginInvoke<TResult> (Func<TResult> function, AsyncCallback callback, object state)
        {
            var asyncResult = new ConsumerAsyncResult<object>(callback, state);
            var workItem = new WorkItem((Delegate)function, null, function.Target, asyncResult);
            _inputQueue.EnqueueAndDispatch(workItem);
            return asyncResult;

        }

        public IAsyncResult BeginInvoke<T1, TResult>(Func<T1, TResult> function, T1 arg1, AsyncCallback callback, object state)
        {
            var asyncResult = new ConsumerAsyncResult<object>(callback, state);

            object[] parameters = new object[1];
            parameters[0] = arg1;

            var workItem = new WorkItem((Delegate)function, parameters, function.Target, asyncResult);
            _inputQueue.EnqueueAndDispatch(workItem);

            return asyncResult;

        }

        public IAsyncResult BeginInvoke<T1, T2, TResult>(Func<T1, T2, TResult> function, T1 arg1, T2 arg2, AsyncCallback callback, object state)
        {
            var asyncResult = new ConsumerAsyncResult<object>(callback, state);

            object[] parameters = new object[2];
            parameters[0] = arg1;
            parameters[1] = arg2;

            var workItem = new WorkItem((Delegate)function, parameters, function.Target, asyncResult);
            _inputQueue.EnqueueAndDispatch(workItem);

            return asyncResult;

        }

        public IAsyncResult BeginInvoke<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> function, T1 arg1, T2 arg2, T3 arg3, AsyncCallback callback, object state)
        {
            var asyncResult = new ConsumerAsyncResult<object>(callback, state);

            object[] parameters = new object[3];
            parameters[0] = arg1;
            parameters[1] = arg2;
            parameters[2] = arg3;

            var workItem = new WorkItem((Delegate)function, parameters, function.Target, asyncResult);
            _inputQueue.EnqueueAndDispatch(workItem);

            return asyncResult;

        }

        public IAsyncResult BeginInvoke<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> function, T1 arg1, T2 arg2, T3 arg3, T4 arg4, AsyncCallback callback, object state)
        {
            var asyncResult = new ConsumerAsyncResult<object>(callback, state);

            object[] parameters = new object[4];
            parameters[0] = arg1;
            parameters[1] = arg2;
            parameters[2] = arg3;
            parameters[3] = arg4;

            var workItem = new WorkItem((Delegate)function, parameters, function.Target, asyncResult);
            _inputQueue.EnqueueAndDispatch(workItem);

            return asyncResult;

        }

        public IAsyncResult BeginInvoke<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> function, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, AsyncCallback callback, object state)
        {
            var asyncResult = new ConsumerAsyncResult<object>(callback, state);

            object[] parameters = new object[5];
            parameters[0] = arg1;
            parameters[1] = arg2;
            parameters[2] = arg3;
            parameters[3] = arg4;
            parameters[4] = arg5;

            var workItem = new WorkItem((Delegate)function, parameters, function.Target, asyncResult);
            _inputQueue.EnqueueAndDispatch(workItem);

            return asyncResult;

        }

        public IAsyncResult BeginInvoke<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> function, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, AsyncCallback callback, object state)
        {
            var asyncResult = new ConsumerAsyncResult<object>(callback, state);

            object[] parameters = new object[6];
            parameters[0] = arg1;
            parameters[1] = arg2;
            parameters[2] = arg3;
            parameters[3] = arg4;
            parameters[4] = arg5;
            parameters[5] = arg6;

            var workItem = new WorkItem((Delegate)function, parameters, function.Target, asyncResult);
            _inputQueue.EnqueueAndDispatch(workItem);

            return asyncResult;

        }

        public IAsyncResult BeginInvoke<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> function, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, AsyncCallback callback, object state)
        {
            var asyncResult = new ConsumerAsyncResult<object>(callback, state);

            object[] parameters = new object[7];
            parameters[0] = arg1;
            parameters[1] = arg2;
            parameters[2] = arg3;
            parameters[3] = arg4;
            parameters[4] = arg5;
            parameters[5] = arg6;
            parameters[6] = arg7;

            var workItem = new WorkItem((Delegate)function, parameters, function.Target, asyncResult);
            _inputQueue.EnqueueAndDispatch(workItem);

            return asyncResult;

        }

        public IAsyncResult BeginInvoke<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> function, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, AsyncCallback callback, object state)
        {
            var asyncResult = new ConsumerAsyncResult<object>(callback, state);

            object[] parameters = new object[8];
            parameters[0] = arg1;
            parameters[1] = arg2;
            parameters[2] = arg3;
            parameters[3] = arg4;
            parameters[4] = arg5;
            parameters[5] = arg6;
            parameters[6] = arg7;
            parameters[7] = arg8;

            var workItem = new WorkItem((Delegate)function, parameters, function.Target, asyncResult);
            _inputQueue.EnqueueAndDispatch(workItem);

            return asyncResult;

        }

        public IAsyncResult BeginInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> function, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, AsyncCallback callback, object state)
        {
            var asyncResult = new ConsumerAsyncResult<object>(callback, state);

            object[] parameters = new object[9];
            parameters[0] = arg1;
            parameters[1] = arg2;
            parameters[2] = arg3;
            parameters[3] = arg4;
            parameters[4] = arg5;
            parameters[5] = arg6;
            parameters[6] = arg7;
            parameters[7] = arg8;
            parameters[8] = arg9;

            var workItem = new WorkItem((Delegate)function, parameters, function.Target, asyncResult);
            _inputQueue.EnqueueAndDispatch(workItem);

            return asyncResult;

        }

        public IAsyncResult BeginInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> function, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, AsyncCallback callback, object state)
        {
            var asyncResult = new ConsumerAsyncResult<object>(callback, state);

            object[] parameters = new object[10];
            parameters[0] = arg1;
            parameters[1] = arg2;
            parameters[2] = arg3;
            parameters[3] = arg4;
            parameters[4] = arg5;
            parameters[5] = arg6;
            parameters[6] = arg7;
            parameters[7] = arg8;
            parameters[8] = arg9;
            parameters[9] = arg10;

            var workItem = new WorkItem((Delegate)function, parameters, function.Target, asyncResult);
            _inputQueue.EnqueueAndDispatch(workItem);

            return asyncResult;

        }

        public IAsyncResult BeginInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> function, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, AsyncCallback callback, object state)
        {
            var asyncResult = new ConsumerAsyncResult<object>(callback, state);

            object[] parameters = new object[11];
            parameters[0] = arg1;
            parameters[1] = arg2;
            parameters[2] = arg3;
            parameters[3] = arg4;
            parameters[4] = arg5;
            parameters[5] = arg6;
            parameters[6] = arg7;
            parameters[7] = arg8;
            parameters[8] = arg9;
            parameters[9] = arg10;
            parameters[10] = arg11;

            var workItem = new WorkItem((Delegate)function, parameters, function.Target, asyncResult);
            _inputQueue.EnqueueAndDispatch(workItem);

            return asyncResult;
        }

        public IAsyncResult BeginInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> function, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, AsyncCallback callback, object state)
        {
            var asyncResult = new ConsumerAsyncResult<object>(callback, state);

            object[] parameters = new object[12];
            parameters[0] = arg1;
            parameters[1] = arg2;
            parameters[2] = arg3;
            parameters[3] = arg4;
            parameters[4] = arg5;
            parameters[5] = arg6;
            parameters[6] = arg7;
            parameters[7] = arg8;
            parameters[8] = arg9;
            parameters[9] = arg10;
            parameters[10] = arg11;
            parameters[11] = arg12;

            var workItem = new WorkItem((Delegate)function, parameters, function.Target, asyncResult);
            _inputQueue.EnqueueAndDispatch(workItem);

            return asyncResult;

        }

        public IAsyncResult BeginInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> function, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, AsyncCallback callback, object state)
        {
            var asyncResult = new ConsumerAsyncResult<object>(callback, state);

            object[] parameters = new object[13];
            parameters[0] = arg1;
            parameters[1] = arg2;
            parameters[2] = arg3;
            parameters[3] = arg4;
            parameters[4] = arg5;
            parameters[5] = arg6;
            parameters[6] = arg7;
            parameters[7] = arg8;
            parameters[8] = arg9;
            parameters[9] = arg10;
            parameters[10] = arg11;
            parameters[11] = arg12;
            parameters[12] = arg13;

            var workItem = new WorkItem((Delegate)function, parameters, function.Target, asyncResult);
            _inputQueue.EnqueueAndDispatch(workItem);

            return asyncResult;
        }

        public IAsyncResult BeginInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> function, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, AsyncCallback callback, object state)
        {
            var asyncResult = new ConsumerAsyncResult<object>(callback, state);

            object[] parameters = new object[14];
            parameters[0] = arg1;
            parameters[1] = arg2;
            parameters[2] = arg3;
            parameters[3] = arg4;
            parameters[4] = arg5;
            parameters[5] = arg6;
            parameters[6] = arg7;
            parameters[7] = arg8;
            parameters[8] = arg9;
            parameters[9] = arg10;
            parameters[10] = arg11;
            parameters[11] = arg12;
            parameters[12] = arg13;
            parameters[13] = arg14;

            var workItem = new WorkItem((Delegate)function, parameters, function.Target, asyncResult);
            _inputQueue.EnqueueAndDispatch(workItem);

            return asyncResult;
        }

        public IAsyncResult BeginInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> function, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, AsyncCallback callback, object state)
        {
            var asyncResult = new ConsumerAsyncResult<object>(callback, state);

            object[] parameters = new object[15];
            parameters[0] = arg1;
            parameters[1] = arg2;
            parameters[2] = arg3;
            parameters[3] = arg4;
            parameters[4] = arg5;
            parameters[5] = arg6;
            parameters[6] = arg7;
            parameters[7] = arg8;
            parameters[8] = arg9;
            parameters[9] = arg10;
            parameters[10] = arg11;
            parameters[11] = arg12;
            parameters[12] = arg13;
            parameters[13] = arg14;
            parameters[14] = arg15;

            var workItem = new WorkItem((Delegate)function, parameters, function.Target, asyncResult);
            _inputQueue.EnqueueAndDispatch(workItem);

            return asyncResult;
        }

        public object EndInvoke(IAsyncResult asyncResult)
        {
            var castedAsyncResult = asyncResult as ConsumerAsyncResult<object>;
            return castedAsyncResult.EndInvoke();
        }

        public TResult EndInvoke<TResult>(IAsyncResult asyncResult)
        {
            return (TResult)EndInvoke(asyncResult);
        }

        #endregion

        #endregion

        #region IDisposable Implementation

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool managedResources)
        {
            if (_state == AsyncConsumerState.Waiting)
            {
                SetState(AsyncConsumerState.Finishing);
                _workerThread.Interrupt();
            }

            if (_workerThread.IsAlive)
            {
                if (_state != AsyncConsumerState.Finishing)
                {
                    SetState(AsyncConsumerState.Finishing);
                }
                _workerThread.Join(800);
                _workerThread.Abort();
            }

            SetState(AsyncConsumerState.Finished);

            if (managedResources)
            {
                _workerThread = null;
                _inputQueue.Dispose();
                _inputQueue = null;
            }
        }

        #endregion

        #region Private Methods

        private void MainExecution()
        {
            while (true)
            {
                SetState(AsyncConsumerState.Waiting);
                try
                {
                    WorkItem work = _inputQueue.Dequeue(TimeSpan.MaxValue);
                    SetState(AsyncConsumerState.Executing);
                    work.Execute();
                }
                catch (ThreadInterruptedException)
                {
                    if (_state != AsyncConsumerState.Finishing)
                    {
                        throw;
                    }
                }
            }
        }

        private void SetState(AsyncConsumerState newState)
        {
            lock (_stateLock)
            {
                if (_state != AsyncConsumerState.Finishing && newState != AsyncConsumerState.Finished || _state != AsyncConsumerState.Finished)
                {
                    _state = newState;
                }
            }
        }

        #endregion
    }
}
