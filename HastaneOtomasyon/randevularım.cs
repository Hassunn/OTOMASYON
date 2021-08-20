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
    public partial class randevularım : Form
    {
        public randevularım()
        {
            InitializeComponent();
        }
        public static string adsoyad = "";
        private void randevularım_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 5;
          
            dataGridView1.Columns[0].Name = "TC";
            dataGridView1.Columns[1].Name = "ADI";
            dataGridView1.Columns[2].Name = "SOYADI";
            dataGridView1.Columns[3].Name = "TARİH";
            dataGridView1.Columns[4].Name = "RANDEVU SAATİ";
            SqlConnection baglanti = new SqlConnection("Data Source =DESKTOP-JID65J8\\SQLEXPRESS; Initial Catalog=hastaneotomasyonu;Integrated Security = True ");
            baglanti.Open();
            SqlCommand kmttt = new SqlCommand("SELECT * FROM randevular where doktor='"+ Form1_giris.doktor + "' and tarih='"+dateTimePicker1.Value.ToShortDateString()+"'", baglanti);

            SqlDataReader drrr = kmttt.ExecuteReader();



            while (drrr.Read())
            {

                dataGridView1.Rows.Add(drrr["tc"].ToString().TrimEnd(), drrr["adi"].ToString().TrimEnd(), drrr["soyadi"].ToString().TrimEnd(), drrr["tarih"].ToString().TrimEnd(), drrr["randevu_saat"].ToString().TrimEnd());
            }

            dataGridView1.Sort(dataGridView1.Columns[4], ListSortDirection.Ascending);





            baglanti.Close();
            drrr.Close();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            adsoyad = (dataGridView1.CurrentRow.Cells[1].Value.ToString().TrimEnd() + " " + dataGridView1.CurrentRow.Cells[2].Value.ToString().TrimEnd());

            recete rct = new recete();
            rct.Show();

        }
    }
}
