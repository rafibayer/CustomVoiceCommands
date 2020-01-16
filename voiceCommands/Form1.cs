using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
        // used for binding and unbinding hotkey
        const int HOTKEY_ACTION_ID = 1;


        public Form1()
        {
            

            InitializeComponent();
            InitializeCommandGridView();
            InitializeHotkey();

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

        // initialize hotkey to the binding found in hotkey.JSON
        // reflect these values in the form
        private void InitializeHotkey()
        {
            // unregister old hotkey (if it exists)
            UnregisterHotKey(this.Handle, HOTKEY_ACTION_ID);

            // read hotkey json
            JsonValue json = JsonObject.Parse(File.ReadAllText("hotkey.json"));

            Console.WriteLine($"Read: {json.ToString()}");


            // get the keybind
            Keys key;
            Enum.TryParse(json["key"], out key);
            int keyInt = (int)key;

            // modifier values modifiers 
            int mod = 0;
            // booleans for form reflection
            bool alt = false; bool ctrl = false; bool shift = false;

            // get modifier values
            if (json["mod"]["alt"])
            {
                mod |= 1; 
                alt = true;
            }
            if (json["mod"]["ctrl"])
            {
                mod |= 2;
                ctrl = true;

            }
            if (json["mod"]["shift"])
            {
                mod |= 4;
                shift = true;
            }

            // register the hotkey
            RegisterHotKey(this.Handle, HOTKEY_ACTION_ID, mod, keyInt);

            // reflect json in form
                // checkbox
            hotkeyMod.SetItemCheckState(0, alt ? CheckState.Checked : CheckState.Unchecked);
            hotkeyMod.SetItemCheckState(1, ctrl ? CheckState.Checked : CheckState.Unchecked);
            hotkeyMod.SetItemCheckState(2, shift ? CheckState.Checked : CheckState.Unchecked);
                // text
            hotkeyText.Text = key.ToString();


        }

        // read values from the form
        // update hotkey.json
        // rebind hotkey
        private void hotkeySave_Click(object sender, EventArgs e)
        {
            // record data from form and build JSON
            JsonValue newHotkey = new JsonObject();
            newHotkey["key"] = hotkeyText.Text.ToString();
            newHotkey["mod"] = new JsonObject();
            newHotkey["mod"]["alt"] = (hotkeyMod.GetItemCheckState(0) == CheckState.Checked);
            newHotkey["mod"]["ctrl"] = (hotkeyMod.GetItemCheckState(1) == CheckState.Checked);
            newHotkey["mod"]["shift"] = (hotkeyMod.GetItemCheckState(2) == CheckState.Checked);

            Console.WriteLine($"Saving: {newHotkey.ToString()}");

            // save
            File.WriteAllText("hotkey.json", newHotkey.ToString());

            // rebind hotkey
            InitializeHotkey();


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
            // ensures that any pending changes to the DataGridView
            // are finalized before saving
            save.Focus();
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
