namespace HastaneOtomasyon
{
    partial class Form1_giris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1_giris));
            this.textBox1_kullanici_adi = new System.Windows.Forms.TextBox();
            this.textBox2_sifre = new System.Windows.Forms.TextBox();
            this.button1_giris = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1_kullanici_adi
            // 
            this.textBox1_kullanici_adi.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1_kullanici_adi.Location = new System.Drawing.Point(186, 80);
            this.textBox1_kullanici_adi.MaxLength = 11;
            this.textBox1_kullanici_adi.Name = "textBox1_kullanici_adi";
            this.textBox1_kullanici_adi.Size = new System.Drawing.Size(176, 34);
            this.textBox1_kullanici_adi.TabIndex = 0;
            this.textBox1_kullanici_adi.TextChanged += new System.EventHandler(this.textBox1_kullanici_adi_TextChanged);
            // 
            // textBox2_sifre
            // 
            this.textBox2_sifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox2_sifre.Location = new System.Drawing.Point(186, 165);
            this.textBox2_sifre.MaxLength = 8;
            this.textBox2_sifre.Name = "textBox2_sifre";
            this.textBox2_sifre.PasswordChar = '*';
            this.textBox2_sifre.Size = new System.Drawing.Size(176, 34);
            this.textBox2_sifre.TabIndex = 1;
            // 
            // button1_giris
            // 
            this.button1_giris.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1_giris.Location = new System.Drawing.Point(216, 253);
            this.button1_giris.Name = "button1_giris";
            this.button1_giris.Size = new System.Drawing.Size(146, 60);
            this.button1_giris.TabIndex = 4;
            this.button1_giris.Text = "Giriş";
            this.button1_giris.UseVisualStyleBackColor = true;
            this.button1_giris.Click += new System.EventHandler(this.button1_giris_Click);
            this.button1_giris.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.button1_giris_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(123, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 38);
            this.label3.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(63, 64);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(63, 149);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // Form1_giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(569, 385);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1_giris);
            this.Controls.Add(this.textBox2_sifre);
            this.Controls.Add(this.textBox1_kullanici_adi);
            this.Name = "Form1_giris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hastane Randevu Otomasyonu";
            this.Load += new System.EventHandler(this.Form1_giris_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1_kullanici_adi;
        private System.Windows.Forms.TextBox textBox2_sifre;
        private System.Windows.Forms.Button button1_giris;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

