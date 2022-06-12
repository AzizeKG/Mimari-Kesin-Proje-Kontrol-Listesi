using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Mimari_Kesin_Proje_Kontrol_Listesi
{
    public partial class KullaniciGirisi : System.Windows.Forms.Form
    {
        private UIApplication uiapp;
        private UIDocument uidoc;
        private Autodesk.Revit.ApplicationServices.Application app;
        private Document doc;

        public Kullanici Kullanici { get; set; }
        public int DurumId { get; set; }
        public string Durum { get; set; }
        public string DokumanKodu { get; set; }

        public KullaniciGirisi(ExternalCommandData commandData)
        {
            InitializeComponent();

            uiapp = commandData.Application;
            uidoc = uiapp.ActiveUIDocument;
            app = uiapp.Application;
            doc = uidoc.Document;

            var name = Path.GetFileNameWithoutExtension(doc.PathName);
            var i = name.LastIndexOf('-');
            name = name.Substring(0, i);
            i = name.LastIndexOf('-');
            name = name.Substring(0, i);
            DokumanKodu = name;

            bool dokuman_bulundu = false;
            using (var vt = new Veritabani())
            {
                var oku = vt.Sorgu($"select id, durum from durum where dokuman_kodu='{name}';");

                var reader = oku.ExecuteReader();
                if (reader.Read())
                {
                    DurumId = reader.GetInt32(0);
                    Durum = reader.GetString(1);
                    dokuman_bulundu = true;
                }
            }

            if (dokuman_bulundu == false)
            {
                using (var vt = new Veritabani())
                {
                    var yaz = vt.Sorgu($"INSERT INTO durum (durum, dokuman_kodu) VALUES ('', '{name}');");
                    yaz.ExecuteNonQuery();
                }

                using (var vt = new Veritabani())
                {
                    var oku = vt.Sorgu($"select id, durum from durum where dokuman_kodu='{name}';");
                    var reader = oku.ExecuteReader();
                    reader.Read();
                    DurumId = reader.GetInt32(0);
                    Durum = reader.GetString(1);
                }
            }
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Kullanici = Kullanici.Giris(textBxKullanici.Text, textBxSifre.Text);

            if (Kullanici == null)
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış.");
            }
            else
            {


                Close();
            }
        }

        private void textBxKullanici_Click(object sender, EventArgs e)
        {
            textBxKullanici.Text = "";
        }
    }
    
}
