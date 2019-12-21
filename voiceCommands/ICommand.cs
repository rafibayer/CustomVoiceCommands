using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voiceCommands
{
    interface ICommand
    {
        void Execute();

        String Command { get; set; }
        String Name { get; set; }
        String Descr { get; set; }


    }
}
