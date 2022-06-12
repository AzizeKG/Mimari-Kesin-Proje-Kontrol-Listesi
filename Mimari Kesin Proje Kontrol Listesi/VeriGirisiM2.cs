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




    public partial class VeriGirisiM2 : System.Windows.Forms.Form
    {
        private UIApplication uiapp;
        private UIDocument uidoc;
        private Autodesk.Revit.ApplicationServices.Application app;
        private Document doc;
        private object excelApplicationObject;
        private object path;


        public int DurumId { get; set; }
        public string DokumanKodu { get; set; }


        public VeriGirisiM2(ExternalCommandData commandData)
        {
            InitializeComponent();

            uiapp = commandData.Application;
            uidoc = uiapp.ActiveUIDocument;
            app = uiapp.Application;
            doc = uidoc.Document;
        }

        private void VeriGirisiM2_Load(object sender, EventArgs e)
        {
            var kontroller = new List<bool>();
            var aciklamalar = new List<string>();
            var kullanicilar = new List<string>();
            var sorular = new List<int>();
            var aciklamayuk = new List<string>();

            NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=dbchecklist; user Id=postgres; password=1");
            baglanti.Open();

            using (Veritabani vt = new Veritabani())
            {
                var oku1 = vt.Sorgu("select kontrol, aciklama_danisman,aciklama_yuklenici,kullanici_adi,soru_id from checklist");
                NpgsqlDataReader reader = oku1.ExecuteReader();
                while (reader.Read())
                {


                    var kontrol = reader.GetBoolean(0);
                    var aciklama_danısman = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    var aciklama_yuklenici = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    var kullanici_adi = reader.IsDBNull(3) ? "" : reader.GetString(3);
                    var soru_id = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                    kontroller.Add(kontrol);
                    aciklamalar.Add(aciklama_danısman);
                    aciklamayuk.Add(aciklama_yuklenici);
                    kullanicilar.Add(kullanici_adi);
                    sorular.Add(soru_id);
                }
            }


            int i = 0;
            // 1. Yanıt ve Kullanıcı Bilgileri okuma 
            i = sorular.FindIndex(p => p == 1);
            checkBx1.Checked = kontroller[i];
            textBx3.Text = aciklamalar[i];
            textBx4.Text = aciklamayuk[i];

            //2. Yanıt 
            i = sorular.FindIndex(p => p == 2);
            checkBx2.Checked = kontroller[i];
            textBx7.Text = aciklamalar[i];
            textBx8.Text = aciklamayuk[i];
            textBxY.Text = kullanicilar[i];

            //3. Yanıt 
            i = sorular.FindIndex(p => p == 3);
            checkBx3.Checked = kontroller[i];
            textBx11.Text = aciklamalar[i];
            textBx12.Text = aciklamayuk[i];
            // 4. Yanıt 
            i = sorular.FindIndex(p => p == 4);
            checkBx4.Checked = kontroller[i];
            textBx15.Text = aciklamalar[i];
            textBx16.Text = aciklamayuk[i];
            // 5. Yanıt 
            i = sorular.FindIndex(p => p == 5);
            checkBx5.Checked = kontroller[i];
            textBx23.Text = aciklamalar[i];
            textBx24.Text = aciklamayuk[i];
            // 6. Yanıt 
            i = sorular.FindIndex(p => p == 6);
            checkBx6.Checked = kontroller[i];
            textBx27.Text = aciklamalar[i];
            textBx28.Text = aciklamayuk[i];
            // 7. Yanıt 
            i = sorular.FindIndex(p => p == 7);
            checkBx7.Checked = kontroller[i];
            textBx32.Text = aciklamalar[i];
            textBx33.Text = aciklamayuk[i];
            // 8. Yanıt 
            i = sorular.FindIndex(p => p == 8);
            checkBx8.Checked = kontroller[i];
            textBx36.Text = aciklamalar[i];
            textBx37.Text = aciklamayuk[i];
            // 9. Yanıt 
            i = sorular.FindIndex(p => p == 9);
            checkBx9.Checked = kontroller[i];
            textBx40.Text = aciklamalar[i];
            textBx41.Text = aciklamayuk[i];
            // 10. Yanıt 
            i = sorular.FindIndex(p => p == 10);
            checkBx10.Checked = kontroller[i];
            textBx44.Text = aciklamalar[i];
            textBx45.Text = aciklamayuk[i];
            // 11. Yanıt 
            i = sorular.FindIndex(p => p == 11);
            checkBx11.Checked = kontroller[i];
            textBx48.Text = aciklamalar[i];
            textBx49.Text = aciklamayuk[i];
            // 12. Yanıt 
            i = sorular.FindIndex(p => p == 12);
            checkBx12.Checked = kontroller[i];
            textBx52.Text = aciklamalar[i];
            textBx53.Text = aciklamayuk[i];
            // 13. Yanıt 
            i = sorular.FindIndex(p => p == 13);
            checkBx13.Checked = kontroller[i];
            textBx56.Text = aciklamalar[i];
            textBx57.Text = aciklamayuk[i];
            // 14. Yanıt 
            i = sorular.FindIndex(p => p == 14);
            chckBx14.Checked = kontroller[i];
            texBx27.Text = aciklamalar[i];
            textBx61.Text = aciklamayuk[i];
            // 15. Yanıt 
            i = sorular.FindIndex(p => p == 15);
            checkBx15.Checked = kontroller[i];
            textBx64.Text = aciklamalar[i];
            textBx65.Text = aciklamayuk[i];
            // 16. Yanıt 
            i = sorular.FindIndex(p => p == 16);
            chckBx1.Checked = kontroller[i];
            texBx1.Text = aciklamalar[i];
            texBx2.Text = aciklamayuk[i];
            // 17. Yanıt 
            i = sorular.FindIndex(p => p == 17);
            chckBx2.Checked = kontroller[i];
            texBx3.Text = aciklamalar[i];
            texBx4.Text = aciklamayuk[i];
            // 18. Yanıt 
            i = sorular.FindIndex(p => p == 18);
            chckBx3.Checked = kontroller[i];
            texBx5.Text = aciklamalar[i];
            texBx6.Text = aciklamayuk[i];
            // 19. Yanıt 
            i = sorular.FindIndex(p => p == 19);
            chckBx4.Checked = kontroller[i];
            texBx7.Text = aciklamalar[i];
            texBx8.Text = aciklamayuk[i];
            // 20. Yanıt 
            i = sorular.FindIndex(p => p == 20);
            chckBx5.Checked = kontroller[i];
            texBx9.Text = aciklamalar[i];
            texBx10.Text = aciklamayuk[i];
            // 21. Yanıt 
            i = sorular.FindIndex(p => p == 21);
            chckBx6.Checked = kontroller[i];
            texBx11.Text = aciklamalar[i];
            texBx12.Text = aciklamayuk[i];
            // 22. Yanıt 
            i = sorular.FindIndex(p => p == 22);
            chckBx7.Checked = kontroller[i];
            texBx13.Text = aciklamalar[i];
            texBx14.Text= aciklamayuk[i];
            // 23. Yanıt 
            i = sorular.FindIndex(p => p == 23);
            chckBx8.Checked = kontroller[i];
            texBx15.Text = aciklamalar[i];
            texBx16.Text = aciklamayuk[i];
            // 24. Yanıt
            i = sorular.FindIndex(p => p == 24);
            chckBx9.Checked = kontroller[i];
            texBx17.Text = aciklamalar[i];
            texBx18.Text = aciklamayuk[i];
            // 25. Yanıt 
            i = sorular.FindIndex(p => p == 25);
            chckBx10.Checked = kontroller[i];
            texBx19.Text = aciklamalar[i];
            texBx20.Text = aciklamayuk[i];
            // 26. Yanıt 
            i = sorular.FindIndex(p => p == 26);
            chckBx11.Checked = kontroller[i];
            texBx21.Text = aciklamalar[i];
            texBx22.Text = aciklamayuk[i];
            // 27. Yanıt 
            i = sorular.FindIndex(p => p == 27);
            chckBx12.Checked = kontroller[i];
            texBx23.Text = aciklamalar[i];
            texBx24.Text = aciklamayuk[i];
            // 28. Yanıt 
            i = sorular.FindIndex(p => p == 28);
            chckBx13.Checked = kontroller[i];
            texBx25.Text = aciklamalar[i];
            texBx26.Text = aciklamayuk[i];
            // 29. Yanıt 
            i = sorular.FindIndex(p => p == 29);
            chckBx14.Checked = kontroller[i];
            texBx27.Text = aciklamalar[i];
            texBx28.Text = aciklamayuk[i];
            // 30. Yanıt 
            i = sorular.FindIndex(p => p == 30);
            chckBx15.Checked = kontroller[i];
            texBx29.Text = aciklamalar[i];
            texBx30.Text = aciklamayuk[i];
            // 31. Yanıt 
            i = sorular.FindIndex(p => p == 31);
            chckBx16.Checked = kontroller[i];
            texBx31.Text = aciklamalar[i];
            texBx32.Text = aciklamayuk[i];
            // 32. Yanıt 
            i = sorular.FindIndex(p => p == 32);
            chckBx17.Checked = kontroller[i];
            texBx33.Text = aciklamalar[i];
            texBx34.Text = aciklamayuk[i];
            // 33. Yanıt 
            i = sorular.FindIndex(p => p == 33);
            chckBx18.Checked = kontroller[i];
            texBx35.Text = aciklamalar[i];
            texBx36.Text = aciklamayuk[i];
            // 34. Yanıt 
            i = sorular.FindIndex(p => p == 34);
            chckBx19.Checked = kontroller[i];
            texBx37.Text = aciklamalar[i];
            texBx38.Text = aciklamayuk[i];
            // 35. Yanıt 
            i = sorular.FindIndex(p => p == 35);
            chckBx20.Checked = kontroller[i];
            texBx39.Text = aciklamalar[i];
            texBx40.Text = aciklamayuk[i];
            baglanti.Close();

           //Vaziyet Planı-Yol kotu Planı Yüklenici NOtları Sadece Okunabilir
            textBx4.ReadOnly = true;
            textBx8.ReadOnly = true;
            textBx12.ReadOnly = true;
            textBx16.ReadOnly = true;
            textBx24.ReadOnly = true;
            textBx28.ReadOnly = true;
            textBx33.ReadOnly = true;
            textBx37.ReadOnly = true;
            textBx41.ReadOnly = true;
            textBx45.ReadOnly = true;
            textBx49.ReadOnly = true;
            textBx53.ReadOnly = true;
            textBx57.ReadOnly = true;
            textBx61.ReadOnly = true;
            textBx65.ReadOnly = true;
            //Kat planları - Kesitler Yüklenici Notları Sadece Okunabilir 
            texBx2.ReadOnly = true;
            texBx4.ReadOnly = true;
            texBx6.ReadOnly = true;
            texBx8.ReadOnly = true;
            texBx10.ReadOnly = true;
            texBx12.ReadOnly = true;
            texBx14.ReadOnly = true;
            texBx16.ReadOnly = true;
            texBx18.ReadOnly = true;
            texBx20.ReadOnly = true;
            texBx22.ReadOnly = true;
            texBx24.ReadOnly = true;
            texBx26.ReadOnly = true;
            texBx28.ReadOnly = true;
            texBx30.ReadOnly = true;
            texBx32.ReadOnly = true;
            texBx34.ReadOnly = true;
            texBx36.ReadOnly = true;
            texBx38.ReadOnly = true;
            texBx40.ReadOnly = true;
            textBxY.ReadOnly = true;

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


        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Veritabani vt = new Veritabani())
            {
                var yaz = vt.Sorgu($"UPDATE durum SET durum='OK' WHERE id={DurumId};");
                yaz.ExecuteNonQuery();
            }
            Close();

            NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=dbchecklist; user Id=postgres; password=1");
            baglanti.Open();
            // 1. soru ve Kullanıcı Bilgisi kaydetme 
            NpgsqlCommand komut1 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4,kullanici_adi=@p5 WHERE soru_id=1;", baglanti);
            komut1.Parameters.AddWithValue("@p1", lbl8.Text);
            komut1.Parameters.AddWithValue("@p2", checkBx1.Checked);
            komut1.Parameters.AddWithValue("@p3", textBx3.Text);
            komut1.Parameters.AddWithValue("@p4", textBx4.Text);
            komut1.Parameters.AddWithValue("@p5", textBx67.Text);
            komut1.ExecuteNonQuery();
            // 2. soru 
            NpgsqlCommand komut2 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4,kullanici_adi=@p5 WHERE soru_id=2;", baglanti);
            komut2.Parameters.AddWithValue("@p1", lbl9.Text);
            komut2.Parameters.AddWithValue("@p2", checkBx2.Checked);
            komut2.Parameters.AddWithValue("@p3", textBx7.Text);
            komut2.Parameters.AddWithValue("@p4", textBx8.Text);
            komut2.Parameters.AddWithValue("@p5", textBxY.Text);
            komut2.ExecuteNonQuery();
            // 3. soru 
            NpgsqlCommand komut3 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=3;", baglanti);
            komut3.Parameters.AddWithValue("@p1", lbl10.Text);
            komut3.Parameters.AddWithValue("@p2", checkBx3.Checked);
            komut3.Parameters.AddWithValue("@p3", textBx11.Text);
            komut3.Parameters.AddWithValue("@p4", textBx12.Text);
            komut3.ExecuteNonQuery();
            // 4. soru
            NpgsqlCommand komut4 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=4;", baglanti);
            komut4.Parameters.AddWithValue("@p1", lbl11.Text);
            komut4.Parameters.AddWithValue("@p2", checkBx4.Checked);
            komut4.Parameters.AddWithValue("@p3", textBx15.Text);
            komut4.Parameters.AddWithValue("@p4", textBx16.Text);
            komut4.ExecuteNonQuery();
            // 5. soru
            NpgsqlCommand komut5 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=5;", baglanti);
            komut5.Parameters.AddWithValue("@p1", lbl12.Text);
            komut5.Parameters.AddWithValue("@p2", checkBx5.Checked);
            komut5.Parameters.AddWithValue("@p3", textBx23.Text);
            komut5.Parameters.AddWithValue("@p4", textBx24.Text);
            komut5.ExecuteNonQuery();
            // 6. soru
            NpgsqlCommand komut6 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=6;", baglanti);
            komut6.Parameters.AddWithValue("@p1", lbl13.Text);
            komut6.Parameters.AddWithValue("@p2", checkBx6.Checked);
            komut6.Parameters.AddWithValue("@p3", textBx27.Text);
            komut6.Parameters.AddWithValue("@p4", textBx28.Text);
            komut6.ExecuteNonQuery();
            // 7. soru 
            NpgsqlCommand komut7 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=7;", baglanti);
            komut7.Parameters.AddWithValue("@p1", lbl14.Text);
            komut7.Parameters.AddWithValue("@p2", checkBx7.Checked);
            komut7.Parameters.AddWithValue("@p3", textBx32.Text);
            komut7.Parameters.AddWithValue("@p4", textBx33.Text);
            komut7.ExecuteNonQuery();
            // 8. soru
            NpgsqlCommand komut8 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=8;", baglanti);
            komut8.Parameters.AddWithValue("@p1", lbl15.Text);
            komut8.Parameters.AddWithValue("@p2", checkBx8.Checked);
            komut8.Parameters.AddWithValue("@p3", textBx36.Text);
            komut8.Parameters.AddWithValue("@p4", textBx37.Text);
            komut8.ExecuteNonQuery();
            // 9. soru 
            NpgsqlCommand komut9 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=9;", baglanti);
            komut9.Parameters.AddWithValue("@p1", lbl16.Text);
            komut9.Parameters.AddWithValue("@p2", checkBx9.Checked);
            komut9.Parameters.AddWithValue("@p3", textBx40.Text);
            komut9.Parameters.AddWithValue("@p4", textBx41.Text);
            komut9.ExecuteNonQuery();
            // 10. soru
            NpgsqlCommand komut10 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=10;", baglanti);
            komut10.Parameters.AddWithValue("@p1", lbl17.Text);
            komut10.Parameters.AddWithValue("@p2", checkBx10.Checked);
            komut10.Parameters.AddWithValue("@p3", textBx44.Text);
            komut10.Parameters.AddWithValue("@p4", textBx45.Text);
            komut10.ExecuteNonQuery();
            // 11. soru
            NpgsqlCommand komut11 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=11;", baglanti);
            komut11.Parameters.AddWithValue("@p1", lbl18.Text);
            komut11.Parameters.AddWithValue("@p2", checkBx11.Checked);
            komut11.Parameters.AddWithValue("@p3", textBx48.Text);
            komut11.Parameters.AddWithValue("@p4", textBx49.Text);
            komut11.ExecuteNonQuery();
            // 12. soru
            NpgsqlCommand komut12 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=12;", baglanti);
            komut12.Parameters.AddWithValue("@p1", lbl19.Text);
            komut12.Parameters.AddWithValue("@p2", checkBx12.Checked);
            komut12.Parameters.AddWithValue("@p3", textBx52.Text);
            komut12.Parameters.AddWithValue("@p4", textBx53.Text);
            komut12.ExecuteNonQuery();
            // 13. soru
            NpgsqlCommand komut13 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=13;", baglanti);
            komut13.Parameters.AddWithValue("@p1", lbl20.Text);
            komut13.Parameters.AddWithValue("@p2", checkBx13.Checked);
            komut13.Parameters.AddWithValue("@p3", textBx56.Text);
            komut13.Parameters.AddWithValue("@p4", textBx57.Text);
            komut13.ExecuteNonQuery();
            // 14. soru
            NpgsqlCommand komut14 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=14;", baglanti);
            komut14.Parameters.AddWithValue("@p1", lbl21.Text);
            komut14.Parameters.AddWithValue("@p2", checkBx14.Checked);
            komut14.Parameters.AddWithValue("@p3", textBx60.Text);
            komut14.Parameters.AddWithValue("@p4", textBx61.Text);
            komut14.ExecuteNonQuery();
            // 15. soru 
            NpgsqlCommand komut15 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=15;", baglanti);
            komut15.Parameters.AddWithValue("@p1", lbl22.Text);
            komut15.Parameters.AddWithValue("@p2", checkBx15.Checked);
            komut15.Parameters.AddWithValue("@p3", textBx64.Text);
            komut15.Parameters.AddWithValue("@p4", textBx65.Text);
            komut15.ExecuteNonQuery();
            // 2. sayfa 1. soru
            NpgsqlCommand komut16 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=16;", baglanti);
            komut16.Parameters.AddWithValue("@p1", labl5.Text);
            komut16.Parameters.AddWithValue("@p2", chckBx1.Checked);
            komut16.Parameters.AddWithValue("@p3", texBx1.Text);
            komut16.Parameters.AddWithValue("@p4", texBx2.Text);
            komut16.ExecuteNonQuery();
            // 2. sayfa 2. soru
            NpgsqlCommand komut17 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=17;", baglanti);
            komut17.Parameters.AddWithValue("@p1", labl6.Text);
            komut17.Parameters.AddWithValue("@p2", chckBx2.Checked);
            komut17.Parameters.AddWithValue("@p3", texBx3.Text);
            komut17.Parameters.AddWithValue("@p4", texBx4.Text);
            komut17.ExecuteNonQuery();
            // 2. sayfa 3. soru
            NpgsqlCommand komut18 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=18;", baglanti);
            komut18.Parameters.AddWithValue("@p1", labl7.Text);
            komut18.Parameters.AddWithValue("@p2", chckBx3.Checked);
            komut18.Parameters.AddWithValue("@p3", texBx5.Text);
            komut18.Parameters.AddWithValue("@p4", texBx6.Text);
            komut18.ExecuteNonQuery();
            // 2. sayfa 4. soru
            NpgsqlCommand komut19 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=19;", baglanti);
            komut19.Parameters.AddWithValue("@p1", labl8.Text);
            komut19.Parameters.AddWithValue("@p2", chckBx4.Checked);
            komut19.Parameters.AddWithValue("@p3", texBx7.Text);
            komut19.Parameters.AddWithValue("@p4", texBx8.Text);
            komut19.ExecuteNonQuery();
            // 2. sayfa 5. soru
            NpgsqlCommand komut20 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=20;", baglanti);
            komut20.Parameters.AddWithValue("@p1", labl9.Text);
            komut20.Parameters.AddWithValue("@p2", chckBx5.Checked);
            komut20.Parameters.AddWithValue("@p3", texBx9.Text);
            komut20.Parameters.AddWithValue("@p4", texBx10.Text);
            komut20.ExecuteNonQuery();
            // 2. sayfa 6. soru
            NpgsqlCommand komut21 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=21;", baglanti);
            komut21.Parameters.AddWithValue("@p1", labl10.Text);
            komut21.Parameters.AddWithValue("@p2", chckBx6.Checked);
            komut21.Parameters.AddWithValue("@p3", texBx11.Text);
            komut21.Parameters.AddWithValue("@p4", texBx12.Text);
            komut21.ExecuteNonQuery();
            // 2. sayfa 7. soru
            NpgsqlCommand komut22 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=22;", baglanti);
            komut22.Parameters.AddWithValue("@p1", labl11.Text);
            komut22.Parameters.AddWithValue("@p2", chckBx7.Checked);
            komut22.Parameters.AddWithValue("@p3", texBx13.Text);
            komut22.Parameters.AddWithValue("@p4", texBx14.Text);
            komut22.ExecuteNonQuery();
            // 2. sayfa 8. soru
            NpgsqlCommand komut23 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=23;", baglanti);
            komut23.Parameters.AddWithValue("@p1", labl12.Text);
            komut23.Parameters.AddWithValue("@p2", chckBx8.Checked);
            komut23.Parameters.AddWithValue("@p3", texBx15.Text);
            komut23.Parameters.AddWithValue("@p4", texBx16.Text);
            komut23.ExecuteNonQuery();
            // 2. sayfa 9. soru
            NpgsqlCommand komut24 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=24;", baglanti);
            komut24.Parameters.AddWithValue("@p1", labl13.Text);
            komut24.Parameters.AddWithValue("@p2", chckBx9.Checked);
            komut24.Parameters.AddWithValue("@p3", texBx17.Text);
            komut24.Parameters.AddWithValue("@p4", texBx18.Text);
            komut24.ExecuteNonQuery();
            // 2. sayfa 10. soru
            NpgsqlCommand komut25 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=25;", baglanti);
            komut25.Parameters.AddWithValue("@p1", labl14.Text);
            komut25.Parameters.AddWithValue("@p2", chckBx10.Checked);
            komut25.Parameters.AddWithValue("@p3", texBx19.Text);
            komut25.Parameters.AddWithValue("@p4", texBx20.Text);
            komut25.ExecuteNonQuery();
            // 2. sayfa 11. soru
            NpgsqlCommand komut26 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=26;", baglanti);
            komut26.Parameters.AddWithValue("@p1", labl15.Text);
            komut26.Parameters.AddWithValue("@p2", chckBx11.Checked);
            komut26.Parameters.AddWithValue("@p3", texBx21.Text);
            komut26.Parameters.AddWithValue("@p4", texBx22.Text);
            komut26.ExecuteNonQuery();
            // 2. sayfa 12. soru
            NpgsqlCommand komut27 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=27;", baglanti);
            komut27.Parameters.AddWithValue("@p1", labl16.Text);
            komut27.Parameters.AddWithValue("@p2", chckBx12.Checked);
            komut27.Parameters.AddWithValue("@p3", texBx23.Text);
            komut27.Parameters.AddWithValue("@p4", texBx24.Text);
            komut27.ExecuteNonQuery();
            // 2. sayfa 13. soru
            NpgsqlCommand komut28 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=28;", baglanti);
            komut28.Parameters.AddWithValue("@p1", labl17.Text);
            komut28.Parameters.AddWithValue("@p2", chckBx13.Checked);
            komut28.Parameters.AddWithValue("@p3", texBx25.Text);
            komut28.Parameters.AddWithValue("@p4", texBx26.Text);
            komut28.ExecuteNonQuery();
            // 2. sayfa 14. soru
            NpgsqlCommand komut29 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=29;", baglanti);
            komut29.Parameters.AddWithValue("@p1", labl18.Text);
            komut29.Parameters.AddWithValue("@p2", chckBx14.Checked);
            komut29.Parameters.AddWithValue("@p3", texBx27.Text);
            komut29.Parameters.AddWithValue("@p4", texBx28.Text);
            komut29.ExecuteNonQuery();
            // 2. sayfa 15. soru
            NpgsqlCommand komut30 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=30;", baglanti);
            komut30.Parameters.AddWithValue("@p1", labl19.Text);
            komut30.Parameters.AddWithValue("@p2", chckBx15.Checked);
            komut30.Parameters.AddWithValue("@p3", texBx29.Text);
            komut30.Parameters.AddWithValue("@p4", texBx30.Text);
            komut30.ExecuteNonQuery();
            // 2. sayfa 16. soru
            NpgsqlCommand komut31 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=31;", baglanti);
            komut31.Parameters.AddWithValue("@p1", labl20.Text);
            komut31.Parameters.AddWithValue("@p2", chckBx16.Checked);
            komut31.Parameters.AddWithValue("@p3", texBx31.Text);
            komut31.Parameters.AddWithValue("@p4", texBx32.Text);
            komut31.ExecuteNonQuery();
            // 2. sayfa 17. soru
            NpgsqlCommand komut32 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=32;", baglanti);
            komut32.Parameters.AddWithValue("@p1", labl21.Text);
            komut32.Parameters.AddWithValue("@p2", chckBx17.Checked);
            komut32.Parameters.AddWithValue("@p3", texBx33.Text);
            komut32.Parameters.AddWithValue("@p4", texBx34.Text);
            komut32.ExecuteNonQuery();
            // 2. sayfa 18. soru
            NpgsqlCommand komut33 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=33;", baglanti);
            komut33.Parameters.AddWithValue("@p1", labl22.Text);
            komut33.Parameters.AddWithValue("@p2", chckBx18.Checked);
            komut33.Parameters.AddWithValue("@p3", texBx35.Text);
            komut33.Parameters.AddWithValue("@p4", texBx36.Text);
            komut33.ExecuteNonQuery();
            // 2. sayfa 19. soru
            NpgsqlCommand komut34 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=34;", baglanti);
            komut34.Parameters.AddWithValue("@p1", labl23.Text);
            komut34.Parameters.AddWithValue("@p2", chckBx19.Checked);
            komut34.Parameters.AddWithValue("@p3", texBx37.Text);
            komut34.Parameters.AddWithValue("@p4", texBx38.Text);
            komut34.ExecuteNonQuery();
            // 2. sayfa 20. soru
            NpgsqlCommand komut35 = new NpgsqlCommand($"UPDATE checklist SET label_adi=@p1,kontrol=@p2,aciklama_danisman=@p3,aciklama_yuklenici=@p4 WHERE soru_id=35;", baglanti);
            komut35.Parameters.AddWithValue("@p1", labl24.Text);
            komut35.Parameters.AddWithValue("@p2", chckBx20.Checked);
            komut35.Parameters.AddWithValue("@p3", texBx39.Text);
            komut35.Parameters.AddWithValue("@p4", texBx40.Text);
            komut35.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Onay Kopyası Talep Edildi");

        }


    }
    }

