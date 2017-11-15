using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLTest
{
    public class Model
    {
        public Model()
        {
            Threads = new List<string>();
        }
        public DateTime? ReceivedDate { get; set; }
        
        public List<string> Threads { get; set; }
    }
}
