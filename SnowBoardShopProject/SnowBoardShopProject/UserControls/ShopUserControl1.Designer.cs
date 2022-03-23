namespace SnowBoardShopProject
{
    partial class ShopUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShopUserControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.QuantitycomboBox1 = new System.Windows.Forms.ComboBox();
            this.Quantitylabel4 = new System.Windows.Forms.Label();
            this.ClientNametextBox1 = new System.Windows.Forms.TextBox();
            this.PricetextBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveOrderbutton1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBoards = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.QuantitycomboBox1);
            this.panel1.Controls.Add(this.Quantitylabel4);
            this.panel1.Controls.Add(this.ClientNametextBox1);
            this.panel1.Controls.Add(this.PricetextBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.SaveOrderbutton1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbBoards);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1671, 880);
            this.panel1.TabIndex = 26;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(1370, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(463, 841);
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(3, 447);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1361, 397);
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // QuantitycomboBox1
            // 
            this.QuantitycomboBox1.FormattingEnabled = true;
            this.QuantitycomboBox1.Items.AddRange(new object[] {
            "1",
            "2"});
            this.QuantitycomboBox1.Location = new System.Drawing.Point(200, 154);
            this.QuantitycomboBox1.Name = "QuantitycomboBox1";
            this.QuantitycomboBox1.Size = new System.Drawing.Size(312, 33);
            this.QuantitycomboBox1.TabIndex = 36;
            this.QuantitycomboBox1.SelectedIndexChanged += new System.EventHandler(this.QuantitycomboBox1_SelectedIndexChanged);
            // 
            // Quantitylabel4
            // 
            this.Quantitylabel4.AutoSize = true;
            this.Quantitylabel4.Location = new System.Drawing.Point(34, 162);
            this.Quantitylabel4.Name = "Quantitylabel4";
            this.Quantitylabel4.Size = new System.Drawing.Size(89, 25);
            this.Quantitylabel4.TabIndex = 35;
            this.Quantitylabel4.Text = "Quantity: ";
            // 
            // ClientNametextBox1
            // 
            this.ClientNametextBox1.Location = new System.Drawing.Point(200, 44);
            this.ClientNametextBox1.Name = "ClientNametextBox1";
            this.ClientNametextBox1.ReadOnly = true;
            this.ClientNametextBox1.Size = new System.Drawing.Size(312, 31);
            this.ClientNametextBox1.TabIndex = 34;
            // 
            // PricetextBox1
            // 
            this.PricetextBox1.Location = new System.Drawing.Point(200, 206);
            this.PricetextBox1.Name = "PricetextBox1";
            this.PricetextBox1.ReadOnly = true;
            this.PricetextBox1.Size = new System.Drawing.Size(312, 31);
            this.PricetextBox1.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 25);
            this.label1.TabIndex = 32;
            this.label1.Text = "Price: ";
            // 
            // SaveOrderbutton1
            // 
            this.SaveOrderbutton1.Location = new System.Drawing.Point(34, 337);
            this.SaveOrderbutton1.Margin = new System.Windows.Forms.Padding(4);
            this.SaveOrderbutton1.Name = "SaveOrderbutton1";
            this.SaveOrderbutton1.Size = new System.Drawing.Size(478, 82);
            this.SaveOrderbutton1.TabIndex = 30;
            this.SaveOrderbutton1.Text = "Buy";
            this.SaveOrderbutton1.UseVisualStyleBackColor = true;
            this.SaveOrderbutton1.Click += new System.EventHandler(this.SaveOrderbutton1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 103);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 25);
            this.label3.TabIndex = 28;
            this.label3.Text = "Board: ";
            // 
            // cmbBoards
            // 
            this.cmbBoards.FormattingEnabled = true;
            this.cmbBoards.Location = new System.Drawing.Point(200, 99);
            this.cmbBoards.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBoards.Name = "cmbBoards";
            this.cmbBoards.Size = new System.Drawing.Size(312, 33);
            this.cmbBoards.TabIndex = 27;
            this.cmbBoards.SelectedIndexChanged += new System.EventHandler(this.cmbBoards_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 25);
            this.label2.TabIndex = 26;
            this.label2.Text = "Client: ";
            // 
            // ShopUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.panel1);
            this.Name = "ShopUserControl";
            this.Size = new System.Drawing.Size(1671, 880);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox PricetextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveOrderbutton1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBoards;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ClientNametextBox1;
        private System.Windows.Forms.ComboBox QuantitycomboBox1;
        private System.Windows.Forms.Label Quantitylabel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
