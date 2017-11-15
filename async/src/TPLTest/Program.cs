using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new Repository();

            var task = repository.GetModelAsync();

            var model = task.Result;
            
            Console.WriteLine(model.ReceivedDate);
         }
    }
}
