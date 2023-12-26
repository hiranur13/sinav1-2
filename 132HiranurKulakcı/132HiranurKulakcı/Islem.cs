using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _132HiranurKulakcı
{
    internal class Islem
    {
        int id;
        string tanim;
        DateTime tarih;
        string tur;
        int miktar;
        bool gelir;

        public int Id { get => id; set => id = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public string Tur { get => tur; set => tur = value; }
        public int Miktar { get => miktar; set => miktar = value; }
        public bool Gelir { get => gelir; set => gelir = value; }

        public Islem(int id, string tanim, DateTime tarih, string tur, int miktar, bool gelir)
        {
            this.id = id;
            this.tanim = tanim;
            this.tarih = tarih;
            this.tur = tur;
            this.miktar = miktar;
            this.gelir = gelir;
        }
    }
}
