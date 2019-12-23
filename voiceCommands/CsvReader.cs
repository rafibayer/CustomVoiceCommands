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
        // CSV columns
        private static readonly String[] columns = { "Command", "Name", "Descr", "CLI" };
        private static readonly char sep = '|';

        // creates tab-sep csv with columns as header
        // called when no command file exists
        private static void createCSV(String filepath)
        {
            StringBuilder sb = new StringBuilder(String.Join(char.ToString(sep), columns));
            File.WriteAllText(@filepath, sb.ToString());

        }


        // Read a csv stored at filepath with separator sep and return as a Dict<String, List<String>>
        // if the csv doesn't exists, it creates and returns a csv with the appropriate columns
        public static Dictionary<String, List<String>> readCSV(String filepath)
        {
            Dictionary<String, List<String>> res = new Dictionary<string, List<string>>();
            if (!File.Exists(@filepath))
            {
                createCSV(@filepath);
            }
            using (var reader = new StreamReader(@filepath))
            {
                // create dict with keys for each column and empty lists as values
                String[] header = reader.ReadLine().Split(sep);
                foreach (String h in header)
                {
                    res.Add(h, new List<String>());
                }

                // keep reading lines and adding to dict by
                // column until the end of the file
                while (!reader.EndOfStream)
                {
                    // current line split by col
                    String[] line = reader.ReadLine().Split(sep);

                    // add to appropriate header
                    for (int i = 0; i < header.Length; i++)
                    {
                        res[header[i]].Add(line[i]);
                    }
                }
            }
          
            return res;
        }

        // takes a dictionary<String, List<String>> and writes to a csv at filepath with separator sep
        public static void writeCSV(String filepath, Dictionary<String, List<String>> commands)
        {

            StringBuilder sb = new StringBuilder(String.Join(char.ToString(sep), commands.Keys) + "\n");

            Console.WriteLine($"Write header: {sb.ToString()}");

            // number of commands stored in dict
            int numCommands = commands[commands.Keys.ToList()[0]].Count;

            // read columns line by line and add to sb
            for (int i = 0; i < numCommands; i++)
            {
                String[] line = new String[columns.Length];
                for (int j = 0; j < columns.Length; j++)
                {
                    line[j] = commands[columns[j]][i]; 
                }
                sb.Append(String.Join(sep.ToString(), line) + "\n");
            }



            Console.WriteLine($"Final CSV:\n{sb.ToString()}");

            File.WriteAllText(@filepath, sb.ToString());

        }

        public static void appendCSV(String filepath, List<String> command);
        


    }
}
