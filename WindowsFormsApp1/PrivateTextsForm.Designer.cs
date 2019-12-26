using System;

namespace ClientGUI
{
    partial class PrivateTextsForm
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
            this.checkboxUsers = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sendTextBox = new System.Windows.Forms.TextBox();
            this.chatTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkboxUsers
            // 
            this.checkboxUsers.FormattingEnabled = true;
            this.checkboxUsers.Location = new System.Drawing.Point(12, 42);
            this.checkboxUsers.Name = "listUsers";
            this.checkboxUsers.Size = new System.Drawing.Size(154, 211);
            this.checkboxUsers.TabIndex = 0;
            //this.checkboxUsers.SelectedIndexChanged += new System.EventHandler(this.checkboxUsers_SelectedIndexChanged);
            this.checkboxUsers.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkboxUsers_ItemCheck);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select user:";
            // 
            // sendTextBox
            // 
            this.sendTextBox.Location = new System.Drawing.Point(214, 44);
            this.sendTextBox.Name = "sendTextBox";
            this.sendTextBox.Size = new System.Drawing.Size(240, 26);
            this.sendTextBox.TabIndex = 2;
            // 
            // chatTextBox
            // 
            this.chatTextBox.Location = new System.Drawing.Point(214, 101);
            this.chatTextBox.Multiline = true;
            this.chatTextBox.Name = "chatTextBox";
            this.chatTextBox.Size = new System.Drawing.Size(240, 154);
            this.chatTextBox.TabIndex = 3;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(469, 39);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(74, 36);
            this.sendButton.TabIndex = 4;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // PrivateTextsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 341);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.chatTextBox);
            this.Controls.Add(this.sendTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkboxUsers);
            this.Name = "PrivateTextsForm";
            this.Text = "PrivateTextsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkboxUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sendTextBox;
        private System.Windows.Forms.TextBox chatTextBox;
        private System.Windows.Forms.Button sendButton;
    }
}