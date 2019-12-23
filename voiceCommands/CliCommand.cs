using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voiceCommands
{
    class CliCommand : ICommand
    {

        public String Command { get; set; }
        public String Name { get; set; }
        public String Descr { get; set; }
        public String CLI { get; set; }



        public CliCommand(String Command, String Name, String Descr, String CLI)
        {
            this.Command = Cleaner.Clean(Command);
            this.Name = Name;
            this.Descr = Descr;
            this.CLI = CLI;
        }

        public void Execute()
        {
            // execute the CLI command
            // TODO: hide cmd window
            System.Diagnostics.Process.Start("CMD.exe", "/C" + @CLI);

        }
    }
}
