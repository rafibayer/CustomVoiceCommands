using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace voiceCommands
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Console.WriteLine("Running now:");

            var data = CsvReader.readCSV("commands.csv");
            foreach (String s in data)
            {
                Console.WriteLine(s);
            }

            CsvReader.writeCSV("commands2.csv", data);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            

           






            
        }
    }
}
