using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voiceCommands
{
    class ExecuteCommand
    {
        public static void execute(String command)
        {
            command = command.ToLower().Trim();
            command = command.Trim(new[] {'.', '!', '?', ','}); // strip trailing punctuation
            
            Console.WriteLine($"Executing command: {command}");
            Dictionary<String, String> commands = new Dictionary<String, String>();
            commands.Add("password", "all I see is ********?");


            string mapValue;
            if (commands.TryGetValue(command, out mapValue))
            {
                Console.WriteLine(mapValue);
            }

        }

    }
}
