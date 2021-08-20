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
using System.Collections;

namespace HastaneOtomasyon
{
    public partial class Form2_randevu_al : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source =DESKTOP-JID65J8\\SQLEXPRESS; Initial Catalog=hastaneotomasyonu;Integrated Security = True ");

        public Form2_randevu_al()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        Form_hastabull hstbull;
        private void button1_hstbul_Click(object sender, EventArgs e)
        {
            if (hstbull == null || hstbull.IsDisposed)
            {
                hstbull = new Form_hastabull();
                hstbull.Show();
            }
            else
            {
                MessageBox.Show("Şuan zaten hasta bul menüsü açık tekra açılamaz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            this.Hide();

        }
        public static  double tc2 = 0;
        public static string ad2 ="";
        public static string soyad2 ="";

        ArrayList ss1 = new ArrayList();
        string[] sat1;
        private void Form2_randevu_al_Load(object sender, EventArgs e)
        {
            dateTimePicker1_tarihhhhh.MinDate = dateTimePicker1_tarihhhhh.Value;

            comboBox1.Text = form_doktorlar.doktor;
            checkedListBox1.SelectedItem = null;
           if(comboBox1.Text != "")
            {
                baglanti.Open();
                SqlCommand kntrol1 = new SqlCommand("SELECT * FROM randevular where doktor = '" + comboBox1.Text.TrimEnd()+ "' and tarih = '"+ dateTimePicker1_tarihhhhh.Value.ToShortDateString().TrimEnd()+ "' ", baglanti);
                
                SqlDataReader gor1 = kntrol1.ExecuteReader();
                while (gor1.Read())
                {
                    if(gor1["tarih"].ToString().TrimEnd() == dateTimePicker1_tarihhhhh.Value.ToShortDateString().TrimEnd())
                    {
                       
                        ss1.Add(gor1["randevu_saat"].ToString().TrimEnd());
                    }
                    
                }

        
                string[] saat = { "09:15", "09:30", "09:45", "10:00", "10:15", "10:30","23:45", "10:45", "11:00", "11:15", "11:30", "11:45", "13:00", "13:15", "13:30"," 13:45", "14:00", "14:15", "14:30", "14:45", "15:00", "15:15", "15:30", "15:45", "16:00", "16:15", "16:30", "16:45"};//saatekle
                checkedListBox1.Items.Clear();
                
                for (int i = 0; i < saat.Length; i++)
                {

                        if (ss1.Contains(saat[i].ToString().TrimEnd()) != true)
                        {
                            char aa = ':';
                            sat1 = (saat[i].Split(aa));
                            
                            if (Convert.ToInt32(dateTimePicker1_tarihhhhh.Value.Hour) <= Convert.ToInt32(sat1[0]) && Convert.ToInt32(dateTimePicker1_tarihhhhh.Value.Minute) <= Convert.ToInt32(sat1[1]))
                            {
                                
                                checkedListBox1.Items.Add(saat[i]);
                            }
                        }
                    



                }
                baglanti.Close();
            }

        }

        private void Form2_randevu_al_Shown(object sender, EventArgs e)
        {
            textBox1_tc.Text = tc2.ToString();
            textBox2_adi.Text = ad2.ToString();
            textBox3_soyadi.Text = soyad2.ToString();


        }
        form_doktorlar doktor;
        private void button_doktor_ekle_Click(object sender, EventArgs e)
        {
            if (doktor == null || doktor.IsDisposed)
            {
                doktor = new form_doktorlar();
                doktor.Show();
            }
            else
            {
                MessageBox.Show("Şuan zaten Doktor Ekle menüsü açık tekrar açılamaz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            this.Close();

        }

        private void textBox1_tc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_adi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBox3_soyadi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void button1_randevu_al_Click(object sender, EventArgs e)
        {
            
            if(label7.Text != " ") 
            {
                baglanti.Open();
                SqlCommand kontrol = new SqlCommand("Insert into randevular(tc,adi,soyadi,tarih,doktor,randevu_saat)Values(@tcc,@adii,@soyadii,@tarihh,@doktorr,@randevu_saatii)", baglanti);
                kontrol.Parameters.AddWithValue("@tcc", textBox1_tc.Text.ToString());
                kontrol.Parameters.AddWithValue("@adii", textBox2_adi.Text.ToString());
                kontrol.Parameters.AddWithValue("@soyadii", textBox3_soyadi.Text.ToString());
                kontrol.Parameters.AddWithValue("@tarihh", dateTimePicker1_tarihhhhh.Value.ToString().Substring(0, 9));
                kontrol.Parameters.AddWithValue("@doktorr", form_doktorlar.doktor.ToString().TrimEnd());
                kontrol.Parameters.AddWithValue("@randevu_saatii", sec.ToString().TrimEnd());
                kontrol.ExecuteNonQuery();
                MessageBox.Show("Randevu Başarıyla Kaydedildi");
                baglanti.Close();
                textBox1_tc.Text = "";
                textBox2_adi.Text = "";
                textBox3_soyadi.Text = "";
                comboBox1.Text = "";
                label7_rndvsaat.Visible = false;
                checkedListBox1.Height = 154;
                checkedListBox1.Items.Clear();
                checkedListBox1.Show();
                baglanti.Close();
            }


        }


        string sec;
        int sec1;
        private void checkedListBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            sec = checkedListBox1.SelectedItem.ToString();
            sec1 = checkedListBox1.SelectedIndex;
            checkedListBox1.Height = 50;
            checkedListBox1.Hide();
            label7_rndvsaat.Text = sec;
            label7_rndvsaat.Visible = true;
         
        }


    }
}
