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
    public partial class Form1_giris : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source =DESKTOP-JID65J8\\SQLEXPRESS; Initial Catalog=hastaneotomasyonu;Integrated Security = True ");


        public Form1_giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_kullanici_adi_TextChanged(object sender, EventArgs e)
        {

        }
        public static string seviye = "";
        public static string isim = "";
        public static string doktor = "";
        private void button1_giris_Click(object sender, EventArgs e)
        {
            if (textBox1_kullanici_adi.Text.Trim() == "")
            {
                MessageBox.Show("kullanıcı adı boş bırakılamaz");
            }
            else if (textBox2_sifre.Text.Trim() == "")
            {
                MessageBox.Show("sifre boş bırakılamaz");

            }
            else
            {
                baglanti.Open();
                SqlCommand kmt = new SqlCommand("SELECT * FROM kullanicilar where kullanici_adi=@kadi and kullanici_sifre=@sifre and seviye='admin'", baglanti);
                kmt.Parameters.AddWithValue("@kadi", textBox1_kullanici_adi.Text);
                kmt.Parameters.AddWithValue("@sifre", textBox2_sifre.Text);

                SqlDataReader dr = kmt.ExecuteReader();


                if (dr.Read())
                {
                    label3.Text = "";
                    seviye = "admin";
                    form_giris_menu giris = new form_giris_menu();
                    isim = textBox1_kullanici_adi.Text.ToString() + "-YETKİ(Admin)";

                    giris.Show();
                    this.Hide();

                }
                else
                {
                    label3.Text = "Hatalı Giriş Yaptınız";
                    label3.Show();
                }

                baglanti.Close();
                dr.Close();



                baglanti.Open();
                SqlCommand kmtt = new SqlCommand("SELECT * FROM kullanicilar where kullanici_adi=@kadi and kullanici_sifre=@sifre and seviye='sekreter'", baglanti);
                kmtt.Parameters.AddWithValue("@kadi", textBox1_kullanici_adi.Text);
                kmtt.Parameters.AddWithValue("@sifre", textBox2_sifre.Text);

                SqlDataReader drr = kmtt.ExecuteReader();



                if (drr.Read())
                {
                    label3.Text = "";
                    seviye = "sekreter";
                    isim = textBox1_kullanici_adi.Text.ToString() + "-YETKİ(Sekreter)";
                    //isim = textBox1_kullanici_adi.Text.ToString();
                    form_giris_menu giris = new form_giris_menu();
                    giris.Show();


                    this.Hide();


                }
                else
                {
                    label3.Text = "Hatalı Giriş Yaptınız";
                    label3.Show();
                }



                baglanti.Close();
                drr.Close();



                baglanti.Open();
                SqlCommand kmttt = new SqlCommand("SELECT * FROM kullanicilar where kullanici_adi=@kadi and kullanici_sifre=@sifre and seviye='doktor'", baglanti);
                kmttt.Parameters.AddWithValue("@kadi", textBox1_kullanici_adi.Text);
                kmttt.Parameters.AddWithValue("@sifre", textBox2_sifre.Text);

                SqlDataReader drrr = kmttt.ExecuteReader();



                if (drrr.Read())
                {
                    label3.Text = "";
                    isim = textBox1_kullanici_adi.Text.ToString() + "-YETKİ(Doktor)";
                    doktor = textBox1_kullanici_adi.Text.ToString();
                    //isim = textBox1_kullanici_adi.Text.ToString();
                    form_giris_menu giris = new form_giris_menu();
                    giris.Show();

                    this.Hide();


                }
                else
                {
                    label3.Text = "Hatalı Giriş Yaptınız";
                    label3.Show();
                }



                baglanti.Close();
                drrr.Close();



            }
        }

        private void Form1_giris_Load(object sender, EventArgs e)
        {

        }

        private void button1_giris_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (textBox1_kullanici_adi.Text.Trim() == "")
                {
                    MessageBox.Show("kullanıcı adı boş bırakılamaz");
                }
                else if (textBox2_sifre.Text.Trim() == "")
                {
                    MessageBox.Show("sifre boş bırakılamaz");

                }
                else
                {
                    baglanti.Open();
                    SqlCommand kmt = new SqlCommand("SELECT * FROM kullanicilar where kullanici_adi=@kadi and kullanici_sifre=@sifre and seviye='admin'", baglanti);
                    kmt.Parameters.AddWithValue("@kadi", textBox1_kullanici_adi.Text);
                    kmt.Parameters.AddWithValue("@sifre", textBox2_sifre.Text);

                    SqlDataReader dr = kmt.ExecuteReader();


                    if (dr.Read())
                    {
                        label3.Text = "";
                        seviye = "admin";
                        form_giris_menu giris = new form_giris_menu();
                        isim = textBox1_kullanici_adi.Text.ToString() + "-YETKİ(Admin)";

                        giris.Show();
                        this.Hide();

                    }
                    else
                    {
                        label3.Text = "Hatalı Giriş Yaptınız";
                        label3.Show();
                    }

                    baglanti.Close();
                    dr.Close();



                    baglanti.Open();
                    SqlCommand kmtt = new SqlCommand("SELECT * FROM kullanicilar where kullanici_adi=@kadi and kullanici_sifre=@sifre and seviye='sekreter'", baglanti);
                    kmtt.Parameters.AddWithValue("@kadi", textBox1_kullanici_adi.Text);
                    kmtt.Parameters.AddWithValue("@sifre", textBox2_sifre.Text);

                    SqlDataReader drr = kmtt.ExecuteReader();



                    if (drr.Read())
                    {
                        label3.Text = "";
                        seviye = "sekreter";
                        isim = textBox1_kullanici_adi.Text.ToString() + "-YETKİ(Sekreter)";
                        //isim = textBox1_kullanici_adi.Text.ToString();
                        form_giris_menu giris = new form_giris_menu();
                        giris.Show();


                        this.Hide();


                    }
                    else
                    {
                        label3.Text = "Hatalı Giriş Yaptınız";
                        label3.Show();
                    }



                    baglanti.Close();
                    drr.Close();



                    baglanti.Open();
                    SqlCommand kmttt = new SqlCommand("SELECT * FROM kullanicilar where kullanici_adi=@kadi and kullanici_sifre=@sifre and seviye='doktor'", baglanti);
                    kmttt.Parameters.AddWithValue("@kadi", textBox1_kullanici_adi.Text);
                    kmttt.Parameters.AddWithValue("@sifre", textBox2_sifre.Text);

                    SqlDataReader drrr = kmttt.ExecuteReader();



                    if (drrr.Read())
                    {
                        label3.Text = "";
                        isim = textBox1_kullanici_adi.Text.ToString() + "-YETKİ(Doktor)";
                        doktor = textBox1_kullanici_adi.Text.ToString();
                        //isim = textBox1_kullanici_adi.Text.ToString();
                        form_giris_menu giris = new form_giris_menu();
                        giris.Show();

                        this.Hide();


                    }
                    else
                    {
                        label3.Text = "Hatalı Giriş Yaptınız";
                        label3.Show();
                    }



                    baglanti.Close();
                    drrr.Close();

                }
            }
        }
    }
}
