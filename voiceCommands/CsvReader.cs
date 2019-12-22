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
        private static String[] columns = { "Command", "Name", "Descr", "CLI" };

        // creates tab-sep csv with columns as header
        // called when no command file exists
        private static void createCSV(String filepath, char sep = '\t')
        {
            StringBuilder sb = new StringBuilder(String.Join(char.ToString(sep), columns));
            File.WriteAllText(@filepath, sb.ToString());

        }


        // Read a csv stored at filepath with separator sep and return as a Dict<String, List<String>>
        // if the csv doesn't exists, it creates and returns a csv with the appropriate columns
        public static Dictionary<String, List<String>> readCSV(String filepath, char sep = '\t')
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

                while (!reader.EndOfStream)
                {
                    // add column values to dict
                    String[] line = reader.ReadLine().Split(sep);
                    for (int i = 0; i < line.Length; i++)
                    {
                        res[header[i]].Add(line[i]);
                    }
                }
            }

            return res;
        }

        // takes a dictionary<String, List<String>> and writes to a csv at filepath with separator sep
        public static void writeCSV(String filepath, Dictionary<String, List<String>> commands, char sep = '\t')
        {

            StringBuilder sb = new StringBuilder(String.Join(char.ToString(sep), commands.Keys));
            sb.Append("\n");
            List<List<String>> data = new List<List<String>>();

            // load command data into 2D list
            foreach (String k in commands.Keys)
            {
                data.Add(commands[k]);
                Console.WriteLine(String.Join("\t", commands[k]));
            }

            // write line to csv
            int numCommands = data[0].Count;
            for (int i = 0; i < numCommands; i++)
            {
                String line = String.Join(char.ToString(sep), data[i]);
                //Console.WriteLine(line);
                sb.AppendLine(line);

            }


            File.WriteAllText(@filepath, sb.ToString());


        } 



    }
}
