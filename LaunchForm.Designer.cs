namespace QlikSenseLoopandReduce
{
    partial class LaunchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaunchForm));
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtScript = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbApps = new System.Windows.Forms.ComboBox();
            this.cmbStreams = new System.Windows.Forms.ComboBox();
            this.cmbLoopField = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMessageBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(139, 21);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(249, 20);
            this.txtServer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "App to Loop";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(313, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Go Loop...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Stream to publish to";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(394, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(59, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Connect";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtScript
            // 
            this.txtScript.Location = new System.Drawing.Point(139, 141);
            this.txtScript.Name = "txtScript";
            this.txtScript.Size = new System.Drawing.Size(248, 20);
            this.txtScript.TabIndex = 9;
            this.txtScript.Text = "set vLoopAndReduceFieldValue = <replace>;";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Script line to insert";
            // 
            // cmbApps
            // 
            this.cmbApps.DisplayMember = "Name";
            this.cmbApps.FormattingEnabled = true;
            this.cmbApps.Location = new System.Drawing.Point(139, 54);
            this.cmbApps.Name = "cmbApps";
            this.cmbApps.Size = new System.Drawing.Size(248, 21);
            this.cmbApps.TabIndex = 11;
            this.cmbApps.ValueMember = "ID";
            this.cmbApps.SelectedIndexChanged += new System.EventHandler(this.cmbApps_SelectedIndexChanged);
            // 
            // cmbStreams
            // 
            this.cmbStreams.DisplayMember = "Name";
            this.cmbStreams.FormattingEnabled = true;
            this.cmbStreams.Location = new System.Drawing.Point(140, 112);
            this.cmbStreams.Name = "cmbStreams";
            this.cmbStreams.Size = new System.Drawing.Size(248, 21);
            this.cmbStreams.TabIndex = 12;
            this.cmbStreams.ValueMember = "ID";
            // 
            // cmbLoopField
            // 
            this.cmbLoopField.DisplayMember = "FallbackTitle";
            this.cmbLoopField.FormattingEnabled = true;
            this.cmbLoopField.Location = new System.Drawing.Point(139, 85);
            this.cmbLoopField.Name = "cmbLoopField";
            this.cmbLoopField.Size = new System.Drawing.Size(248, 21);
            this.cmbLoopField.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Field to Loop on";
            // 
            // txtMessageBox
            // 
            this.txtMessageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessageBox.Location = new System.Drawing.Point(36, 226);
            this.txtMessageBox.Multiline = true;
            this.txtMessageBox.Name = "txtMessageBox";
            this.txtMessageBox.Size = new System.Drawing.Size(351, 79);
            this.txtMessageBox.TabIndex = 19;
            this.txtMessageBox.Text = resources.GetString("txtMessageBox.Text");
            // 
            // LaunchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(478, 356);
            this.Controls.Add(this.txtMessageBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbLoopField);
            this.Controls.Add(this.cmbStreams);
            this.Controls.Add(this.cmbApps);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtScript);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LaunchForm";
            this.Text = "Qlik Sense Loop and Reduce (on reload)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtScript;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbApps;
        private System.Windows.Forms.ComboBox cmbStreams;
        private System.Windows.Forms.ComboBox cmbLoopField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMessageBox;

    }
}

