using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace voiceCommands
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listenButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Listen Button was pressed");

            Console.WriteLine("Start speaking now:");
            speechToText.RecognizeSpeechAsync().ConfigureAwait(true);


          
        }
    }
}
