namespace SQL_Example
{
    partial class MainForm
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
            this.logoutButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(240, 12);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 23);
            this.logoutButton.TabIndex = 0;
            this.logoutButton.Text = "登出";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 300);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.logoutButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button button1;
    }
}