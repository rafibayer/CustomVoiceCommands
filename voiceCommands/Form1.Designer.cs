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
            this.save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.hotkeyMod = new System.Windows.Forms.CheckedListBox();
            this.hotkeySave = new System.Windows.Forms.Button();
            this.hotkeyText = new System.Windows.Forms.TextBox();
            this.cmdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdCommand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdCLI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.commandDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // listenButton
            // 
            this.listenButton.Location = new System.Drawing.Point(12, 356);
            this.listenButton.Name = "listenButton";
            this.listenButton.Size = new System.Drawing.Size(74, 45);
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
            this.commandDataGrid.Size = new System.Drawing.Size(968, 527);
            this.commandDataGrid.TabIndex = 1;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(12, 33);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(74, 36);
            this.save.TabIndex = 2;
            this.save.Text = "Save Changes";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hotkey:";
            // 
            // hotkeyMod
            // 
            this.hotkeyMod.FormattingEnabled = true;
            this.hotkeyMod.Items.AddRange(new object[] {
            "ALT",
            "CTRL",
            "SHIFT"});
            this.hotkeyMod.Location = new System.Drawing.Point(12, 447);
            this.hotkeyMod.Name = "hotkeyMod";
            this.hotkeyMod.Size = new System.Drawing.Size(74, 64);
            this.hotkeyMod.TabIndex = 4;
            // 
            // hotkeySave
            // 
            this.hotkeySave.Location = new System.Drawing.Point(12, 517);
            this.hotkeySave.Name = "hotkeySave";
            this.hotkeySave.Size = new System.Drawing.Size(74, 43);
            this.hotkeySave.TabIndex = 5;
            this.hotkeySave.Text = "Save Hotkey";
            this.hotkeySave.UseVisualStyleBackColor = true;
            this.hotkeySave.Click += new System.EventHandler(this.hotkeySave_Click);
            // 
            // hotkeyText
            // 
            this.hotkeyText.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hotkeyText.Location = new System.Drawing.Point(12, 421);
            this.hotkeyText.MaxLength = 1;
            this.hotkeyText.Name = "hotkeyText";
            this.hotkeyText.Size = new System.Drawing.Size(73, 20);
            this.hotkeyText.TabIndex = 6;
            // 
            // cmdName
            // 
            this.cmdName.HeaderText = "Name";
            this.cmdName.Name = "cmdName";
            this.cmdName.ToolTipText = "Name of Command";
            this.cmdName.Width = 150;
            // 
            // cmdCommand
            // 
            this.cmdCommand.HeaderText = "Command";
            this.cmdCommand.Name = "cmdCommand";
            this.cmdCommand.ToolTipText = "Voice Command";
            this.cmdCommand.Width = 150;
            // 
            // cmdDescr
            // 
            this.cmdDescr.HeaderText = "Description";
            this.cmdDescr.Name = "cmdDescr";
            this.cmdDescr.ToolTipText = "Description of the command";
            this.cmdDescr.Width = 250;
            // 
            // cmdCLI
            // 
            this.cmdCLI.HeaderText = "CLI command";
            this.cmdCLI.Name = "cmdCLI";
            this.cmdCLI.ToolTipText = "CLI code to be executed";
            this.cmdCLI.Width = 500;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 596);
            this.Controls.Add(this.hotkeyText);
            this.Controls.Add(this.hotkeySave);
            this.Controls.Add(this.hotkeyMod);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.commandDataGrid);
            this.Controls.Add(this.listenButton);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "voiceCommands";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.commandDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button listenButton;
        private System.Windows.Forms.DataGridView commandDataGrid;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox hotkeyMod;
        private System.Windows.Forms.Button hotkeySave;
        private System.Windows.Forms.TextBox hotkeyText;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmdCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmdDescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmdCLI;
    }
}

