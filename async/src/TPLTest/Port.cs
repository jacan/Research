using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPLTest
{
    public class Port
    {
        private Action<Model> _modelDelegate;
        
        private ManualResetEvent _signal;
        public void Send()
        {
	        var t = new Thread(() =>
	        {
		        Thread.Sleep(3000);

		        var model = new Model
		        {
			        ReceivedDate = DateTime.Now,
		        };

		        model.Threads.Add(Thread.CurrentThread.ManagedThreadId.ToString());

		        _modelDelegate.Invoke(model);
	        })
	        {
		        Name = "LongRunningThreád"
	        };

	        t.Start();
        }

        public void AddMessageAction(Action<Model> handler)
        {
            _modelDelegate = handler;
        }
    }
}
