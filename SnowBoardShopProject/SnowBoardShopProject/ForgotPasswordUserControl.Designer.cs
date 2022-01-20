namespace SnowBoardShopProject
{
    partial class ForgotPasswordUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPasswordUserControl));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gmailLabel1 = new System.Windows.Forms.Label();
            this.getPaaawordbutton1 = new System.Windows.Forms.Button();
            this.gmailTextBox1 = new System.Windows.Forms.TextBox();
            this.UsernameTextBox2 = new System.Windows.Forms.TextBox();
            this.userNameLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(734, 508);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // gmailLabel1
            // 
            this.gmailLabel1.AutoSize = true;
            this.gmailLabel1.BackColor = System.Drawing.Color.GhostWhite;
            this.gmailLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gmailLabel1.Location = new System.Drawing.Point(43, 69);
            this.gmailLabel1.Name = "gmailLabel1";
            this.gmailLabel1.Size = new System.Drawing.Size(101, 25);
            this.gmailLabel1.TabIndex = 1;
            this.gmailLabel1.Text = "Your Gmail:";
            // 
            // getPaaawordbutton1
            // 
            this.getPaaawordbutton1.BackColor = System.Drawing.Color.GhostWhite;
            this.getPaaawordbutton1.FlatAppearance.BorderSize = 0;
            this.getPaaawordbutton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.getPaaawordbutton1.Location = new System.Drawing.Point(43, 116);
            this.getPaaawordbutton1.Name = "getPaaawordbutton1";
            this.getPaaawordbutton1.Size = new System.Drawing.Size(144, 34);
            this.getPaaawordbutton1.TabIndex = 4;
            this.getPaaawordbutton1.Text = "Get Password";
            this.getPaaawordbutton1.UseVisualStyleBackColor = false;
            this.getPaaawordbutton1.Click += new System.EventHandler(this.getPaaawordbutton1_Click);
            // 
            // gmailTextBox1
            // 
            this.gmailTextBox1.Location = new System.Drawing.Point(184, 63);
            this.gmailTextBox1.Name = "gmailTextBox1";
            this.gmailTextBox1.Size = new System.Drawing.Size(232, 31);
            this.gmailTextBox1.TabIndex = 5;
            // 
            // UsernameTextBox2
            // 
            this.UsernameTextBox2.Location = new System.Drawing.Point(184, 16);
            this.UsernameTextBox2.Name = "UsernameTextBox2";
            this.UsernameTextBox2.Size = new System.Drawing.Size(232, 31);
            this.UsernameTextBox2.TabIndex = 7;
            // 
            // userNameLabel1
            // 
            this.userNameLabel1.AutoSize = true;
            this.userNameLabel1.BackColor = System.Drawing.Color.GhostWhite;
            this.userNameLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userNameLabel1.Location = new System.Drawing.Point(43, 22);
            this.userNameLabel1.Name = "userNameLabel1";
            this.userNameLabel1.Size = new System.Drawing.Size(135, 25);
            this.userNameLabel1.TabIndex = 6;
            this.userNameLabel1.Text = "Your Username:";
            // 
            // ForgotPasswordUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UsernameTextBox2);
            this.Controls.Add(this.userNameLabel1);
            this.Controls.Add(this.gmailTextBox1);
            this.Controls.Add(this.getPaaawordbutton1);
            this.Controls.Add(this.gmailLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ForgotPasswordUserControl";
            this.Size = new System.Drawing.Size(734, 508);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label gmailLabel1;
        private System.Windows.Forms.Button getPaaawordbutton1;
        private System.Windows.Forms.TextBox gmailTextBox1;
        private System.Windows.Forms.TextBox UsernameTextBox2;
        private System.Windows.Forms.Label userNameLabel1;
    }
}
