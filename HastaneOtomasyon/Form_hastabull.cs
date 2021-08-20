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
    public partial class Form_hastabull : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source =DESKTOP-JID65J8\\SQLEXPRESS; Initial Catalog=hastaneotomasyonu;Integrated Security = True ");


        public Form_hastabull()
        {
            InitializeComponent();
        }

        private void Form_hastabull_Load(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand kmt = new SqlCommand("SELECT * FROM hastalar", baglanti);
            SqlDataReader gor = kmt.ExecuteReader();
            while (gor.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = gor["hasta_tc"].ToString();
                ekle.SubItems.Add(gor["hasta_adi"].ToString());
                ekle.SubItems.Add(gor["hasta_soyadi"].ToString());           
                listView1.Items.Add(ekle);
            }
            baglanti.Close();



        }
        public static string ad1;
        public static  string soyad1;
        public  static double tc1;


        private void listView1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            tc1 = Convert.ToDouble(listView1.SelectedItems[0].SubItems[0].Text.ToString());
            ad1 = listView1.SelectedItems[0].SubItems[1].Text.ToString();
            soyad1 = listView1.SelectedItems[0].SubItems[2].Text.ToString();
            



            Form2_randevu_al.ad2 = ad1;
            Form2_randevu_al.soyad2 = soyad1;
            Form2_randevu_al.tc2 = tc1;
            
      
            Form2_randevu_al nw = new Form2_randevu_al();
            nw.Show();
            this.Hide();
        }

        private void textBox1_araamaa_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("SELECT * FROM hastalar WHERE hasta_tc LIKE '%" + textBox1_araamaa.Text + "%' OR hasta_adi LIKE '%" + textBox1_araamaa.Text + "%' OR hasta_soyadi LIKE '%" + textBox1_araamaa.Text + "%'", baglanti); 
            SqlDataReader gor = kmt.ExecuteReader();
            while (gor.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = gor["hasta_tc"].ToString();
                ekle.SubItems.Add(gor["hasta_adi"].ToString());
                ekle.SubItems.Add(gor["hasta_soyadi"].ToString());
                listView1.Items.Add(ekle);
            }
            baglanti.Close();

        }
    }
}
