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
    public partial class Form5_hasta_ekle : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source =DESKTOP-JID65J8\\SQLEXPRESS; Initial Catalog=hastaneotomasyonu;Integrated Security = True ");
        public Form5_hasta_ekle()
        {
            InitializeComponent();
        }
        

        private void textBox1_TC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);//buraada sadece harf ve karakter girişini engelledik
        }

        private void adsoyd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)&& !char.IsSeparator(e.KeyChar);//rakam girişini engelledik

        }

        private void babaad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);//rakam girişini engelledik

        }

        private void anneadi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);//rakam girişini engelledik

        }

        private void button_kaydet_Click(object sender, EventArgs e)
        {
            if (textBox1_TC.Text==""||adsoyd.Text.Trim()==""||babaad.Text.Trim()==""||anneadi.Text.Trim()==""||comboBox1_uyruk.Text.Trim()==""||dgmyeri.Text.Trim()==""||comboBox2_cnsiyet.Text.Trim()==""||textBox1_onceki.Text.Trim()==""||textBox1_onceki.Text.Trim()=="")//texboxlaın boşluğunu kontol ettik aynı zamanda boşluklaı trim ile sildik
            {
                label_uyarı.Text = "Lütfen Zorunlu Alanları Doldurunuz";
                label_uyarı.Show();

            }
            else if (textBox1_TC.TextLength<10)
            {
                label_uyarı.Text = "Lütfen Geçerli Bir TC Giriniz";
                label_uyarı.Show();
            }
            else
            {
               

                baglanti.Open();
                char aa = ' ';
                string[] metin = adsoyd.Text.ToString().TrimEnd().Split(aa);

                SqlCommand kmt = new SqlCommand("Insert into hastalar(hasta_tc,hasta_adi,hasta_soyadi,hasta_baba,hasta_anne,hasta_dogum,hasta_dogumtrh,hasta_cins,hasta_sosyalgv,hasta_med,hasta_mah,hasta_ev,hasta_cep,hasta_email,hasta_eskikamet,hasta_saat,hasta_eskipoli)Values(@tc,@hastaadi,@hasta_soyadi,@baba,@anne,@dogum,@dogumtr,@cins,@sosyal,@med,@mah,@ev,@cep,@email,@eskiikamet,@saat,@onceki)", baglanti);
                kmt.Parameters.AddWithValue("@hastaadi", metin[0].ToString());
                kmt.Parameters.AddWithValue("@hasta_soyadi", metin[1].ToString());
                kmt.Parameters.AddWithValue("@tc", textBox1_TC.Text.ToString());
                kmt.Parameters.AddWithValue("@baba", babaad.Text.ToString());
                kmt.Parameters.AddWithValue("@anne", anneadi.Text.ToString());
                kmt.Parameters.AddWithValue("@dogum", dgmyeri.Text.ToString());
                kmt.Parameters.AddWithValue("@dogumtr",Convert.ToDateTime(dateTimePicker1.Text));
                kmt.Parameters.AddWithValue("@cins", comboBox2_cnsiyet.Text.ToString());
                kmt.Parameters.AddWithValue("@sosyal", comboBox3_sosyalgvnce.Text.ToString());
                kmt.Parameters.AddWithValue("@med", medenihali.Text.ToString());
                kmt.Parameters.AddWithValue("@mah", mahkoy.Text.ToString());
                kmt.Parameters.AddWithValue("@ev", maskedTextBox1_EV.Text.ToString());
                kmt.Parameters.AddWithValue("@cep", maskedTextBox2_TEL.Text.ToString());
                kmt.Parameters.AddWithValue("@email", email.Text.ToString());
                kmt.Parameters.AddWithValue("@saat",  dateTimePicker1.Value.ToString());
                kmt.Parameters.AddWithValue("@eskiikamet", textBox1_eskikamet.Text.ToString());
                kmt.Parameters.AddWithValue("@onceki", textBox1_onceki.Text.ToString());



                kmt.ExecuteNonQuery();
                MessageBox.Show("Sorgun Başarıyla Eklendi");
                baglanti.Close();
                temizle();
                //veri tabanına kaydetme işlemi yapılacak
                label_uyarı.Text = "";

                label_uyarı.Show();
                temizle();

            }
        }
        private void temizle()
        {
            textBox1_TC.Text = "";//bütün alanlar için temizleme yaptık
            adsoyd.Text = "";
            babaad.Text = "";
            anneadi.Text = "";
            dgmyeri.Text = "";
            comboBox1_uyruk.Text="";
            comboBox2_cnsiyet.Text = "";
            comboBox3_sosyalgvnce.Text = "";
            ssyalguvenlikno.Text = "";
            medenihali.Text = "";
            iller.Text = "";
            ilceler.Text = "";
            belde.Text = "";
            mahkoy.Text = "";
            aptno.Text = "";
            katno.Text = "";
            daireno.Text = "";
            maskedTextBox1_EV.Text = "";
            maskedTextBox2_TEL.Text = "";
            email.Text = "";
            textBox1_eskikamet.Text = "";
            textBox1_onceki.Text = "";

                
            
        }

        private void button1_temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void ssyalguvenlikno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void belde_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void mahkoy_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void aptno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);//karakter girişi engellendi
        }

        private void katno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void daireno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void maskedTextBox1_EV_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);

        }

        private void maskedTextBox2_TEL_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);

        }

        private void email_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }
        private void dgmyeri_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void Form5_hasta_ekle_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate =dateTimePicker1.Value;
           
        }

        private void dgmyeri_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void button_iptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
