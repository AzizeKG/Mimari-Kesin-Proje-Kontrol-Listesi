using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimari_Kesin_Proje_Kontrol_Listesi
{
    public class Kullanici
    {
        public string Adi { get; set; }
        public string Sifre { get; set; }
        public UserRole Rol { get; set; }

        public static Kullanici Giris(string adi, string sifre)
        {
            List<Kullanici> listesi = new List<Kullanici>();
            listesi.Add(new Kullanici { Adi = "Danışman", Sifre = "1234", Rol = UserRole.Danisman });
            listesi.Add(new Kullanici { Adi = "İşveren", Sifre = "1234", Rol = UserRole.Isveren });
            listesi.Add(new Kullanici { Adi = "Yüklenici", Sifre = "1234", Rol = UserRole.Yuklenici });

            foreach (var item in listesi)
            {
                if (item.Sifre == sifre && item.Adi == adi)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
