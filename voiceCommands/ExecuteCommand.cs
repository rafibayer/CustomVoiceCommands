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
            // should be factored out and build from user created commands
            Dictionary<String, ICommand> commands = new Dictionary<String, ICommand>();

            // TODO: load from file or other sources
            // sample command for testing

            // ####################################
            // simple process start
            /*
            CliCommand myCommand = new CliCommand(
                "calculator",
                "Open Calc",
                "Opens the Calculator",
                "calc.exe");
            commands.Add(myCommand.Command, myCommand);

            // open chrome to a url
            CliCommand openAzure = new CliCommand(
                "azure",
                "Open Azure",
                "Opens Azure Website",
                "start chrome https://azure.microsoft.com/en-us/"
                );
            commands.Add(openAzure.Command, openAzure);

            // call an internal windows function
            CliCommand lockPC = new CliCommand(
                "lock",
                "Lock PC",
                "Locks windows PC",
                @"C:\WINDOWS\system32\rundll32.exe user32.dll, LockWorkStation"
                );
            commands.Add(lockPC.Command, lockPC);

            // execute a script
            CliCommand smile = new CliCommand(
                "smile",
                "Make Smiley",
                "Generates a smiley face with python",
                @"python c:/Users/Easy_/Desktop/PyCommands/Smile.py"
            );

            commands.Add(smile.Command, smile);
            */
            // ####################################


            // read commands from CSV and add all as new CLI commands
            var commandList = CsvReader.readCSV("commands.csv"); // file contents
            string[] columns = CsvReader.columns; // order of columns
            foreach (String cmd in commandList)
            {
                String[] values = cmd.Split( CsvReader.sep); // command values

                commands.Add
                (
                    values[Array.IndexOf(columns, "Name")], // value index of name

                    new CliCommand
                    (
                        // value indicies for all parameters for command constructor
                        values[Array.IndexOf(columns, "Command")],
                        values[Array.IndexOf(columns, "Name")],
                        values[Array.IndexOf(columns, "Descr")],
                        values[Array.IndexOf(columns, "CLI")]
                    )
                );


            }



            ICommand mapValue;
            if (commands.TryGetValue(command, out mapValue))
            {
                mapValue.Execute();
               
            }
            else
            {
                Console.WriteLine("Command not found");
            }

        }


        

    }

    
}
