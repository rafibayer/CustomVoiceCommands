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
            // TODO: maybe map from String to function or CLI command?
            Dictionary<String, String> commands = new Dictionary<String, String>();

            // sample command for testing
            commands.Add("password", "all I see is ********?");


            // TEST COMMAND
            // TODO: FACTOR OUT
            if (command.Equals("calculator"))
            {
                openCalc();
            }

            // for now since we map to string, print the value string
            String mapValue;
            if (commands.TryGetValue(command, out mapValue))
            {
                Console.WriteLine(mapValue);
               
            }
            else
            {
                Console.WriteLine("Command not found");
            }

        }

        // test command
        // code to execute when calculator command is issued
        // TODO: FACTOR OUT
        private static void openCalc()
        {
            System.Diagnostics.Process.Start(@"calc.exe");
        }

    }

    
}
