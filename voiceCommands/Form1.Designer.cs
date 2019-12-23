namespace voiceCommands
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listenButton = new System.Windows.Forms.Button();
            this.commandDataGrid = new System.Windows.Forms.DataGridView();
            this.cmdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdCommand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdCLI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.commandDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // listenButton
            // 
            this.listenButton.Location = new System.Drawing.Point(12, 33);
            this.listenButton.Name = "listenButton";
            this.listenButton.Size = new System.Drawing.Size(95, 45);
            this.listenButton.TabIndex = 0;
            this.listenButton.Text = "listen";
            this.listenButton.UseVisualStyleBackColor = true;
            this.listenButton.Click += new System.EventHandler(this.listenButton_Click);
            // 
            // commandDataGrid
            // 
            this.commandDataGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.commandDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.commandDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmdName,
            this.cmdCommand,
            this.cmdDescr,
            this.cmdCLI});
            this.commandDataGrid.Location = new System.Drawing.Point(132, 33);
            this.commandDataGrid.Name = "commandDataGrid";
            this.commandDataGrid.Size = new System.Drawing.Size(745, 405);
            this.commandDataGrid.TabIndex = 1;
            this.commandDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // cmdName
            // 
            this.cmdName.HeaderText = "Name";
            this.cmdName.Name = "cmdName";
            this.cmdName.ToolTipText = "Command name";
            // 
            // cmdCommand
            // 
            this.cmdCommand.HeaderText = "Command";
            this.cmdCommand.Name = "cmdCommand";
            this.cmdCommand.ToolTipText = "What you say to activate this command";
            // 
            // cmdDescr
            // 
            this.cmdDescr.HeaderText = "Description";
            this.cmdDescr.Name = "cmdDescr";
            this.cmdDescr.ToolTipText = "description of the command";
            this.cmdDescr.Width = 200;
            // 
            // cmdCLI
            // 
            this.cmdCLI.HeaderText = "CLI command";
            this.cmdCLI.Name = "cmdCLI";
            this.cmdCLI.ToolTipText = "CLI code to be executed";
            this.cmdCLI.Width = 300;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(12, 147);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(95, 36);
            this.save.TabIndex = 2;
            this.save.Text = "Save Changes";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 450);
            this.Controls.Add(this.save);
            this.Controls.Add(this.commandDataGrid);
            this.Controls.Add(this.listenButton);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "voiceCommands";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.commandDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button listenButton;
        private System.Windows.Forms.DataGridView commandDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmdCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmdDescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmdCLI;
        private System.Windows.Forms.Button save;
    }
}

