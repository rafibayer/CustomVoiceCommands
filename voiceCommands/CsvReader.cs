using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace voiceCommands
{
    static class CsvReader
    {
        // CSV separator
        public static readonly char sep = '|';
        // CSV columns

        public static readonly String[] columns = { "Name", "Command", "Descr", "CLI" };

        public static List<String> readCSV(String filepath)
        {
            List<String> commands = new List<String>();
            
            // create command list if does not exist
            if (!File.Exists(@filepath))
            {
                writeCSV(@filepath, commands);
            }

            using (var reader = new StreamReader(@filepath))
            {
                String header = reader.ReadLine();
                if (! header.Equals(String.Join(sep.ToString(), columns)))
                {
                    throw new IOException("CSV header did not match columns, CSV may be malformed or using wrong sep");
                }

                Console.WriteLine($"Header: {header}");

                while (!reader.EndOfStream)
                {
                    String line = reader.ReadLine();
                    if (line.Equals(""))
                    {
                        Console.WriteLine("Blank/empty lines found in CSV");
                        break;
                    }
                    commands.Add(line);
                }
            }
            return commands;
        }

        public static void writeCSV(String filepath, List<String> commands)
        {
            StringBuilder csv = new StringBuilder(String.Join(sep.ToString(), columns) + "\n");

            foreach(String s in commands)
            {
                csv.AppendLine(s);
            }

            File.WriteAllText(@filepath, csv.ToString());
        }
    }
}
