using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace voiceCommands
{
    public partial class Form1 : Form
    {

        // DLL libraries used to manage hotkeys
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        // hotkey action ID
        const int HOTKEY_ACTION_ID = 1;

        //TODO: MAKE HOTKEY configureable 
        // https://stackoverflow.com/questions/2964161/how-to-unregister-a-specific-hotkey-using-c-sharp


        public Form1()
        {
            // register the hotkey (default ALT+Q)
            RegisterHotKey(this.Handle, HOTKEY_ACTION_ID, 1, (int)Keys.Q);

            InitializeComponent();
            InitializeCommandGridView();

        }

        // hotkey call, invokes listen
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == HOTKEY_ACTION_ID)
            {


                Console.WriteLine("Hotkey pressed");
                listenButton_Click(null, null);

            }
            base.WndProc(ref m);
        }

        // when the listen button is clicked, call the SpeechToText component
        private void listenButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Listen Button was pressed");

            Console.WriteLine("Start speaking now:");
            speechToText.RecognizeSpeechAsync().ConfigureAwait(true);

        }

        // populates command grid view with the saved commands
        private void InitializeCommandGridView()
        {
            List<String> commands = CsvReader.readCSV("commands.csv");


            foreach (String cmd in commands)
            {
                DataGridViewRow row = (DataGridViewRow)commandDataGrid.Rows[0].Clone();
                String[] values = cmd.Split(CsvReader.sep);
                String[] columns = CsvReader.columns;

                foreach (String col in columns)
                {
                    row.Cells[0].Value = values[Array.IndexOf(columns, "Name")];
                    row.Cells[1].Value = values[Array.IndexOf(columns, "Command")];
                    row.Cells[2].Value = values[Array.IndexOf(columns, "Descr")];
                    row.Cells[3].Value = values[Array.IndexOf(columns, "CLI")];

                }

                commandDataGrid.Rows.Add(row);
            }
            
        }

        // saves the current datagridview as a csv of commands
        // skips rows with empty cells
        private void save_Click(object sender, EventArgs e)
        {
            // list to build
            List<String> commands = new List<String>();

            //foreach row
            foreach(DataGridViewRow row in commandDataGrid.Rows)
            {
                // build command out of cell componenets
                List<String> command = new List<String>();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // if the cell is populated
                    if (cell.Value != null && !cell.Value.Equals(""))
                    {
                        command.Add(cell.Value.ToString());
                        Console.WriteLine($"Adding: {cell.Value.ToString()}");
                    }
                    else
                    {
                        Console.WriteLine($"Null/Empty cell detected in cell {cell}");
                    }
                    
                }

                // join command into csv line and add to commands list
                commands.Add(String.Join(CsvReader.sep.ToString(), command));
                
            }

            // write commands list to csv
            CsvReader.writeCSV("commands.csv", commands);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // save shorcut:
            if (e.Control && e.KeyCode == Keys.S)
            {
                // invoke the save click function
                save_Click(null, null);
            }

        }
    }
}
