using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPLTest
{
    public class Repository
    {
        private Port _port;

        public Repository()
        {
            _port = new Port();
        }
        
        public Task<Model> GetModelAsync()
        {
            TaskCompletionSource<Model> taskSource = new TaskCompletionSource<Model>();

            Task.Factory.StartNew(() =>
            {
                _port.AddMessageAction(model =>
                {
                    var modelCopy = new Model { ReceivedDate = model.ReceivedDate};
                    modelCopy.Threads.Add(Thread.CurrentThread.ManagedThreadId.ToString());
                    modelCopy.Threads.AddRange(model.Threads);
                    taskSource.SetResult(modelCopy);
                });
                
            });
            
            _port.Send();

            return taskSource.Task;
        }
    }
}
