using _21_OOP_Hamburgerci.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_OOP_Hamburgerci.Models
{
    public class Siparis
    {
        public Siparis()
        {
            Extralar = new List<Extra>();
        }
        public Menu Menu { get; set; }
        public Boyut Boyut { get; set; }
        public List<Extra> Extralar { get; set; }
        public int Adet { get; set; }
        public decimal ToplamTutar { get; set; }

        public void Hesapla()
        {
            this.ToplamTutar = 0;
            this.ToplamTutar += Menu.Fiyat;
            switch (Boyut)
            {
                case Boyut.Normal:
                    this.ToplamTutar += this.ToplamTutar * 0.10M;
                    break;
                case Boyut.Büyük:
                    this.ToplamTutar += this.ToplamTutar * 0.20M;
                    break;
            }
            foreach(Extra extra in Extralar)
                this.ToplamTutar += extra.Fiyat;

            this.ToplamTutar = this.ToplamTutar * Adet;
        }

        public override string ToString()
        {
            if (Extralar.Count < 1)
            {
                return string.Format("{0} Menü, X {1} Adet, {2} Boy, Toplam: {3}",
                    Menu.MenuAdi,
                    Adet,
                    Boyut.ToString(),
                    ToplamTutar.ToString("C2"));
            }
            else
            {
                string extraMalzemeler = "";
                foreach (Extra extra in Extralar)
                    extraMalzemeler += extra.ExtraAdi + ",";

                extraMalzemeler = extraMalzemeler.Trim(',');

                return string.Format("{0} Menü, X {1} Adet, {2} Boy, Ex: {3}, Toplam: {4}",
                    Menu.MenuAdi,
                    Adet,
                    Boyut.ToString(),
                    extraMalzemeler,
                    ToplamTutar.ToString("C2"));
            }
        }
    }
}
