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
    public partial class form_hstalar : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source =DESKTOP-JID65J8\\SQLEXPRESS; Initial Catalog=hastaneotomasyonu;Integrated Security = True ");


        public form_hstalar()
        {
            InitializeComponent();
        }
        
        public void hastalist()
        {
            listView1_hastalar.Items.Clear();
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("SELECT * FROM hastalar", baglanti);
            SqlDataReader gor = kmt.ExecuteReader();
            while (gor.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = gor["hasta_id"].ToString();
                ekle.SubItems.Add(gor["hasta_adi"].ToString());
                ekle.SubItems.Add(gor["hasta_tc"].ToString());
                ekle.SubItems.Add(gor["hasta_baba"].ToString());
                ekle.SubItems.Add(gor["hasta_anne"].ToString());
                ekle.SubItems.Add(gor["hasta_dogum"].ToString());
                ekle.SubItems.Add(gor["hasta_dogumtrh"].ToString());
                ekle.SubItems.Add(gor["hasta_cins"].ToString());
                ekle.SubItems.Add(gor["hasta_sosyalgv"].ToString());
                ekle.SubItems.Add(gor["hasta_med"].ToString());
                ekle.SubItems.Add(gor["hasta_mah"].ToString());
                ekle.SubItems.Add(gor["hasta_ev"].ToString());
                ekle.SubItems.Add(gor["hasta_cep"].ToString());
                ekle.SubItems.Add(gor["hasta_email"].ToString());
                ekle.SubItems.Add(gor["hasta_eskikamet"].ToString());
                ekle.SubItems.Add(gor["hasta_saat"].ToString());
                ekle.SubItems.Add(gor["hasta_eskipoli"].ToString());

                listView1_hastalar.Items.Add(ekle);
                
            }
            listView1_hastalar.GridLines = true;
            
            baglanti.Close();
        }
        private void form_hstalar_Load(object sender, EventArgs e)
        {
            hastalist();
            listView1_hastalar.Columns[14].Width = 250;
        }

        private void textBox1_hastaara_TextChanged(object sender, EventArgs e)
        {
            listView1_hastalar.Items.Clear();
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("SELECT * FROM hastalar WHERE hasta_tc LIKE '%"+textBox1_hastaara.Text+ "%' OR hasta_adi LIKE '%" + textBox1_hastaara.Text + "%' OR hasta_baba LIKE '%" + textBox1_hastaara.Text + "%'", baglanti);
            SqlDataReader gor = kmt.ExecuteReader();
            while (gor.Read())
            {
                
                ListViewItem ekle = new ListViewItem();
                ekle.Text = gor["hasta_id"].ToString();
                ekle.SubItems.Add(gor["hasta_adi"].ToString());
                ekle.SubItems.Add(gor["hasta_tc"].ToString());
                ekle.SubItems.Add(gor["hasta_baba"].ToString());
                ekle.SubItems.Add(gor["hasta_anne"].ToString());
                ekle.SubItems.Add(gor["hasta_dogum"].ToString());
                ekle.SubItems.Add(gor["hasta_dogumtrh"].ToString());
                ekle.SubItems.Add(gor["hasta_cins"].ToString());
                ekle.SubItems.Add(gor["hasta_sosyalgv"].ToString());
                ekle.SubItems.Add(gor["hasta_med"].ToString());
                ekle.SubItems.Add(gor["hasta_mah"].ToString());
                ekle.SubItems.Add(gor["hasta_ev"].ToString());
                ekle.SubItems.Add(gor["hasta_cep"].ToString());
                ekle.SubItems.Add(gor["hasta_email"].ToString());
                ekle.SubItems.Add(gor["hasta_eskikamet"].ToString());
                ekle.SubItems.Add(gor["hasta_saat"].ToString());
                listView1_hastalar.Items.Add(ekle);

            }
            listView1_hastalar.GridLines = true;

            baglanti.Close();
        }

        private void listView1_hastalar_DoubleClick(object sender, EventArgs e)
        {
            Form_hastaduzenle ekle = new Form_hastaduzenle();
            ekle.label5.Text= listView1_hastalar.SelectedItems[0].SubItems[0].Text.ToString();
            ekle.adsoyd.Text = listView1_hastalar.SelectedItems[0].SubItems[1].Text.ToString();
            ekle.textBox1_TC.Text = listView1_hastalar.SelectedItems[0].SubItems[2].Text.ToString();
            ekle.babaad.Text = listView1_hastalar.SelectedItems[0].SubItems[3].Text.ToString();
            ekle.anneadi.Text = listView1_hastalar.SelectedItems[0].SubItems[4].Text.ToString();
            ekle.dgmyeri.Text = listView1_hastalar.SelectedItems[0].SubItems[5].Text.ToString();
            ekle. dateTimePicker1.Value =Convert.ToDateTime(listView1_hastalar.SelectedItems[0].SubItems[6].Text.ToString());
            ekle.comboBox2_cnsiyet.Text = listView1_hastalar.SelectedItems[0].SubItems[7].Text.ToString();
            ekle.ssyalguvenlikno.Text = listView1_hastalar.SelectedItems[0].SubItems[8].Text.ToString();
            ekle.medenihali.Text = listView1_hastalar.SelectedItems[0].SubItems[9].Text.ToString();
            ekle.mahkoy.Text = listView1_hastalar.SelectedItems[0].SubItems[10].Text.ToString();
            ekle.maskedTextBox1_EV.Text = listView1_hastalar.SelectedItems[0].SubItems[11].Text.ToString();
            ekle.maskedTextBox1_EV.Text = listView1_hastalar.SelectedItems[0].SubItems[12].Text.ToString();
            ekle.email.Text = listView1_hastalar.SelectedItems[0].SubItems[13].Text.ToString();
            ekle.textBox1_onceki.Text = listView1_hastalar.SelectedItems[0].SubItems[14].Text.ToString();
            ekle.Show();
            this.Close();
        
        }
    }

}
