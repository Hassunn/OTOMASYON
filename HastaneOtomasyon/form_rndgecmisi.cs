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
    public partial class form_rndgecmisi : Form

    {
        SqlConnection baglanti = new SqlConnection("Data Source =DESKTOP-JID65J8\\SQLEXPRESS; Initial Catalog=hastaneotomasyonu;Integrated Security = True ");

        public form_rndgecmisi()
        {
            InitializeComponent();
        }

        private void form_rndgecmisi_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand kntrol = new SqlCommand("SELECT * FROM randevular where doktor='"+ Form1_giris.doktor+ "'", baglanti);
            SqlDataReader gor = kntrol.ExecuteReader();
            while (gor.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = gor["tc"].ToString();
                ekle.SubItems.Add(gor["adi"].ToString());
                ekle.SubItems.Add(gor["soyadi"].ToString());
                ekle.SubItems.Add(gor["randevu_saat"].ToString());
                listView1.Items.Add(ekle);
            }
            listView1.GridLines = true;
            baglanti.Close();
        }
    }
}
