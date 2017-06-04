namespace 夢想之都管理程式
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
            this.userBox = new System.Windows.Forms.GroupBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.urlBox = new System.Windows.Forms.GroupBox();
            this.messageBox = new System.Windows.Forms.GroupBox();
            this.departmentLabel = new System.Windows.Forms.Label();
            this.permissionLabel = new System.Windows.Forms.Label();
            this.檔案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.登出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重新整理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.結束ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // userBox
            // 
            this.userBox.Controls.Add(this.permissionLabel);
            this.userBox.Controls.Add(this.departmentLabel);
            this.userBox.Controls.Add(this.nameLabel);
            this.userBox.Location = new System.Drawing.Point(14, 29);
            this.userBox.Margin = new System.Windows.Forms.Padding(5);
            this.userBox.Name = "userBox";
            this.userBox.Padding = new System.Windows.Forms.Padding(5);
            this.userBox.Size = new System.Drawing.Size(301, 128);
            this.userBox.TabIndex = 1;
            this.userBox.TabStop = false;
            this.userBox.Text = "用戶資料";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(10, 27);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(92, 20);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "nameLabel";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.檔案ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(590, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // urlBox
            // 
            this.urlBox.Location = new System.Drawing.Point(14, 167);
            this.urlBox.Margin = new System.Windows.Forms.Padding(5);
            this.urlBox.Name = "urlBox";
            this.urlBox.Padding = new System.Windows.Forms.Padding(5);
            this.urlBox.Size = new System.Drawing.Size(301, 203);
            this.urlBox.TabIndex = 1;
            this.urlBox.TabStop = false;
            this.urlBox.Text = "URL";
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(329, 29);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(249, 341);
            this.messageBox.TabIndex = 3;
            this.messageBox.TabStop = false;
            this.messageBox.Text = "留言板";
            // 
            // departmentLabel
            // 
            this.departmentLabel.AutoSize = true;
            this.departmentLabel.Location = new System.Drawing.Point(10, 61);
            this.departmentLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.departmentLabel.Name = "departmentLabel";
            this.departmentLabel.Size = new System.Drawing.Size(139, 20);
            this.departmentLabel.TabIndex = 3;
            this.departmentLabel.Text = "departmentLabel";
            // 
            // permissionLabel
            // 
            this.permissionLabel.AutoSize = true;
            this.permissionLabel.Location = new System.Drawing.Point(10, 94);
            this.permissionLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.permissionLabel.Name = "permissionLabel";
            this.permissionLabel.Size = new System.Drawing.Size(131, 20);
            this.permissionLabel.TabIndex = 3;
            this.permissionLabel.Text = "permissionLabel";
            // 
            // 檔案ToolStripMenuItem
            // 
            this.檔案ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.登出ToolStripMenuItem,
            this.重新整理ToolStripMenuItem,
            this.結束ToolStripMenuItem});
            this.檔案ToolStripMenuItem.Name = "檔案ToolStripMenuItem";
            this.檔案ToolStripMenuItem.Size = new System.Drawing.Size(43, 19);
            this.檔案ToolStripMenuItem.Text = "檔案";
            // 
            // 登出ToolStripMenuItem
            // 
            this.登出ToolStripMenuItem.Name = "登出ToolStripMenuItem";
            this.登出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.登出ToolStripMenuItem.Text = "登出";
            this.登出ToolStripMenuItem.Click += new System.EventHandler(this.登出ToolStripMenuItem_Click);
            // 
            // 重新整理ToolStripMenuItem
            // 
            this.重新整理ToolStripMenuItem.Name = "重新整理ToolStripMenuItem";
            this.重新整理ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.重新整理ToolStripMenuItem.Text = "重新整理";
            // 
            // 結束ToolStripMenuItem
            // 
            this.結束ToolStripMenuItem.Name = "結束ToolStripMenuItem";
            this.結束ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.結束ToolStripMenuItem.Text = "結束";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 384);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.urlBox);
            this.Controls.Add(this.userBox);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainForm";
            this.Text = "夢想之都管理程式";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.userBox.ResumeLayout(false);
            this.userBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox userBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox urlBox;
        private System.Windows.Forms.GroupBox messageBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label permissionLabel;
        private System.Windows.Forms.Label departmentLabel;
        private System.Windows.Forms.ToolStripMenuItem 檔案ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 登出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重新整理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 結束ToolStripMenuItem;
    }
}