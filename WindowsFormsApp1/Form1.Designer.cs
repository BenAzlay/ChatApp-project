namespace ClientGUI
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
            this.SignUpButton = new System.Windows.Forms.Button();
            this.connectionLabel = new System.Windows.Forms.Label();
            this.newMessageTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.chatTextBox = new System.Windows.Forms.TextBox();
            this.newTopicButton = new System.Windows.Forms.Button();
            this.topicLabel = new System.Windows.Forms.Label();
            this.signInButton = new System.Windows.Forms.Button();
            this.listTopicsTextBox = new System.Windows.Forms.Label();
            this.privateTextsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SignUpButton
            // 
            this.SignUpButton.Location = new System.Drawing.Point(16, 16);
            this.SignUpButton.Name = "SignUpButton";
            this.SignUpButton.Size = new System.Drawing.Size(88, 47);
            this.SignUpButton.TabIndex = 3;
            this.SignUpButton.Text = "Sign Up";
            this.SignUpButton.UseVisualStyleBackColor = true;
            this.SignUpButton.Click += new System.EventHandler(this.signUp_Click);
            // 
            // connectionLabel
            // 
            this.connectionLabel.AutoSize = true;
            this.connectionLabel.Location = new System.Drawing.Point(240, 16);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(113, 20);
            this.connectionLabel.TabIndex = 4;
            this.connectionLabel.Text = "Not connected";
            // 
            // newMessageTextBox
            // 
            this.newMessageTextBox.Location = new System.Drawing.Point(416, 10);
            this.newMessageTextBox.Multiline = true;
            this.newMessageTextBox.Name = "newMessageTextBox";
            this.newMessageTextBox.Size = new System.Drawing.Size(240, 53);
            this.newMessageTextBox.TabIndex = 5;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(680, 10);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(74, 31);
            this.sendButton.TabIndex = 7;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.send_Click);
            // 
            // chatTextBox
            // 
            this.chatTextBox.Location = new System.Drawing.Point(416, 83);
            this.chatTextBox.Multiline = true;
            this.chatTextBox.Name = "chatTextBox";
            this.chatTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatTextBox.Size = new System.Drawing.Size(240, 141);
            this.chatTextBox.TabIndex = 8;
            // 
            // newTopicButton
            // 
            this.newTopicButton.Location = new System.Drawing.Point(16, 83);
            this.newTopicButton.Name = "newTopicButton";
            this.newTopicButton.Size = new System.Drawing.Size(141, 47);
            this.newTopicButton.TabIndex = 9;
            this.newTopicButton.Text = "Create/join topic";
            this.newTopicButton.UseVisualStyleBackColor = true;
            this.newTopicButton.Click += new System.EventHandler(this.newTopic_Click);
            // 
            // topicLabel
            // 
            this.topicLabel.AutoSize = true;
            this.topicLabel.Location = new System.Drawing.Point(240, 83);
            this.topicLabel.Name = "topicLabel";
            this.topicLabel.Size = new System.Drawing.Size(131, 20);
            this.topicLabel.TabIndex = 10;
            this.topicLabel.Text = "No topic selected";
            // 
            // signInButton
            // 
            this.signInButton.Location = new System.Drawing.Point(123, 16);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(88, 47);
            this.signInButton.TabIndex = 11;
            this.signInButton.Text = "Sign In";
            this.signInButton.UseVisualStyleBackColor = true;
            this.signInButton.Click += new System.EventHandler(this.signIn_Click);
            // 
            // listTopicsTextBox
            // 
            this.listTopicsTextBox.AutoSize = true;
            this.listTopicsTextBox.Location = new System.Drawing.Point(29, 164);
            this.listTopicsTextBox.Name = "listTopicsTextBox";
            this.listTopicsTextBox.Size = new System.Drawing.Size(102, 20);
            this.listTopicsTextBox.TabIndex = 12;
            this.listTopicsTextBox.Text = "List of topics:";
            // 
            // privateTextsButton
            // 
            this.privateTextsButton.Location = new System.Drawing.Point(416, 243);
            this.privateTextsButton.Name = "privateTextsButton";
            this.privateTextsButton.Size = new System.Drawing.Size(158, 36);
            this.privateTextsButton.TabIndex = 13;
            this.privateTextsButton.Text = "Private messages";
            this.privateTextsButton.UseVisualStyleBackColor = true;
            this.privateTextsButton.Click += new System.EventHandler(this.privateTextsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 329);
            this.Controls.Add(this.privateTextsButton);
            this.Controls.Add(this.listTopicsTextBox);
            this.Controls.Add(this.signInButton);
            this.Controls.Add(this.topicLabel);
            this.Controls.Add(this.newTopicButton);
            this.Controls.Add(this.chatTextBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.newMessageTextBox);
            this.Controls.Add(this.connectionLabel);
            this.Controls.Add(this.SignUpButton);
            this.Name = "Form1";
            this.Text = "Form1";
            //this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SignUpButton;
        private System.Windows.Forms.Label connectionLabel;
        private System.Windows.Forms.TextBox newMessageTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox chatTextBox;
        private System.Windows.Forms.Button newTopicButton;
        private System.Windows.Forms.Label topicLabel;
        private System.Windows.Forms.Button signInButton;
        private System.Windows.Forms.Label listTopicsTextBox;
        private System.Windows.Forms.Button privateTextsButton;
    }
}

