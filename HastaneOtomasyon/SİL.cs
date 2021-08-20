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
    public partial class personel_ekle : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source =DESKTOP-JID65J8\\SQLEXPRESS; Initial Catalog=hastaneotomasyonu;Integrated Security = True ");

        public personel_ekle()
        {
            InitializeComponent();
        }
        private void bosalt()
        {
            label5_uyarii.Text = "";
            label5_uyarii.Show();
            textBox3_tcc.Text = "";
            textBox2_soyadiii.Text = "";
            textBox1_adi.Text = "";
            textBox1_sıfre.Text = "";
            textBox1_sıfre.Text = "";
        }
        private void goster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand kntrol = new SqlCommand("SELECT * FROM sekreter", baglanti);
            SqlDataReader gor = kntrol.ExecuteReader();
            while (gor.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = gor["id"].ToString();
                ekle.SubItems.Add(gor["sek_tc"].ToString());
                ekle.SubItems.Add(gor["sek_ad"].ToString());
                ekle.SubItems.Add(gor["sek_soyad"].ToString());


                listView1.Items.Add(ekle);
            }
            listView1.GridLines = true;
            baglanti.Close();
        }

        private void SİL_Load(object sender, EventArgs e)
        {
            goster();
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1_adi.Text.Trim() == "" || textBox2_soyadiii.Text.Trim() == "" || textBox3_tcc.Text.Trim() == "")//texboxlaın boşluğunu kontol ettik aynı zamanda boşluklaı trim ile sildik
            {
                label5_uyarii.Text = "Lütfen Zorunlu Alanları Doldurunuz";
                label5_uyarii.Show();

            }
            else if (textBox3_tcc.TextLength < 10)
            {
                label5.Text = "Lütfen Geçerli Bir TC Giriniz";
                label5_uyarii.Show();
            }
            else
            {
                int kont = 0;
                int sonuc = 0;
                try
                {
                    baglanti.Open();

                    SqlCommand kntrol = new SqlCommand("SELECT sek_tc FROM sekreter", baglanti);
                    SqlDataReader gor = kntrol.ExecuteReader();

                    while (gor.Read())
                    {

                        if (gor["sek_tc"].ToString().TrimEnd() != textBox3_tcc.ToString().TrimEnd())
                        {
                            sonuc = 1;
                        }

                    }
                    gor.Close();

                    if (sonuc == 1)
                    {
                        SqlCommand kontrol2 = new SqlCommand("Insert into sekreter(sek_tc,sek_ad,sek_soyad)Values(@tcc,@adii,@soyadii)", baglanti);
                        kontrol2.Parameters.AddWithValue("@tcc", textBox3_tcc.Text.ToString());
                        kontrol2.Parameters.AddWithValue("@adii", textBox1_adi.Text.ToString());
                        kontrol2.Parameters.AddWithValue("@soyadii", textBox2_soyadiii.Text.ToString());

                        kontrol2.ExecuteNonQuery();
                     
                    }
                    else
                    {
                        DialogResult mesaj;
                        mesaj = MessageBox.Show("BU TC ZATEN  KAYITLI", "UYARI", MessageBoxButtons.OK);
                    }


                    SqlCommand kntrol3 = new SqlCommand("SELECT * FROM kullanicilar", baglanti);
                    SqlDataReader gor1 = kntrol3.ExecuteReader();
                    while (gor1.Read())
                    {
                        if (gor1["kullanici_adi"].ToString().TrimEnd() != textBox3_tcc.ToString().TrimEnd())
                        {
                            kont = 1;
                        }

                    }
                    gor1.Close();
                    if (kont == 1)
                    {
                        SqlCommand kontrol1 = new SqlCommand("Insert into kullanicilar(kullanici_adi,kullanici_sifre,seviye)Values(@kadi,@sifre,@seviye)", baglanti);
                        kontrol1.Parameters.AddWithValue("@kadi", textBox3_tcc.Text.ToString());
                        kontrol1.Parameters.AddWithValue("@sifre", textBox1_sıfre.Text.ToString().TrimEnd());
                        kontrol1.Parameters.AddWithValue("@seviye", "sekreter");

                        kontrol1.ExecuteNonQuery();
              
                    }


                    baglanti.Close();
                    bosalt();
                    goster();

                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("DELETE FROM sekreter WHERE id=@id", baglanti);

            sil.Parameters.AddWithValue("@id", label5.Text.ToString());
            sil.ExecuteNonQuery();
            baglanti.Close();
            bosalt();
            goster();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("UPDATE sekreter SET sek_tc=@tc,sek_ad=@adi,sek_soyad=@soyad  WHERE id=@id", baglanti);

            guncelle.Parameters.AddWithValue("@tc", textBox3_tcc.Text.ToString());
            guncelle.Parameters.AddWithValue("@adi", textBox1_adi.Text.ToString());
            guncelle.Parameters.AddWithValue("@soyad", textBox2_soyadiii.Text.ToString());

            guncelle.Parameters.AddWithValue("@id", Convert.ToInt32(label5.Text.ToString()));
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Başarıyla Güncelleme Yaptınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SqlCommand kontrol1 = new SqlCommand("UPDATE kullanicilar SET kullanici_sifre=@sifre  WHERE kullanici_adi=@tckont", baglanti);
            kontrol1.Parameters.AddWithValue("@sifre", textBox1_sıfre.Text.ToString().TrimEnd());
            kontrol1.Parameters.AddWithValue("@tckont", textBox3_tcc.Text.ToString().TrimEnd());
            kontrol1.ExecuteNonQuery();
            baglanti.Close();
            bosalt();
            goster();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            label5.Text = listView1.SelectedItems[0].SubItems[0].Text.ToString();
            textBox3_tcc.Text = listView1.SelectedItems[0].SubItems[1].Text.ToString();
            textBox1_adi.Text = listView1.SelectedItems[0].SubItems[2].Text.ToString();
            textBox2_soyadiii.Text = listView1.SelectedItems[0].SubItems[3].Text.ToString();
           
        }
    }
}
