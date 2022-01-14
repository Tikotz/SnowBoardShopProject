namespace SnowBoardShopProject
{
    partial class EditOrdersUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditOrdersUserControl));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Removebutton1 = new System.Windows.Forms.Button();
            this.OrderIdtextBox1 = new System.Windows.Forms.TextBox();
            this.OrderIdlabel1 = new System.Windows.Forms.Label();
            this.Editbutton1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1398, 675);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(631, 328);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(750, 322);
            this.dataGridView1.TabIndex = 1;
            // 
            // Removebutton1
            // 
            this.Removebutton1.Location = new System.Drawing.Point(248, 616);
            this.Removebutton1.Name = "Removebutton1";
            this.Removebutton1.Size = new System.Drawing.Size(139, 34);
            this.Removebutton1.TabIndex = 2;
            this.Removebutton1.Text = "Cencel Order";
            this.Removebutton1.UseVisualStyleBackColor = true;
            this.Removebutton1.Click += new System.EventHandler(this.Removebutton1_Click);
            // 
            // OrderIdtextBox1
            // 
            this.OrderIdtextBox1.Location = new System.Drawing.Point(475, 579);
            this.OrderIdtextBox1.Name = "OrderIdtextBox1";
            this.OrderIdtextBox1.Size = new System.Drawing.Size(150, 31);
            this.OrderIdtextBox1.TabIndex = 3;
            this.OrderIdtextBox1.Visible = false;
            // 
            // OrderIdlabel1
            // 
            this.OrderIdlabel1.AutoSize = true;
            this.OrderIdlabel1.Location = new System.Drawing.Point(248, 585);
            this.OrderIdlabel1.Name = "OrderIdlabel1";
            this.OrderIdlabel1.Size = new System.Drawing.Size(221, 25);
            this.OrderIdlabel1.TabIndex = 4;
            this.OrderIdlabel1.Text = "Enter the order ID here =>";
            this.OrderIdlabel1.Visible = false;
            // 
            // Editbutton1
            // 
            this.Editbutton1.Location = new System.Drawing.Point(428, 613);
            this.Editbutton1.Name = "Editbutton1";
            this.Editbutton1.Size = new System.Drawing.Size(149, 34);
            this.Editbutton1.TabIndex = 5;
            this.Editbutton1.Text = "Edit";
            this.Editbutton1.UseVisualStyleBackColor = true;
            this.Editbutton1.Click += new System.EventHandler(this.Editbutton1_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1398, 675);
            this.panel1.TabIndex = 6;
            // 
            // EditOrdersUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Editbutton1);
            this.Controls.Add(this.OrderIdlabel1);
            this.Controls.Add(this.OrderIdtextBox1);
            this.Controls.Add(this.Removebutton1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "EditOrdersUserControl";
            this.Size = new System.Drawing.Size(1398, 675);
            this.Load += new System.EventHandler(this.EditOrdersUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Removebutton1;
        private System.Windows.Forms.TextBox OrderIdtextBox1;
        private System.Windows.Forms.Label OrderIdlabel1;
        private System.Windows.Forms.Button Editbutton1;
        private System.Windows.Forms.Panel panel1;
    }
}
