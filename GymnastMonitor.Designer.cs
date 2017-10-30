namespace GCC_App
{
    partial class GymnastMonitor
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
            this.lbl_hello = new System.Windows.Forms.Label();
            this.gymnastList = new System.Windows.Forms.ListBox();
            this.dropOffBtn = new System.Windows.Forms.Button();
            this.pickUpBtn = new System.Windows.Forms.Button();
            this.newChildTextBox = new System.Windows.Forms.TextBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_hello
            // 
            this.lbl_hello.AutoSize = true;
            this.lbl_hello.Location = new System.Drawing.Point(12, 9);
            this.lbl_hello.Name = "lbl_hello";
            this.lbl_hello.Size = new System.Drawing.Size(0, 13);
            this.lbl_hello.TabIndex = 0;
            // 
            // gymnastList
            // 
            this.gymnastList.FormattingEnabled = true;
            this.gymnastList.Location = new System.Drawing.Point(12, 88);
            this.gymnastList.Name = "gymnastList";
            this.gymnastList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.gymnastList.Size = new System.Drawing.Size(300, 264);
            this.gymnastList.TabIndex = 1;
            // 
            // dropOffBtn
            // 
            this.dropOffBtn.Location = new System.Drawing.Point(318, 300);
            this.dropOffBtn.Name = "dropOffBtn";
            this.dropOffBtn.Size = new System.Drawing.Size(75, 23);
            this.dropOffBtn.TabIndex = 2;
            this.dropOffBtn.Text = "Drop Off";
            this.dropOffBtn.UseVisualStyleBackColor = true;
            this.dropOffBtn.Click += new System.EventHandler(this.dropOffBtn_Click);
            // 
            // pickUpBtn
            // 
            this.pickUpBtn.Location = new System.Drawing.Point(318, 329);
            this.pickUpBtn.Name = "pickUpBtn";
            this.pickUpBtn.Size = new System.Drawing.Size(75, 23);
            this.pickUpBtn.TabIndex = 3;
            this.pickUpBtn.Text = "Pick Up";
            this.pickUpBtn.UseVisualStyleBackColor = true;
            this.pickUpBtn.Click += new System.EventHandler(this.pickUpBtn_Click);
            // 
            // newChildTextBox
            // 
            this.newChildTextBox.Location = new System.Drawing.Point(12, 62);
            this.newChildTextBox.Name = "newChildTextBox";
            this.newChildTextBox.Size = new System.Drawing.Size(300, 20);
            this.newChildTextBox.TabIndex = 4;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(318, 59);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 5;
            this.addBtn.Text = "Add Child";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // GymnastMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 372);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.newChildTextBox);
            this.Controls.Add(this.pickUpBtn);
            this.Controls.Add(this.dropOffBtn);
            this.Controls.Add(this.gymnastList);
            this.Controls.Add(this.lbl_hello);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GymnastMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GCC Gymnast Monitor";
            this.Load += new System.EventHandler(this.GymnastMonitor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_hello;
        private System.Windows.Forms.ListBox gymnastList;
        private System.Windows.Forms.Button dropOffBtn;
        private System.Windows.Forms.Button pickUpBtn;
        private System.Windows.Forms.TextBox newChildTextBox;
        private System.Windows.Forms.Button addBtn;
    }
}