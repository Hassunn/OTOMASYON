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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Collections;
using System.Web;


namespace HastaneOtomasyon
{
    public partial class recete : Form
    {
        public recete()
        {
            InitializeComponent();
        }
        public string hasta;
        private void recete_Load(object sender, EventArgs e)
        {


            hasta = randevularım.adsoyad;

            dataGridView1.ColumnCount = 3;

            dataGridView1.Columns[0].Name = "İLAÇ KODU";
            dataGridView1.Columns[1].Name = "İLAÇ ADI";
            dataGridView1.Columns[2].Name = "İLAÇ TÜRÜ";

            dataGridView3.ColumnCount = 4;

            dataGridView3.Columns[0].Name = "İLAÇ KODU";
            dataGridView3.Columns[1].Name = "İLAÇ ADI";
            dataGridView3.Columns[2].Name = "İLAÇ TÜRÜ";
            dataGridView3.Columns[3].Name = "TARİH";

            SqlConnection baglanti = new SqlConnection("Data Source =DESKTOP-JID65J8\\SQLEXPRESS; Initial Catalog=hastaneotomasyonu;Integrated Security = True ");
            baglanti.Open();
            SqlCommand kmttt = new SqlCommand("SELECT * FROM ilaclar ", baglanti);


            SqlDataReader drrr = kmttt.ExecuteReader();



            while (drrr.Read())
            {

                dataGridView1.Rows.Add(drrr["ilac_kodu"].ToString().TrimEnd(), drrr["ilac_adi"].ToString().TrimEnd(), drrr["ilac_turu"].ToString().TrimEnd());
            }
            baglanti.Close();
            drrr.Close();

            //eskiilaçlar
            dataGridView2.ColumnCount = 4;

            dataGridView2.Columns[0].Name = "İLAÇ KODU";
            dataGridView2.Columns[1].Name = "İLAÇ ADI";
            dataGridView2.Columns[2].Name = "İLAÇ TÜRÜ";
            dataGridView2.Columns[3].Name = "TARİH";


            baglanti.Open();
            SqlCommand kmtttt = new SqlCommand("SELECT * FROM receteler where hasta_adi = '" + hasta + "' ", baglanti);


            SqlDataReader drrrr = kmtttt.ExecuteReader();



            while (drrrr.Read())
            {

                dataGridView2.Rows.Add(drrrr["ilac_kod"].ToString().TrimEnd(), drrrr["ilac_ad"].ToString().TrimEnd(), drrrr["ilac_tur"].ToString().TrimEnd(), drrrr["tarih"].ToString().TrimEnd());
            }
            baglanti.Close();
            drrrr.Close();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            dataGridView3.Rows.Add(dataGridView1.CurrentRow.Cells[0].Value.ToString().TrimEnd(), dataGridView1.CurrentRow.Cells[1].Value.ToString().TrimEnd().TrimEnd(), dataGridView1.CurrentRow.Cells[2].Value.ToString().TrimEnd(), dateTimePicker1.Value.ToShortDateString());

        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {




            dataGridView3.Rows.Add(dataGridView2.CurrentRow.Cells[0].Value.ToString().TrimEnd(), dataGridView2.CurrentRow.Cells[1].Value.ToString().TrimEnd().TrimEnd(), dataGridView2.CurrentRow.Cells[2].Value.ToString().TrimEnd(), dateTimePicker1.Value.ToShortDateString());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source =DESKTOP-JID65J8\\SQLEXPRESS; Initial Catalog=hastaneotomasyonu;Integrated Security = True ");
            baglanti.Open();
            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {
                SqlCommand kmttttt = new SqlCommand("insert into receteler(hasta_adi,ilac_kod,ilac_ad,ilac_tur,tarih) values ('" + hasta + "' ,'" + dataGridView3.Rows[i].Cells[0].Value.ToString().TrimEnd() + "' ,'" + dataGridView3.Rows[i].Cells[1].Value.ToString().TrimEnd() + "' ,'" + dataGridView3.Rows[i].Cells[2].Value.ToString().TrimEnd() + "' ,'" + dataGridView3.Rows[i].Cells[3].Value.ToString().TrimEnd() + "'  )", baglanti);
                kmttttt.ExecuteNonQuery();
            }
            baglanti.Close();
  



      
                PdfPTable pdfTablosu1 = new PdfPTable(dataGridView3.ColumnCount-1);
                pdfTablosu1.DefaultCell.Padding = 5;
                pdfTablosu1.WidthPercentage = 100;
                pdfTablosu1.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTablosu1.DefaultCell.BorderWidth = 0;
                pdfTablosu1.DefaultCell.Border = Element.BODY;

         

                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance((Application.StartupPath +"\\ilk.png"));


                //Boyutlandırma için ScaleToFit() methodunu ya da ScalePercent() methodunu kullanabiliriz.

                img.ScaleToFit(600, 600);

                //Çerçeve vermek için aşağıdaki özelliklerini kullanabiliriz.

                img.Border = iTextSharp.text.Rectangle.TOP_BORDER;

                img.BorderColor = iTextSharp.text.BaseColor.BLACK;

                img.BorderWidth = 0f;








            for (int k = 0; k < dataGridView3.Rows.Count - 1; k++)
            {

                MessageBox.Show(k.ToString());

                pdfTablosu1.AddCell(dataGridView3.Rows[k].Cells[0].Value.ToString());
                pdfTablosu1.AddCell(dataGridView3.Rows[k].Cells[1].Value.ToString());
                pdfTablosu1.AddCell(dataGridView3.Rows[k].Cells[2].Value.ToString());
  
            }
         
                SaveFileDialog dosyakaydet = new SaveFileDialog();
        

                dosyakaydet.RestoreDirectory = true;
                dosyakaydet.Filter = "PDF Dosyası|*.pdf";
      
                if (dosyakaydet.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(dosyakaydet.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
                        iTextSharp.text.Font fn = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL);
                        PdfWriter.GetInstance(pdfDoc, stream);

                        pdfDoc.AddCreationDate();
                        pdfDoc.Open();
                        pdfDoc.Add(img);
              
                        pdfDoc.Add(pdfTablosu1);

                        pdfDoc.Close();
                        stream.Close();

                        MessageBox.Show("PDF dosyası başarıyla oluşturuldu!\n" + "Dosya Konumu: " + dosyakaydet.FileName, "İşlem Tamam");
            
                    }
                }

        }
    }
}