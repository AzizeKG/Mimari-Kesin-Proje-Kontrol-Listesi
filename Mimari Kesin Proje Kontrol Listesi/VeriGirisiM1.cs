using System;
using System.IO;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Microsoft.Office.Interop.Excel;
using excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using Npgsql;
using System.Collections.Generic;

namespace Mimari_Kesin_Proje_Kontrol_Listesi
{




    public partial class VeriGirisiM1 : System.Windows.Forms.Form
    {
        private UIApplication uiapp;
        private UIDocument uidoc;
        private Autodesk.Revit.ApplicationServices.Application app;
        private Document doc;
        private object excelApplicationObject;
        private object path;


        public int DurumId { get; set; }
        public string DokumanKodu { get; set; }


        public VeriGirisiM1(ExternalCommandData commandData)
        {
            InitializeComponent();

            uiapp = commandData.Application;
            uidoc = uiapp.ActiveUIDocument;
            app = uiapp.Application;
            doc = uidoc.Document;
        }




        public VeriGirisiM1()
        {
            lbl7.Visible = false;
            textBx4.Visible = false;
            textBx8.Visible = false;
            textBx12.Visible = false;
            textBx16.Visible = false;
            textBx24.Visible = false;
            textBx28.Visible = false;
            textBx33.Visible = false;
            textBx37.Visible = false;
            textBx41.Visible = false;
            textBx45.Visible = false;
            textBx49.Visible = false;
            textBx53.Visible = false;
            textBx57.Visible = false;
            textBx61.Visible = false;
            textBx65.Visible = false;
            labl4.Visible = false;
            texBx2.Visible = false;
            texBx4.Visible = false;
            texBx6.Visible = false;
            texBx8.Visible = false;
            texBx10.Visible = false;
            texBx12.Visible = false;
            texBx14.Visible = false;
            texBx16.Visible = false;
            texBx18.Visible = false;
            texBx20.Visible = false;
            texBx22.Visible = false;
            texBx24.Visible = false;
            texBx26.Visible = false;
            texBx28.Visible = false;
            texBx30.Visible = false;
            texBx32.Visible = false;
            texBx34.Visible = false;
            texBx36.Visible = false;
            texBx38.Visible = false;
            texBx40.Visible = false;
        }



        

        private void btnExclAktr_Click(object sender, EventArgs e)
        {
            object missing = Type.Missing;
            excel.Application app = new excel.Application();
            app.Visible = true;
            Workbook oWB = app.Workbooks.Add(missing);
            Worksheet sayfa = oWB.ActiveSheet as Worksheet;
            sayfa.Name = "SAYFA2";
            Worksheet sayfa2 = oWB.Sheets.Add(missing, missing, 1, missing)
                            as Worksheet;
            sayfa2.Name = "SAYFA1";
       

            // Başlıklar - 1. satır
            sayfa.Cells[1, 1] = lbl1.Text;
            sayfa.Cells[1, 2] = lbl2.Text;
            sayfa.Cells[1, 3] = lbl4.Text;
            sayfa.Cells[1, 4] = lbl7.Text;
            // 2. Satır
            sayfa.Cells[2, 1] = lbl8.Text;
            sayfa.Cells[2, 3] = textBx3.Text;
            sayfa.Cells[2, 4] = textBx4.Text;
            var kabul = "✓";
            var red = "X";
            if (checkBx1.Checked == true)
            {
                sayfa.Cells[2, 2] = kabul;

            }
            else if (checkBx1.Checked == false)
            {
                sayfa.Cells[2, 2] = red;
            }
            // 3. Satır
            sayfa.Cells[3, 1] = lbl9.Text;
            if (checkBx2.Checked == true)
            {
                sayfa.Cells[3, 2] = kabul;

            }
            else if (checkBx2.Checked == false)
            {
                sayfa.Cells[3, 2] = red;
            }
            sayfa.Cells[3, 3] = textBx7.Text;
            sayfa.Cells[3, 4] = textBx8.Text;
            // 4. Satır
            sayfa.Cells[4, 1] = lbl10.Text;
            if (checkBx3.Checked == true)
            {
                sayfa.Cells[4, 2] = kabul;

            }
            else if (checkBx3.Checked == false)
            {
                sayfa.Cells[4, 2] = red;
            }
            sayfa.Cells[4, 3] = textBx11.Text;
            sayfa.Cells[4, 4] = textBx12.Text;
            // 5. Satır
            sayfa.Cells[5, 1] = lbl11.Text;
            if (checkBx4.Checked == true)
            {
                sayfa.Cells[5, 2] = kabul;

            }
            else if (checkBx4.Checked == false)
            {
                sayfa.Cells[5, 2] = red;
            }
            sayfa.Cells[5, 3] = textBx15.Text;
            sayfa.Cells[5, 4] = textBx16.Text;
            // 6. Satır
            sayfa.Cells[6, 1] = lbl12.Text;
            if (checkBx5.Checked == true)
            {
                sayfa.Cells[6, 2] = kabul;

            }
            else if (checkBx5.Checked == false)
            {
                sayfa.Cells[6, 2] = red;
            }
            sayfa.Cells[6, 3] = textBx23.Text;
            sayfa.Cells[6, 4] = textBx24.Text;
            // 7. Satır
            sayfa.Cells[7, 1] = lbl13.Text;
            if (checkBx6.Checked == true)
            {
                sayfa.Cells[7, 2] = kabul;

            }
            else if (checkBx6.Checked == false)
            {
                sayfa.Cells[7, 2] = red;
            }
            sayfa.Cells[7, 3] = textBx27.Text;
            sayfa.Cells[7, 4] = textBx28.Text;
            // 8. Satır
            sayfa.Cells[8, 1] = lbl14.Text;
            if (checkBx7.Checked == true)
            {
                sayfa.Cells[8, 2] = kabul;

            }
            else if (checkBx7.Checked == false)
            {
                sayfa.Cells[8, 2] = red;
            }
            sayfa.Cells[8, 3] = textBx32.Text;
            sayfa.Cells[8, 4] = textBx33.Text;
            // 9. Satır
            sayfa.Cells[9, 1] = lbl15.Text;
            if (checkBx8.Checked == true)
            {
                sayfa.Cells[9, 2] = kabul;

            }
            else if (checkBx8.Checked == false)
            {
                sayfa.Cells[9, 2] = red;
            }
            sayfa.Cells[9, 3] = textBx36.Text;
            sayfa.Cells[9, 4] = textBx37.Text;
            // 10. Satır
            sayfa.Cells[10, 1] = lbl16.Text;
            if (checkBx9.Checked == true)
            {
                sayfa.Cells[10, 2] = kabul;

            }
            else if (checkBx9.Checked == false)
            {
                sayfa.Cells[10, 2] = red;
            }
            sayfa.Cells[10, 3] = textBx40.Text;
            sayfa.Cells[10, 4] = textBx41.Text;
            // 11. Satır
            sayfa.Cells[11, 1] = lbl17.Text;
            if (checkBx10.Checked == true)
            {
                sayfa.Cells[11, 2] = kabul;

            }
            else if (checkBx10.Checked == false)
            {
                sayfa.Cells[11, 2] = red;
            }
            sayfa.Cells[11, 3] = textBx44.Text;
            sayfa.Cells[11, 4] = textBx45.Text;
            // 12. Satır
            sayfa.Cells[12, 1] = lbl18.Text;
            if (checkBx11.Checked == true)
            {
                sayfa.Cells[12, 2] = kabul;

            }
            else if (checkBx11.Checked == false)
            {
                sayfa.Cells[12, 2] = red;
            }
            sayfa.Cells[12, 3] = textBx48.Text;
            sayfa.Cells[12, 4] = textBx49.Text;
            // 13. Satır
            sayfa.Cells[13, 1] = lbl19.Text;
            if (checkBx12.Checked == true)
            {
                sayfa.Cells[13, 2] = kabul;

            }
            else if (checkBx12.Checked == false)
            {
                sayfa.Cells[13, 2] = red;
            }
            sayfa.Cells[13, 4] = textBx52.Text;
            sayfa.Cells[13, 5] = textBx53.Text;
            // 14. Satır 
            sayfa.Cells[14, 1] = lbl20.Text;
            if (checkBx13.Checked == true)
            {
                sayfa.Cells[14, 2] = kabul;

            }
            else if (checkBx13.Checked == false)
            {
                sayfa.Cells[14, 2] = red;
            }
            sayfa.Cells[14, 3] = textBx56.Text;
            sayfa.Cells[14, 4] = textBx57.Text;
            // 15. Satır
            sayfa.Cells[15, 1] = lbl21.Text;
            if (checkBx14.Checked == true)
            {
                sayfa.Cells[15, 2] = kabul;

            }
            else if (checkBx14.Checked == false)
            {
                sayfa.Cells[15, 2] = red;
            }
            sayfa.Cells[15, 3] = textBx60.Text;
            sayfa.Cells[15, 4] = textBx61.Text;
            // 16. Satır 
            sayfa.Cells[16, 1] = lbl22.Text;
            if (checkBx15.Checked == true)
            {
                sayfa.Cells[16, 2] = kabul;

            }
            else if (checkBx15.Checked == false)
            {
                sayfa.Cells[16, 2] = red;
            }
            sayfa.Cells[16, 3] = textBx64.Text;
            sayfa.Cells[16, 4] = textBx65.Text;

            // 17. Satır Kullanıcı Bilgileri
            sayfa.Cells[17, 1] = lbl24.Text;
            sayfa.Cells[17, 2] = textBx67.Text;


            // 2. Sayfa Başlıklar - 1. satır
            sayfa2.Cells[1, 1] = labl1.Text;
            sayfa2.Cells[1, 2] = labl2.Text;
            sayfa2.Cells[1, 3] = labl3.Text;
            sayfa2.Cells[1, 4] = labl4.Text;
            // Sayfa2 2. Satır
            sayfa2.Cells[2, 1 ]=labl5.Text;
            if (chckBx1.Checked == true)
            {
                sayfa2.Cells[2, 2] = kabul;

            }
            else if (checkBx1.Checked == false)
            {
                sayfa2.Cells[2, 2] = red;
            }
            sayfa2.Cells[2, 3]=texBx1.Text;
            sayfa2.Cells[2, 4] = texBx2.Text;
            // Sayfa2 3. Satır
            sayfa2.Cells[3, 1] = labl6.Text;
            if (chckBx2.Checked == true)
            {
                sayfa2.Cells[3, 2] = kabul;

            }
            else if (checkBx2.Checked == false)
            {
                sayfa2.Cells[3, 2] = red;
            }
            sayfa2.Cells[3, 3] = texBx3.Text;
            sayfa2.Cells[3, 4] = texBx4.Text;
            // Sayfa2 4. Satır
            sayfa2.Cells[4, 1] = labl7.Text;
            if (chckBx3.Checked == true)
            {
                sayfa2.Cells[4, 2] = kabul;

            }
            else if (checkBx3.Checked == false)
            {
                sayfa2.Cells[4, 2] = red;
            }
            sayfa2.Cells[4, 3] = texBx5.Text;
            sayfa2.Cells[4, 4] = texBx6.Text;
            // Sayfa2 5. Satır
            sayfa2.Cells[5, 1] = labl8.Text;
            if (chckBx4.Checked == true)
            {
                sayfa2.Cells[5, 2] = kabul;

            }
            else if (checkBx4.Checked == false)
            {
                sayfa2.Cells[5, 2] = red;
            }
            sayfa2.Cells[5, 3] = texBx7.Text;
            sayfa2.Cells[5, 4] = texBx8.Text;
            // Sayfa2 6. Satır
            sayfa2.Cells[6, 1] = labl9.Text;
            if (chckBx5.Checked == true)
            {
                sayfa2.Cells[6, 2] = kabul;

            }
            else if (checkBx5.Checked == false)
            {
                sayfa2.Cells[6, 2] = red;
            }
            sayfa2.Cells[6, 3] = texBx9.Text;
            sayfa2.Cells[6, 4] = texBx10.Text;
            // Sayfa2 7. Satır
            sayfa2.Cells[7, 1] = labl10.Text;
            if (chckBx6.Checked == true)
            {
                sayfa2.Cells[7, 2] = kabul;

            }
            else if (checkBx6.Checked == false)
            {
                sayfa2.Cells[7, 2] = red;
            }
            sayfa2.Cells[7, 3] = texBx11.Text;
            sayfa2.Cells[7, 4] = texBx12.Text;
            // Sayfa2 8. Satır 
            sayfa2.Cells[8, 1] = labl11.Text;
            if (chckBx7.Checked == true)
            {
                sayfa2.Cells[8, 2] = kabul;

            }
            else if (checkBx7.Checked == false)
            {
                sayfa2.Cells[8, 2] = red;
            }
            sayfa2.Cells[8, 3] = texBx13.Text;
            sayfa2.Cells[8, 4] = texBx14.Text;
            // Sayfa2 9. Satır 
            sayfa2.Cells[9, 1] = labl12.Text;
            if (chckBx8.Checked == true)
            {
                sayfa2.Cells[9, 2] = kabul;

            }
            else if (checkBx8.Checked == false)
            {
                sayfa2.Cells[9, 2] = red;
            }
            sayfa2.Cells[9, 3] = texBx15.Text;
            sayfa2.Cells[9, 4] = texBx16.Text;
            // Sayfa2 10. Satır
            sayfa2.Cells[10, 1] = labl13.Text;
            if (chckBx9.Checked == true)
            {
                sayfa2.Cells[10, 2]= kabul;

            }
            else if (checkBx9.Checked == false)
            {
                sayfa2.Cells[10, 2] = red;
            }
            sayfa2.Cells[10, 3] = texBx17.Text;
            sayfa2.Cells[10, 4] = texBx18.Text;
            // Sayfa2 11. Satır 
            sayfa2.Cells[11, 1] = labl14.Text;
            if (chckBx10.Checked == true)
            {
                sayfa2.Cells[11, 2] = kabul;

            }
            else if (checkBx10.Checked == false)
            {
                sayfa2.Cells[11, 2] = red;
            }
            sayfa2.Cells[11, 3] = texBx19.Text;
            sayfa2.Cells[11, 4] = texBx20.Text;
            // Sayfa2 12. Satır 
            sayfa2.Cells[12, 1] = labl15.Text;
            if (chckBx11.Checked == true)
            {
                sayfa2.Cells[12, 2]= kabul;

            }
            else if (checkBx11.Checked == false)
            {
                sayfa2.Cells[12, 2] = red;
            }
            sayfa2.Cells[12, 3] = texBx21.Text;
            sayfa2.Cells[12, 4] = texBx22.Text;
            // Sayfa2 13. Satır 
            sayfa2.Cells[13, 1] = labl16.Text;
            if (chckBx12.Checked == true)
            {
                sayfa2.Cells[13, 2] = kabul;

            }
            else if (checkBx12.Checked == false)
            {
                sayfa2.Cells[13, 2] = red;
            }
            sayfa2.Cells[13, 3] = texBx23.Text;
            sayfa2.Cells[13, 4] = texBx24.Text;
            // Sayfa2 14. Satır 
            sayfa2.Cells[14, 1] = labl17.Text;
            if (chckBx13.Checked == true)
            {
                sayfa2.Cells[14, 2] = kabul;

            }
            else if (checkBx13.Checked == false)
            {
                sayfa2.Cells[14, 2] = red;
            }
            sayfa2.Cells[14, 3] = texBx25.Text;
            sayfa2.Cells[14, 4] = texBx26.Text;
            // Sayfa2 15. Satır 
            sayfa2.Cells[15, 1] = labl18.Text;
            if (chckBx14.Checked == true)
            {
                sayfa2.Cells[15, 2] = kabul;

            }
            else if (checkBx14.Checked == false)
            {
                sayfa2.Cells[15, 2] = red;
            }
            sayfa2.Cells[15, 3] = texBx27.Text;
            sayfa2.Cells[15, 4] = texBx28.Text;
            // Sayfa2 16. Satır 
            sayfa2.Cells[16, 1] = labl19.Text;
            if (chckBx15.Checked == true)
            {
                sayfa2.Cells[16, 2] = kabul;

            }
            else if (checkBx15.Checked == false)
            {
                sayfa2.Cells[16, 2] = red;
            }
            sayfa2.Cells[16, 3] = texBx29.Text;
            sayfa2.Cells[16, 4] = texBx30.Text;
            // Sayfa2 17. Satır
            sayfa2.Cells[17, 1] = labl20.Text;
            if (chckBx16.Checked == true)
            {
                sayfa2.Cells[17, 2] = kabul;

            }
            else if (chckBx16.Checked == false)
            {
                sayfa2.Cells[17, 2] = red;
            }
            sayfa2.Cells[17, 3] = texBx31.Text;
            sayfa2.Cells[17, 4] = texBx32.Text;
            // Sayfa2 18. Satır 
            sayfa2.Cells[18, 1] = labl21.Text;
            if (chckBx17.Checked == true)
            {
                sayfa2.Cells[18, 2] = kabul;

            }
            else if (chckBx17.Checked == false)
            {
                sayfa2.Cells[18, 2] = red;
            }
            sayfa2.Cells[18, 3] = texBx33.Text;
            sayfa2.Cells[18, 4] = texBx34.Text;
            // Sayfa2 19. Satır 
            sayfa2.Cells[19, 1] = labl22.Text;
            if (chckBx18.Checked == true)
            {
                sayfa2.Cells[19, 2] = kabul;

            }
            else if (chckBx18.Checked == false)
            {
                sayfa2.Cells[19, 2] = red;
            }
            sayfa2.Cells[19, 3] = texBx35.Text;
            sayfa2.Cells[19, 4] = texBx36.Text;
            // Sayfa2 20. Satır 
            sayfa2.Cells[20, 1] = labl23.Text;
            if (chckBx19.Checked == true)
            {
                sayfa2.Cells[20, 2] = kabul;

            }
            else if (chckBx19.Checked == false)
            {
                sayfa2.Cells[20, 2] = red;
            }
            sayfa2.Cells[20, 3] = texBx37.Text;
            sayfa2.Cells[20, 4] = texBx38.Text;
            // Sayfa2 21. Satır
            sayfa2.Cells[21, 1] = labl24.Text;
            if (chckBx20.Checked == true)
            {
                sayfa2.Cells[21, 2] = kabul;

            }
            else if (chckBx20.Checked == false)
            {
                sayfa2.Cells[21, 2] = red;
            }
            sayfa2.Cells[21, 3] = texBx39.Text;
            sayfa2.Cells[21, 4] = texBx40.Text;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\azize\source\repos\Mimari Kesin Proje Kontrol Listesi\Mimari Kesin Proje Kontrol Listesi\PDFSaver.mdf;Integrated Security=True");
            SqlDataAdapter adtr = new SqlDataAdapter("Select *from dbo.data_pdf ", baglanti); //PDFSaver / Properties/ Connection String 
            baglanti.Open();

            System.Data.DataSet ds = new DataSet();
            adtr.Fill(ds, "dbo.data_pdf");

            PDFSaverEntities db = new PDFSaverEntities();
            dataGridView1.DataSource = ds.Tables["dbo.data_pdf"];
            
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\azize\source\repos\Mimari Kesin Proje Kontrol Listesi\Mimari Kesin Proje Kontrol Listesi\PDFSaver.mdf;Integrated Security=True");
        SqlCommand cmd;
        private string durum;

        private void btnVeriKayıt_Click(object sender, EventArgs e)
        {


            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {

                string file = openFileDialog1.FileName;
                string[] f = file.Split('\\');
                // Dosya İsmi Seçme
                string fn = f[(f.Length) - 1];
                string dest = @"C:\Users\azize\Desktop\Kaydedilen_PDF\" + fn; 
                // Hedef Klasöre Dosyayı Kopyalama İşlemi
                File.Copy(file, dest, true);
                // Veritabanına Kaydetme İşlemi
                string q = "insert into [data_pdf] values('" + fn + "','" + dest + "')";
                cmd = new SqlCommand(q, con);
                con.Open();
                cmd.ExecuteNonQuery();
                
            }
        }

        private void btnPDFAc_Click(object sender, EventArgs e)
        {
            var rowIndex = dataGridView1.SelectedCells[0].RowIndex;
            var path = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            Process.Start(path);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            var path = dataGridView1.Rows[2].Cells[2].Value.ToString();
            Process.Start(path);
            linkLabel1.LinkVisited=true;
        }

        private void TS12576_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var path = dataGridView1.Rows[1].Cells[2].Value.ToString();
            Process.Start(path);
            TS12576.LinkVisited = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var path = dataGridView1.Rows[0].Cells[2].Value.ToString();
            Process.Start(path);
            linkLabel2.LinkVisited = true;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var path = dataGridView1.Rows[0].Cells[2].Value.ToString();
            Process.Start(path);
            linkLabel3.LinkVisited = true;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var path = dataGridView1.Rows[0].Cells[2].Value.ToString();
            Process.Start(path);
            linkLabel4.LinkVisited = true;
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var path = dataGridView1.Rows[0].Cells[2].Value.ToString();
            Process.Start(path);
            linkLabel5.LinkVisited = true;
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var path = dataGridView1.Rows[0].Cells[2].Value.ToString();
            Process.Start(path);
            linkLabel6.LinkVisited = true;
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var path = dataGridView1.Rows[5].Cells[2].Value.ToString();
            Process.Start(path);
            linkLabel7.LinkVisited = true;
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var path = dataGridView1.Rows[5].Cells[2].Value.ToString();
            Process.Start(path);
            linkLabel8.LinkVisited = true;
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var path = dataGridView1.Rows[5].Cells[2].Value.ToString();
            Process.Start(path);
            linkLabel9.LinkVisited = true;
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var path = dataGridView1.Rows[4].Cells[2].Value.ToString();
            Process.Start(path);
            linkLabel10.LinkVisited = true;
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var path = dataGridView1.Rows[0].Cells[2].Value.ToString();
            Process.Start(path);
            linkLabel11.LinkVisited = true;
        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var path = dataGridView1.Rows[3].Cells[2].Value.ToString();
            Process.Start(path);
            linkLabel12.LinkVisited = true;
        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var path = dataGridView1.Rows[3].Cells[2].Value.ToString();
            Process.Start(path);
            linkLabel13.LinkVisited = true;
        }

        private void btnRet_Click(object sender, EventArgs e)
        {
            using (Veritabani vt = new Veritabani())
            {
                var yaz = vt.Sorgu($"UPDATE durum SET durum='RT' WHERE id={DurumId};");
                yaz.ExecuteNonQuery();
            }
            Close();
            
            NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=dbchecklist; user Id=postgres; password=1");
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,aciklama_yuklenici,kullanici_adi,soru_id) values (@p1,@p2,@p3,@p4,@p5,1)", baglanti);

            // 1. soru
            // Kullanıcı Bilgileri Kaydetme
            komut1.Parameters.AddWithValue("@p1", lbl8.Text);
            komut1.Parameters.AddWithValue("@p2", checkBx1.Checked);
            komut1.Parameters.AddWithValue("@p3", textBx3.Text);
            komut1.Parameters.AddWithValue("@p4", textBx4.Text);
            komut1.Parameters.AddWithValue("@p5", textBx67.Text);
            komut1.ExecuteNonQuery();
            // 2. soru 
            NpgsqlCommand komut2 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,2)", baglanti);
            komut2.Parameters.AddWithValue("@p1", lbl9.Text);
            komut2.Parameters.AddWithValue("@p2", checkBx2.Checked);
            komut2.Parameters.AddWithValue("@p3", textBx7.Text);
            komut2.ExecuteNonQuery();
            // 3. soru 
            NpgsqlCommand komut3 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,3)", baglanti);
            komut3.Parameters.AddWithValue("@p1", lbl10.Text);
            komut3.Parameters.AddWithValue("@p2", checkBx3.Checked);
            komut3.Parameters.AddWithValue("@p3", textBx11.Text);
            komut3.ExecuteNonQuery();
            // 4. soru
            NpgsqlCommand komut4 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,4)", baglanti);
            komut4.Parameters.AddWithValue("@p1", lbl11.Text);
            komut4.Parameters.AddWithValue("@p2", checkBx4.Checked);
            komut4.Parameters.AddWithValue("@p3", textBx15.Text);
            komut4.ExecuteNonQuery();
            // 5. soru
            NpgsqlCommand komut5 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,5)", baglanti);
            komut5.Parameters.AddWithValue("@p1", lbl12.Text);
            komut5.Parameters.AddWithValue("@p2", checkBx5.Checked);
            komut5.Parameters.AddWithValue("@p3", textBx23.Text);
            komut5.ExecuteNonQuery();
            // 6. soru
            NpgsqlCommand komut6 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,6)", baglanti);
            komut6.Parameters.AddWithValue("@p1", lbl13.Text);
            komut6.Parameters.AddWithValue("@p2", checkBx6.Checked);
            komut6.Parameters.AddWithValue("@p3", textBx27.Text);
            komut6.ExecuteNonQuery();
            // 7. soru 
            NpgsqlCommand komut7 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,7)", baglanti);
            komut7.Parameters.AddWithValue("@p1", lbl14.Text);
            komut7.Parameters.AddWithValue("@p2", checkBx7.Checked);
            komut7.Parameters.AddWithValue("@p3", textBx32.Text);
            komut7.ExecuteNonQuery();
            // 8. soru
            NpgsqlCommand komut8 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,8)", baglanti);
            komut8.Parameters.AddWithValue("@p1", lbl15.Text);
            komut8.Parameters.AddWithValue("@p2", checkBx8.Checked);
            komut8.Parameters.AddWithValue("@p3", textBx36.Text);
            komut8.ExecuteNonQuery();
            // 9. soru 
            NpgsqlCommand komut9 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,9)", baglanti);
            komut9.Parameters.AddWithValue("@p1", lbl16.Text);
            komut9.Parameters.AddWithValue("@p2", checkBx9.Checked);
            komut9.Parameters.AddWithValue("@p3", textBx40.Text);
            komut9.ExecuteNonQuery();
            // 10. soru
            NpgsqlCommand komut10 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,10)", baglanti);
            komut10.Parameters.AddWithValue("@p1", lbl17.Text);
            komut10.Parameters.AddWithValue("@p2", checkBx10.Checked);
            komut10.Parameters.AddWithValue("@p3", textBx44.Text);
            komut10.ExecuteNonQuery();
            // 11. soru
            NpgsqlCommand komut11 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,11)", baglanti);
            komut11.Parameters.AddWithValue("@p1", lbl18.Text);
            komut11.Parameters.AddWithValue("@p2", checkBx11.Checked);
            komut11.Parameters.AddWithValue("@p3", textBx48.Text);
            komut11.ExecuteNonQuery();
            // 12. soru
            NpgsqlCommand komut12 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,12)", baglanti);
            komut12.Parameters.AddWithValue("@p1", lbl19.Text);
            komut12.Parameters.AddWithValue("@p2", checkBx12.Checked);
            komut12.Parameters.AddWithValue("@p3", textBx52.Text);
            komut12.ExecuteNonQuery();
            // 13. soru
            NpgsqlCommand komut13 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,13)", baglanti);
            komut13.Parameters.AddWithValue("@p1", lbl20.Text);
            komut13.Parameters.AddWithValue("@p2", checkBx13.Checked);
            komut13.Parameters.AddWithValue("@p3", textBx56.Text);
            komut13.ExecuteNonQuery();
            // 14. soru
            NpgsqlCommand komut14 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,14)", baglanti);
            komut14.Parameters.AddWithValue("@p1", lbl21.Text);
            komut14.Parameters.AddWithValue("@p2", checkBx14.Checked);
            komut14.Parameters.AddWithValue("@p3", textBx60.Text);
            komut14.ExecuteNonQuery();
            // 15. soru 
            NpgsqlCommand komut15 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,15)", baglanti);
            komut15.Parameters.AddWithValue("@p1", lbl22.Text);
            komut15.Parameters.AddWithValue("@p2", checkBx15.Checked);
            komut15.Parameters.AddWithValue("@p3", textBx64.Text);
            komut15.ExecuteNonQuery();
            // 2. sayfa 1. soru
            NpgsqlCommand komut16 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,16)", baglanti);
            komut16.Parameters.AddWithValue("@p1", labl5.Text);
            komut16.Parameters.AddWithValue("@p2", chckBx1.Checked);
            komut16.Parameters.AddWithValue("@p3", texBx1.Text);
            komut16.ExecuteNonQuery();
            // 2. sayfa 2. soru
            NpgsqlCommand komut17 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,17)", baglanti);
            komut17.Parameters.AddWithValue("@p1", labl6.Text);
            komut17.Parameters.AddWithValue("@p2", chckBx2.Checked);
            komut17.Parameters.AddWithValue("@p3", texBx3.Text);
            komut17.ExecuteNonQuery();
            // 2. sayfa 3. soru
            NpgsqlCommand komut18 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,18)", baglanti);
            komut18.Parameters.AddWithValue("@p1", labl7.Text);
            komut18.Parameters.AddWithValue("@p2", chckBx3.Checked);
            komut18.Parameters.AddWithValue("@p3", texBx5.Text);
            komut18.ExecuteNonQuery();
            // 2. sayfa 4. soru
            NpgsqlCommand komut19 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,19)", baglanti);
            komut19.Parameters.AddWithValue("@p1", labl8.Text);
            komut19.Parameters.AddWithValue("@p2", chckBx4.Checked);
            komut19.Parameters.AddWithValue("@p3", texBx7.Text);
            komut19.ExecuteNonQuery();
            // 2. sayfa 5. soru
            NpgsqlCommand komut20 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,20)", baglanti);
            komut20.Parameters.AddWithValue("@p1", labl9.Text);
            komut20.Parameters.AddWithValue("@p2", chckBx5.Checked);
            komut20.Parameters.AddWithValue("@p3", texBx9.Text);
            komut20.ExecuteNonQuery();
            // 2. sayfa 6. soru
            NpgsqlCommand komut21 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,21)", baglanti);
            komut21.Parameters.AddWithValue("@p1", labl10.Text);
            komut21.Parameters.AddWithValue("@p2", chckBx6.Checked);
            komut21.Parameters.AddWithValue("@p3", texBx11.Text);
            komut21.ExecuteNonQuery();
            // 2. sayfa 7. soru
            NpgsqlCommand komut22 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,22)", baglanti);
            komut22.Parameters.AddWithValue("@p1", labl11.Text);
            komut22.Parameters.AddWithValue("@p2", chckBx7.Checked);
            komut22.Parameters.AddWithValue("@p3", texBx13.Text);
            komut22.ExecuteNonQuery();
            // 2. sayfa 8. soru
            NpgsqlCommand komut23 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,23)", baglanti);
            komut23.Parameters.AddWithValue("@p1", labl12.Text);
            komut23.Parameters.AddWithValue("@p2", chckBx8.Checked);
            komut23.Parameters.AddWithValue("@p3", texBx15.Text);
            komut23.ExecuteNonQuery();
            // 2. sayfa 9. soru
            NpgsqlCommand komut24 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,24)", baglanti);
            komut24.Parameters.AddWithValue("@p1", labl13.Text);
            komut24.Parameters.AddWithValue("@p2", chckBx9.Checked);
            komut24.Parameters.AddWithValue("@p3", texBx17.Text);
            komut24.ExecuteNonQuery();
            // 2. sayfa 10. soru
            NpgsqlCommand komut25 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,25)", baglanti);
            komut25.Parameters.AddWithValue("@p1", labl14.Text);
            komut25.Parameters.AddWithValue("@p2", chckBx10.Checked);
            komut25.Parameters.AddWithValue("@p3", texBx19.Text);
            komut25.ExecuteNonQuery();
            // 2. sayfa 11. soru
            NpgsqlCommand komut26 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,26)", baglanti);
            komut26.Parameters.AddWithValue("@p1", labl15.Text);
            komut26.Parameters.AddWithValue("@p2", chckBx11.Checked);
            komut26.Parameters.AddWithValue("@p3", texBx21.Text);
            komut26.ExecuteNonQuery();
            // 2. sayfa 12. soru
            NpgsqlCommand komut27 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,27)", baglanti);
            komut27.Parameters.AddWithValue("@p1", labl16.Text);
            komut27.Parameters.AddWithValue("@p2", chckBx12.Checked);
            komut27.Parameters.AddWithValue("@p3", texBx23.Text);
            komut27.ExecuteNonQuery();
            // 2. sayfa 13. soru
            NpgsqlCommand komut28 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,28)", baglanti);
            komut28.Parameters.AddWithValue("@p1", labl17.Text);
            komut28.Parameters.AddWithValue("@p2", chckBx13.Checked);
            komut28.Parameters.AddWithValue("@p3", texBx25.Text);
            komut28.ExecuteNonQuery();
            // 2. sayfa 14. soru
            NpgsqlCommand komut29 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,29)", baglanti);
            komut29.Parameters.AddWithValue("@p1", labl18.Text);
            komut29.Parameters.AddWithValue("@p2", chckBx14.Checked);
            komut29.Parameters.AddWithValue("@p3", texBx27.Text);
            komut29.ExecuteNonQuery();
            // 2. sayfa 15. soru
            NpgsqlCommand komut30 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,30)", baglanti);
            komut30.Parameters.AddWithValue("@p1", labl19.Text);
            komut30.Parameters.AddWithValue("@p2", chckBx15.Checked);
            komut30.Parameters.AddWithValue("@p3", texBx29.Text);
            komut30.ExecuteNonQuery();
            // 2. sayfa 16. soru
            NpgsqlCommand komut31 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,31)", baglanti);
            komut31.Parameters.AddWithValue("@p1", labl20.Text);
            komut31.Parameters.AddWithValue("@p2", chckBx16.Checked);
            komut31.Parameters.AddWithValue("@p3", texBx31.Text);
            komut31.ExecuteNonQuery();
            // 2. sayfa 17. soru
            NpgsqlCommand komut32 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,32)", baglanti);
            komut32.Parameters.AddWithValue("@p1", labl21.Text);
            komut32.Parameters.AddWithValue("@p2", chckBx17.Checked);
            komut32.Parameters.AddWithValue("@p3", texBx33.Text);
            komut32.ExecuteNonQuery();
            // 2. sayfa 18. soru
            NpgsqlCommand komut33 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,33)", baglanti);
            komut33.Parameters.AddWithValue("@p1", labl22.Text);
            komut33.Parameters.AddWithValue("@p2", chckBx18.Checked);
            komut33.Parameters.AddWithValue("@p3", texBx35.Text);
            komut33.ExecuteNonQuery();
            // 2. sayfa 19. soru
            NpgsqlCommand komut34 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,34)", baglanti);
            komut34.Parameters.AddWithValue("@p1", labl23.Text);
            komut34.Parameters.AddWithValue("@p2", chckBx19.Checked);
            komut34.Parameters.AddWithValue("@p3", texBx37.Text);
            komut34.ExecuteNonQuery();
            // 2. sayfa 20. soru
            NpgsqlCommand komut35 = new NpgsqlCommand("insert into checklist (label_adi,kontrol,aciklama_danisman,soru_id) values (@p1,@p2,@p3,35)", baglanti);
            komut35.Parameters.AddWithValue("@p1", labl24.Text);
            komut35.Parameters.AddWithValue("@p2", chckBx20.Checked);
            komut35.Parameters.AddWithValue("@p3", texBx39.Text);
            komut35.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Revizyon Talep Edildi");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Veritabani vt = new Veritabani())
            {
                var yaz = vt.Sorgu($"UPDATE durum SET durum='OK' WHERE id={DurumId};");
                yaz.ExecuteNonQuery();
            }
            Close();
        }
    }
    }

