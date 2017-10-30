namespace GCC_App
{
    partial class AdminForm
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
            this.addUserBtn = new System.Windows.Forms.Button();
            this.remUserBtn = new System.Windows.Forms.Button();
            this.pNameText = new System.Windows.Forms.TextBox();
            this.pinText = new System.Windows.Forms.TextBox();
            this.cNameText = new System.Windows.Forms.TextBox();
            this.pNameLbl = new System.Windows.Forms.Label();
            this.pinLabel = new System.Windows.Forms.Label();
            this.cNameLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addUserBtn
            // 
            this.addUserBtn.Location = new System.Drawing.Point(135, 258);
            this.addUserBtn.Name = "addUserBtn";
            this.addUserBtn.Size = new System.Drawing.Size(75, 23);
            this.addUserBtn.TabIndex = 0;
            this.addUserBtn.Text = "Add Parent";
            this.addUserBtn.UseVisualStyleBackColor = true;
            this.addUserBtn.Click += new System.EventHandler(this.addUserBtn_Click);
            // 
            // remUserBtn
            // 
            this.remUserBtn.Location = new System.Drawing.Point(12, 258);
            this.remUserBtn.Name = "remUserBtn";
            this.remUserBtn.Size = new System.Drawing.Size(75, 23);
            this.remUserBtn.TabIndex = 1;
            this.remUserBtn.Text = "Remove Parent";
            this.remUserBtn.UseVisualStyleBackColor = true;
            this.remUserBtn.Click += new System.EventHandler(this.remUserBtn_Click);
            // 
            // pNameText
            // 
            this.pNameText.Location = new System.Drawing.Point(15, 25);
            this.pNameText.Name = "pNameText";
            this.pNameText.Size = new System.Drawing.Size(195, 20);
            this.pNameText.TabIndex = 3;
            // 
            // pinText
            // 
            this.pinText.Location = new System.Drawing.Point(15, 85);
            this.pinText.Name = "pinText";
            this.pinText.Size = new System.Drawing.Size(195, 20);
            this.pinText.TabIndex = 4;
            this.pinText.UseSystemPasswordChar = true;
            // 
            // cNameText
            // 
            this.cNameText.Location = new System.Drawing.Point(15, 150);
            this.cNameText.Multiline = true;
            this.cNameText.Name = "cNameText";
            this.cNameText.Size = new System.Drawing.Size(195, 102);
            this.cNameText.TabIndex = 5;
            // 
            // pNameLbl
            // 
            this.pNameLbl.AutoSize = true;
            this.pNameLbl.Location = new System.Drawing.Point(12, 9);
            this.pNameLbl.Name = "pNameLbl";
            this.pNameLbl.Size = new System.Drawing.Size(69, 13);
            this.pNameLbl.TabIndex = 6;
            this.pNameLbl.Text = "Parent Name";
            // 
            // pinLabel
            // 
            this.pinLabel.AutoSize = true;
            this.pinLabel.Location = new System.Drawing.Point(15, 69);
            this.pinLabel.Name = "pinLabel";
            this.pinLabel.Size = new System.Drawing.Size(22, 13);
            this.pinLabel.TabIndex = 7;
            this.pinLabel.Text = "Pin";
            // 
            // cNameLbl
            // 
            this.cNameLbl.AutoSize = true;
            this.cNameLbl.Location = new System.Drawing.Point(15, 134);
            this.cNameLbl.Name = "cNameLbl";
            this.cNameLbl.Size = new System.Drawing.Size(111, 13);
            this.cNameLbl.TabIndex = 8;
            this.cNameLbl.Text = "Children (One per line)";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 302);
            this.Controls.Add(this.cNameLbl);
            this.Controls.Add(this.pinLabel);
            this.Controls.Add(this.pNameLbl);
            this.Controls.Add(this.cNameText);
            this.Controls.Add(this.pinText);
            this.Controls.Add(this.pNameText);
            this.Controls.Add(this.remUserBtn);
            this.Controls.Add(this.addUserBtn);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addUserBtn;
        private System.Windows.Forms.Button remUserBtn;
        private System.Windows.Forms.TextBox pNameText;
        private System.Windows.Forms.TextBox pinText;
        private System.Windows.Forms.TextBox cNameText;
        private System.Windows.Forms.Label pNameLbl;
        private System.Windows.Forms.Label pinLabel;
        private System.Windows.Forms.Label cNameLbl;
    }
}