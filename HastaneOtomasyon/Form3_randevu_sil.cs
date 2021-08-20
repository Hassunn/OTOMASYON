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
    public partial class Form3_randevu_sil : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source =DESKTOP-JID65J8\\SQLEXPRESS; Initial Catalog=hastaneotomasyonu;Integrated Security = True ");
        public Form3_randevu_sil()
        {
            InitializeComponent();
        }


        private void Form3_randevu_sil_Load(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand kntrol1 = new SqlCommand("SELECT * FROM randevular  ", baglanti);
            SqlDataReader gor1 = kntrol1.ExecuteReader();
            while (gor1.Read())
            {
                if(Convert.ToInt32(dateTimePicker1.Value.Hour.ToString()) <= Convert.ToInt32(gor1["randevu_saat"].ToString().Substring(0, 2).TrimEnd()))
                {
                    ListViewItem ekle = new ListViewItem();

                    ekle.Text = gor1["id"].ToString();
                    ekle.SubItems.Add(gor1["tc"].ToString());
                    ekle.SubItems.Add(gor1["adi"].ToString());
                    ekle.SubItems.Add(gor1["soyadi"].ToString());
                    ekle.SubItems.Add(gor1["tarih"].ToString());
                    ekle.SubItems.Add(gor1["doktor"].ToString());
                    ekle.SubItems.Add(gor1["randevu_saat"].ToString());
                    listView1_sil.Items.Add(ekle);


                }
                
            }
        }
    }
}
