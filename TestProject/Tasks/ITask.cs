using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Tasks
{
    /// <summary>
    /// Interface for Task
    /// </summary>
    interface ITask
    {
        
            string Name { get; set; }


            Execution Status { get; set; }

            void Run();
           
        
    }
}
