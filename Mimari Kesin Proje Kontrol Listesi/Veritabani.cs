using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimari_Kesin_Proje_Kontrol_Listesi
{
    internal class Veritabani : IDisposable
    {
        public NpgsqlConnection Baglanti { get; private set; }

        public Veritabani()
        {
            Baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=dbchecklist; user Id=postgres; password=1");
            Baglanti.Open();
        }

        public NpgsqlCommand Sorgu(string sorgu) {
            return new NpgsqlCommand(sorgu, Baglanti);
        }                                

        public void Dispose()
        {
            Baglanti.Close();
        }
    }
}
