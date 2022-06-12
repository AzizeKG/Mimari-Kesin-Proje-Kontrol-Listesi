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
    public partial class FormY_1 : System.Windows.Forms.Form
    {

        private UIApplication uiapp;
        private UIDocument uidoc;
        private Autodesk.Revit.ApplicationServices.Application app;
        private Document doc;
        private object excelApplicationObject;
        private object path;

        public int DurumId { get; set; }
        public string DokumanKodu { get; set; }

        public FormY_1(ExternalCommandData commandData)
        {
            InitializeComponent();
            uiapp = commandData.Application;
            uidoc = uiapp.ActiveUIDocument;
            app = uiapp.Application;
            doc = uidoc.Document;
        }

        private void btnKontrol_Click(object sender, EventArgs e)
        {
            using (Veritabani vt = new Veritabani())
            {
                var yaz = vt.Sorgu($"UPDATE durum SET durum='R' WHERE id={DurumId};");
                yaz.ExecuteNonQuery();
            }
            Close();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
