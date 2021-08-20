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
    public partial class Form_hastaduzenle : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source =DESKTOP-JID65J8\\SQLEXPRESS; Initial Catalog=hastaneotomasyonu;Integrated Security = True ");

        public Form_hastaduzenle()
        {
            InitializeComponent();
        }

        private void button_iptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_hastaduzenle_Load(object sender, EventArgs e)
        {

        }

        private void button_guncelle_Click(object sender, EventArgs e)
        {
            char aa = ' ';
            string[] metin = adsoyd.Text.ToString().TrimEnd().Split(aa);

            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("UPDATE hastalar SET hasta_tc=@tc,hasta_adi=@hastaad,hasta_soyadi=@soyadii,hasta_baba=@baba,hasta_anne=@anne,hasta_dogum=@dog,hasta_dogumtrh=@tarih,hasta_cins=@cinsiyet,hasta_sosyalgv=@sos,hasta_med=@med,hasta_eskipoli=@eskipol,hasta_mah=@mahalle,hasta_ev=@ev,hasta_cep=@cep,hasta_email=@email   WHERE hasta_id=@id ", baglanti);
            guncelle.Parameters.AddWithValue("@tc",textBox1_TC.Text.ToString());
            guncelle.Parameters.AddWithValue("@hastaad", metin[0].ToString());

            guncelle.Parameters.AddWithValue("@soyadii", metin[1].ToString());
            guncelle.Parameters.AddWithValue("@baba",babaad.Text.ToString());
            guncelle.Parameters.AddWithValue("@anne", anneadi.Text.ToString());
            guncelle.Parameters.AddWithValue("@dog", dgmyeri.Text.ToString());
            guncelle.Parameters.AddWithValue("@tarih",Convert.ToDateTime( dateTimePicker1.Text.ToString()));
            guncelle.Parameters.AddWithValue("@cinsiyet", comboBox2_cnsiyet.Text.ToString());
            guncelle.Parameters.AddWithValue("@sos", ssyalguvenlikno.Text.ToString());
            guncelle.Parameters.AddWithValue("@med", medenihali.Text.ToString());
            guncelle.Parameters.AddWithValue("@eskipol", textBox1_onceki.Text.ToString());
            guncelle.Parameters.AddWithValue("@mahalle", mahkoy.Text.ToString());
            guncelle.Parameters.AddWithValue("@ev", maskedTextBox1_EV.Text.ToString());
            guncelle.Parameters.AddWithValue("@cep", maskedTextBox2_TEL.Text.ToString());
            guncelle.Parameters.AddWithValue("@email", email.Text.ToString());
            guncelle.Parameters.AddWithValue("@id", label5.Text.ToString());
            MessageBox.Show("Başarıyla Güncelleme Yaptınız","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

            guncelle.ExecuteNonQuery();
            baglanti.Close();
            this.Close();
            form_hstalar ac = new form_hstalar();
            ac.Show();
        }
    }
}
