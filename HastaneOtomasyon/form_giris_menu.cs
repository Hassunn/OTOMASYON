using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HastaneOtomasyon
{
    public partial class form_giris_menu : Form
    {
        public form_giris_menu()
        {
            InitializeComponent();
        }

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2_randevu_al al = new Form2_randevu_al();
            Form3_randevu_sil sil = new Form3_randevu_sil();
            Form5_hasta_ekle ek = new Form5_hasta_ekle();
            Form_hastabull bul = new Form_hastabull();
            form_hstalar hs = new form_hstalar();
            form_rndgecmisi gc = new form_rndgecmisi();
            al.Close();
            sil.Close();
            ek.Close();
            bul.Close();
            hs.Close();
            gc.Close();
        }
        private void randevuAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void randevuSilToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

       


        private void sekreterGirişiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        Form2_randevu_al randevu_al;

        private void randevuSilToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (randevu_al == null || randevu_al.IsDisposed)
            {
                randevu_al = new Form2_randevu_al();
                randevu_al.MdiParent = this;
                randevu_al.Show();
            }
            else
            {
                MessageBox.Show("Şuan Zaten Randevu Al Menüsü Açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        Form5_hasta_ekle hstekle;
        private void hastaEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(hstekle==null || hstekle.IsDisposed)
            {
                hstekle = new Form5_hasta_ekle();
                hstekle.MdiParent = this;
                hstekle.Show();
              
            }
            else
            {
                MessageBox.Show("Şuan Zaten Hasta Ekle Menüsü Açık","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
       
       
        Form3_randevu_sil sil;
        private void randevuSilToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if(sil==null||sil.IsDisposed)
            {
                sil = new Form3_randevu_sil();
                sil.MdiParent = this;
                sil.Show(); 
            }
            else
            {
                MessageBox.Show("Şuan Zaten Randevu Sil Menüsü Açık Tekrar Açılamaz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        form_hstalar hastalar;
        private void hastalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hastalar==null||hastalar.IsDisposed)
            {
                hastalar = new form_hstalar();
                hastalar.MdiParent = this;
                hastalar.Show();
            }
            else
            {
                
                MessageBox.Show("Şuan Zaten Hastalar Menüsü Açık Tekrar Açılamaz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            

        }
        form_rndgecmisi rndgeci;
        private void randevuGeçmişiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rndgeci == null || rndgeci.IsDisposed)
            {
                rndgeci = new form_rndgecmisi();
                rndgeci.MdiParent = this;
                rndgeci.Show();
            }
            else
            {
                MessageBox.Show("Şuan zaten randevu geçmişi menüsü açık tekra açılamaz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
       
        form_doktorlar doktorlar;
        public static Point  boyut;
        private void doktorEkleDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (doktorlar == null || doktorlar.IsDisposed)
            {
                doktorlar = new form_doktorlar();
                doktorlar.MdiParent = this;
                doktorlar.Size = new Size(1086, 600);
                
                doktorlar.Show();
            }
            else
            {
                MessageBox.Show("Şuan zaten randevu geçmişi menüsü açık tekra açılamaz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void form_giris_menu_Load(object sender, EventArgs e)
        {
            string hsn = Form1_giris.seviye;
            if (hsn == "admin")
            {
                hastalarToolStripMenuItem.Visible = false;

                hastaEkleToolStripMenuItem.Visible = false;
                randevuGeçmişiToolStripMenuItem.Visible = false;
                randevuAlToolStripMenuItem.Visible = false;
                randevularımToolStripMenuItem.Visible = false;

            }
            else if (hsn == "sekreter")
            {
                
                randevularımToolStripMenuItem.Visible = false;
                personelekleToolStripMenuItem.Visible = false;
            }
            else
            {


                doktorlarToolStripMenuItem.Visible = false;
                randevuAlToolStripMenuItem.Visible = false;
                personelekleToolStripMenuItem.Visible = false;
                hastaEkleToolStripMenuItem.Visible = false;
            }
            
            toolStripTextBox1.Text = Form1_giris.isim;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        randevularım randevu;
        private void randevularımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (randevu == null || randevu.IsDisposed)
            {
                randevu = new randevularım();
                randevu.MdiParent = this;

                randevu.Show();
            }
            else
            {
                MessageBox.Show("Şuan zaten randevular menüsü açık tekrar açılamaz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }
        personel_ekle per;
            private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (per == null || randevu.IsDisposed)
            {
                per = new personel_ekle();
                per.MdiParent = this;

                per.Show();
            }
            else
            {
                MessageBox.Show("Şuan zaten personel ekle  menüsü açık tekra açılamaz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
