using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Forms;

namespace Mimari_Kesin_Proje_Kontrol_Listesi
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]

    public class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            KullaniciGirisi girisFormu = new KullaniciGirisi(commandData);
            girisFormu.ShowDialog();
            var kullanici = girisFormu.Kullanici;
            var durum_id = girisFormu.DurumId;
            var durum = girisFormu.Durum;
            var dokuman_kodu = girisFormu.DokumanKodu;

            if (kullanici.Rol == UserRole.Yuklenici && durum == "")
            {
                var form = new FormY_1(commandData);
                form.DurumId = durum_id;
                form.DokumanKodu = dokuman_kodu;
                form.ShowDialog();
            }
            if (kullanici.Rol == UserRole.Danisman && durum == "R")
            {
                var form = new VeriGirisiM1(commandData);
                form.DurumId = durum_id;
                form.DokumanKodu = dokuman_kodu;
                form.ShowDialog();
            }
            if (kullanici.Rol == UserRole.Yuklenici && durum == "RT")
            {
                var form = new VeriGirisiY2(commandData);
                form.DurumId = durum_id;
                form.DokumanKodu = dokuman_kodu;
                form.ShowDialog();
            }
            if (kullanici.Rol == UserRole.Danisman && durum == "RM")
            {
                var form = new VeriGirisiM2(commandData);
                form.DurumId = durum_id;
                form.DokumanKodu = dokuman_kodu;
                form.ShowDialog();
            }
            if (kullanici.Rol == UserRole.Yuklenici && durum == "OK")
            {
                var form = new FormY_3(commandData);
                form.DurumId = durum_id;
                form.DokumanKodu = dokuman_kodu;
                form.ShowDialog();
            }
            if (kullanici.Rol == UserRole.Isveren && durum == "O")
            {
                var form = new VeriGirisiI1(commandData);
                form.DurumId = durum_id;
                form.DokumanKodu = dokuman_kodu;
                form.ShowDialog();
            }
            if (kullanici.Rol == UserRole.Danisman && durum == "ONAY")
            {
                var form = new FormG_1(commandData);
                form.DurumId = durum_id;
                form.DokumanKodu = dokuman_kodu;
                form.ShowDialog();
            }
            if (kullanici.Rol == UserRole.Yuklenici && durum == "ONAY")
            {
                var form = new FormG_1(commandData);
                form.DurumId = durum_id;
                form.DokumanKodu = dokuman_kodu;
                form.ShowDialog();
            }




            return Result.Succeeded;
        }
    }
}
