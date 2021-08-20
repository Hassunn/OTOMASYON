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
    public partial class form_doktorlar : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source =DESKTOP-JID65J8\\SQLEXPRESS; Initial Catalog=hastaneotomasyonu;Integrated Security = True ");

        public form_doktorlar()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void form_doktorlar_Load(object sender, EventArgs e)
        {
            
            goster();
         }
        private void goster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand kntrol = new SqlCommand("SELECT * FROM doktorlar", baglanti);
            SqlDataReader gor = kntrol.ExecuteReader();
            while (gor.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = gor["doktor_id"].ToString();
                ekle.SubItems.Add(gor["doktor_tc"].ToString());
                ekle.SubItems.Add(gor["doktor_adi"].ToString());
                ekle.SubItems.Add(gor["doktor_soyadi"].ToString());
                ekle.SubItems.Add(gor["doktor_unvan"].ToString());
                listView1.Items.Add(ekle);
            }
            listView1.GridLines = true;
            baglanti.Close();
        }
        private void bosalt()
        {
            label5_uyarii.Text = "";
            label5_uyarii.Show();
            textBox3_tcc.Text = "";
            textBox2_soyadiii.Text = "";
            textBox1_adi.Text = "";
            comboBox1_unvan.Text = "";
            textBox1_sıfre.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1_adi.Text.Trim() == "" || textBox2_soyadiii.Text.Trim() == "" || textBox3_tcc.Text.Trim() == "" || comboBox1_unvan.Text.Trim() == "")//texboxlaın boşluğunu kontol ettik aynı zamanda boşluklaı trim ile sildik
            {
                label5_uyarii.Text = "Lütfen Zorunlu Alanları Doldurunuz";
                label5_uyarii.Show();

            }
            else if (textBox3_tcc.TextLength < 10)
            {
                label5_uyarii.Text = "Lütfen Geçerli Bir TC Giriniz";
                label5_uyarii.Show();
            }
            else
            {
                int kont = 0;
                int sonuc=0;
                try
                {
                    baglanti.Open();

                    SqlCommand kntrol = new SqlCommand("SELECT * FROM doktorlar", baglanti);
                    SqlDataReader gor = kntrol.ExecuteReader();
                    
                    while (gor.Read())
                    {
                      
                        if (gor["doktor_tc"].ToString().TrimEnd() != textBox3_tcc.ToString().TrimEnd())
                        {
                            sonuc = 1;
                        }
    
                    }
                    gor.Close();
                    
                    if(sonuc == 1)
                    {
                        SqlCommand kontrol2 = new SqlCommand("Insert into doktorlar(doktor_tc,doktor_adi,doktor_soyadi,doktor_unvan)Values(@tcc,@adii,@soyadii,@unvan)", baglanti);
                        kontrol2.Parameters.AddWithValue("@tcc", textBox3_tcc.Text.ToString());
                        kontrol2.Parameters.AddWithValue("@adii", textBox1_adi.Text.ToString());
                        kontrol2.Parameters.AddWithValue("@soyadii", textBox2_soyadiii.Text.ToString());
                        kontrol2.Parameters.AddWithValue("@unvan", comboBox1_unvan.Text.ToString());
                        kontrol2.ExecuteNonQuery();
                        MessageBox.Show("Sorgun Başarıyla Eklendi");
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
                    if(kont == 1)
                    {
                        SqlCommand kontrol1 = new SqlCommand("Insert into kullanicilar(kullanici_adi,kullanici_sifre,seviye)Values(@kadi,@sifre,@seviye)", baglanti);
                        kontrol1.Parameters.AddWithValue("@kadi", textBox3_tcc.Text.ToString());
                        kontrol1.Parameters.AddWithValue("@sifre", textBox1_sıfre.Text.ToString().TrimEnd());
                        kontrol1.Parameters.AddWithValue("@seviye", "doktor");

                        kontrol1.ExecuteNonQuery();
                        MessageBox.Show("Sorgun Başarıyla Eklendi");
                    }


                    baglanti.Close();

                    bosalt();
                    goster();
                }catch(Exception hata)
                {
                    MessageBox.Show(hata.ToString());
                }
               

            }
    }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("DELETE FROM doktorlar WHERE doktor_id=@id", baglanti);

            sil.Parameters.AddWithValue("@id",label5.Text.ToString());
            sil.ExecuteNonQuery();
            baglanti.Close();
            bosalt();
            goster();
            

        }


        
        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("UPDATE doktorlar SET doktor_tc=@tc,doktor_adi=@adi,doktor_soyadi=@soyad,doktor_unvan=@unvan  WHERE doktor_id=@id", baglanti);
            
            guncelle.Parameters.AddWithValue("@tc", textBox3_tcc.Text.ToString());
            guncelle.Parameters.AddWithValue("@adi", textBox1_adi.Text.ToString());
            guncelle.Parameters.AddWithValue("@soyad", textBox2_soyadiii.Text.ToString());
            guncelle.Parameters.AddWithValue("@unvan", comboBox1_unvan.Text.ToString());
            guncelle.Parameters.AddWithValue("@id", Convert.ToInt32(label5.Text.ToString());
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
        public static string doktor;
        Form2_randevu_al rndval;
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            doktor = listView1.SelectedItems[0].SubItems[1].Text.ToString();
            if (rndval == null || rndval.IsDisposed)
            {
                rndval = new Form2_randevu_al();
                rndval.Show();
            }
            else
            {
                MessageBox.Show("Şuan zaten hasta bul menüsü açık tekra açılamaz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            this.Close();

        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            label5.Text = listView1.SelectedItems[0].SubItems[0].Text.ToString();
            textBox3_tcc.Text = listView1.SelectedItems[0].SubItems[1].Text.ToString();
            textBox1_adi.Text = listView1.SelectedItems[0].SubItems[2].Text.ToString();
            textBox2_soyadiii.Text = listView1.SelectedItems[0].SubItems[3].Text.ToString();
            comboBox1_unvan.Text = listView1.SelectedItems[0].SubItems[4].Text.ToString();
        }
    }
}
