
namespace View
{
    partial class StartScreen
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
            this.Title_Label = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox_players = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exit_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.bagelType_comboBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title_Label
            // 
            this.Title_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Title_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F);
            this.Title_Label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Title_Label.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Title_Label.Location = new System.Drawing.Point(0, 49);
            this.Title_Label.Name = "Title_Label";
            this.Title_Label.Size = new System.Drawing.Size(800, 751);
            this.Title_Label.TabIndex = 0;
            this.Title_Label.Text = "Catch the Bagel";
            this.Title_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Start
            // 
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Start.Location = new System.Drawing.Point(258, 487);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(255, 99);
            this.Start.TabIndex = 1;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(210, 595);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(0, 0);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox_players
            // 
            this.comboBox_players.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_players.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBox_players.FormattingEnabled = true;
            this.comboBox_players.Items.AddRange(new object[] {
            "Man Bagel",
            "Ghostly Bagel",
            "Beary Pink",
            "Camper Duck"});
            this.comboBox_players.Location = new System.Drawing.Point(238, 238);
            this.comboBox_players.Name = "comboBox_players";
            this.comboBox_players.Size = new System.Drawing.Size(300, 39);
            this.comboBox_players.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(203, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 80);
            this.label1.TabIndex = 5;
            this.label1.Text = "Choose your fighter:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 49);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.controlsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(104, 45);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(296, 54);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // controlsToolStripMenuItem
            // 
            this.controlsToolStripMenuItem.Name = "controlsToolStripMenuItem";
            this.controlsToolStripMenuItem.Size = new System.Drawing.Size(296, 54);
            this.controlsToolStripMenuItem.Text = "Controls";
            this.controlsToolStripMenuItem.Click += new System.EventHandler(this.controlsToolStripMenuItem_Click);
            // 
            // exit_button
            // 
            this.exit_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.exit_button.Location = new System.Drawing.Point(258, 621);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(255, 99);
            this.exit_button.TabIndex = 7;
            this.exit_button.Text = "Exit";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(128, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(525, 80);
            this.label2.TabIndex = 8;
            this.label2.Text = "Choose your bagel of your choice or perhaps donut:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bagelType_comboBox
            // 
            this.bagelType_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bagelType_comboBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.bagelType_comboBox.FormattingEnabled = true;
            this.bagelType_comboBox.Items.AddRange(new object[] {
            "Plain Bagel",
            "Cheese & Jalapeño Bagel",
            "Bart Donut",
            "Sugar Donut"});
            this.bagelType_comboBox.Location = new System.Drawing.Point(194, 397);
            this.bagelType_comboBox.Name = "bagelType_comboBox";
            this.bagelType_comboBox.Size = new System.Drawing.Size(388, 39);
            this.bagelType_comboBox.TabIndex = 9;
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Controls.Add(this.bagelType_comboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_players);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.Title_Label);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StartScreen";
            this.Text = "Catch the Bagel";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title_Label;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox_players;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlsToolStripMenuItem;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox bagelType_comboBox;
    }
}