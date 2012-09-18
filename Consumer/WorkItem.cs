using System;

namespace Cjam.Threading.Consumer
{
    internal class WorkItem
    {
        private Delegate _funcion;
        private object[] _functionParameters;
        private object _classInstance;
        private IAsyncResult _result;

        public WorkItem(Delegate function, object[] functionParameters, object classInstance, IAsyncResult result)
        {
            _funcion = function;
            _functionParameters = functionParameters;
            _classInstance = classInstance;
            _result = result;
        }

        public void Execute()
        {
            object ret = _funcion.DynamicInvoke(_functionParameters);
            if (_result is ConsumerAsyncResult)
            {
                ConsumerAsyncResult castedResult = (ConsumerAsyncResult)ret;
                castedResult.SetComplete();
            }
            else if (_result is ConsumerAsyncResult<object>)
            {
                ConsumerAsyncResult<object> castedResult = (ConsumerAsyncResult<object>)_result;
                castedResult.SetComplete(ret);
            }
        }
    }
}
