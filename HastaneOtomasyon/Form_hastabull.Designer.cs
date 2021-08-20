namespace HastaneOtomasyon
{
    partial class Form_hastabull
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_hastabull));
            this.listView1 = new System.Windows.Forms.ListView();
            this.tc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.soyad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox1_araamaa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.Gray;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.tc,
            this.ad,
            this.soyad});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(75, 110);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(564, 367);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick_1);
            // 
            // tc
            // 
            this.tc.Text = "TC";
            this.tc.Width = 153;
            // 
            // ad
            // 
            this.ad.Text = "ADI";
            this.ad.Width = 117;
            // 
            // soyad
            // 
            this.soyad.Text = "SOYADI";
            this.soyad.Width = 96;
            // 
            // textBox1_araamaa
            // 
            this.textBox1_araamaa.Location = new System.Drawing.Point(179, 64);
            this.textBox1_araamaa.Name = "textBox1_araamaa";
            this.textBox1_araamaa.Size = new System.Drawing.Size(149, 22);
            this.textBox1_araamaa.TabIndex = 1;
            this.textBox1_araamaa.TextChanged += new System.EventHandler(this.textBox1_araamaa_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(75, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hasta Ara";
            // 
            // Form_hastabull
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(724, 470);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1_araamaa);
            this.Controls.Add(this.listView1);
            this.Name = "Form_hastabull";
            this.Text = "Hasta Bul";
            this.Load += new System.EventHandler(this.Form_hastabull_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader tc;
        private System.Windows.Forms.ColumnHeader ad;
        private System.Windows.Forms.ColumnHeader soyad;
        private System.Windows.Forms.TextBox textBox1_araamaa;
        private System.Windows.Forms.Label label1;
    }
}