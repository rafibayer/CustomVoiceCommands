using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voiceCommands
{
    static class ExecuteCommand
    {
        // if the command contains this word, cancel the command
        // should be factored out and configurable by user
        public const string cancelKeyword = "cancel";

        public static void Execute(String command)
        {
            command = Cleaner.Clean(command);
            
            Console.WriteLine($"Executing command: {command}");

            // check if the command contains the cancel keyword
            // if it does, return immediately 
            if (command.Contains(cancelKeyword))
            {
                Console.WriteLine($"Recognized cancel keyword: {cancelKeyword}");
                return;
            }

            // dictionary of commands
            Dictionary<String, ICommand> commands = new Dictionary<String, ICommand>();


            // read commands from CSV and add all as new CLI commands
            // TODO: only call this when program starts or when commands change
            // write now we are calling it everytime a command is executed which may be slow (disk IO)
            var commandList = CsvReader.readCSV("commands.csv"); // file contents
            string[] columns = CsvReader.columns; // order of columns
            foreach (String cmd in commandList)
            {
                String[] values = cmd.Split( CsvReader.sep); // command values

                commands.Add
                (
                    Cleaner.Clean(values[Array.IndexOf(columns, "Command")]), // value index of command

                    new CliCommand
                    (
                        // value indicies for all parameters for command constructor
                        Cleaner.Clean(values[Array.IndexOf(columns, "Command")]),
                        values[Array.IndexOf(columns, "Name")],
                        values[Array.IndexOf(columns, "Descr")],
                        values[Array.IndexOf(columns, "CLI")]
                    )
                );
            }

            // try to find the command said by the user
            ICommand mapValue;
            if (commands.TryGetValue(command, out mapValue))
            {
                mapValue.Execute(); // if found, execute it
            }
            else
            {
                Console.WriteLine("Command not found"); // otherwise print not found
            }
        }
    }
}
