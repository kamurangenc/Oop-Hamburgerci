using _21_OOP_Hamburgerci.Helpers;
using _21_OOP_Hamburgerci.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using M = _21_OOP_Hamburgerci.Models;

namespace _21_OOP_Hamburgerci
{
    public partial class frmSiparisOlustur : Form
    {
        public frmSiparisOlustur()
        {
            InitializeComponent();
        }

        public static List<Siparis> siparisler = new List<Siparis>();

        private List<Siparis> mevcutSiparisler = new List<Siparis>();

        public static List<M.Menu> menuler = new List<M.Menu>
        {
            new M.Menu{ MenuAdi = "Kral Burger",Fiyat = 30.00M },
            new M.Menu{ MenuAdi = "Mc Fish",Fiyat = 25.00M },
            new M.Menu{ MenuAdi = "King Chicken",Fiyat = 26.00M },
            new M.Menu{ MenuAdi = "Steak House",Fiyat = 35.00M },
            new M.Menu{ MenuAdi = "Kasap Burger",Fiyat = 28.00M },
            new M.Menu{ MenuAdi = "Anadolu Burger",Fiyat = 32.00M },
            new M.Menu{ MenuAdi = "Mexico Burger",Fiyat = 29.00M },
            new M.Menu{ MenuAdi = "Happy Meal",Fiyat = 18.00M },
            new M.Menu{ MenuAdi = "Chicken Royal Meal",Fiyat = 22.00M },
            new M.Menu{ MenuAdi = "Big King",Fiyat = 25.00M }
        };

        public static List<M.Extra> extralar = new List<M.Extra>
        {
            new M.Extra{ ExtraAdi = "Ketçap",Fiyat = 1.00M },
            new M.Extra{ ExtraAdi = "Mayonez",Fiyat = 1.00M },
            new M.Extra{ ExtraAdi = "Acı Sos",Fiyat = 1.00M },
            new M.Extra{ ExtraAdi = "Sarımsaklı Mayonez",Fiyat = 1.25M },
            new M.Extra{ ExtraAdi = "Ranch Sos",Fiyat = 1.50M },
            new M.Extra{ ExtraAdi = "Bufalo Sos",Fiyat = 2.00M },
            new M.Extra{ ExtraAdi = "Barbekü Sos",Fiyat = 2.00M },
            new M.Extra{ ExtraAdi = "Hardal",Fiyat = 1.50M }
        };

        private void frmSiparisOlustur_Load(object sender, EventArgs e)
        {
            cmbMenuler.Items.AddRange(menuler.ToArray());

            foreach (M.Extra ex in extralar)
                flpExtralar.Controls.Add(new CheckBox { Text = ex.ExtraAdi, Tag = ex });
        }

        private void btnSiparisEkle_Click(object sender, EventArgs e)
        {
            Siparis siparis = new Siparis();
            siparis.Menu = (M.Menu)cmbMenuler.SelectedItem;

            if (rbKucuk.Checked)
                siparis.Boyut = Enums.Boyut.Küçük;
            else if (rbOrta.Checked)
                siparis.Boyut = Enums.Boyut.Normal;
            else
                siparis.Boyut = Enums.Boyut.Büyük;

            foreach (CheckBox item in flpExtralar.Controls)
                if (item.Checked)
                    siparis.Extralar.Add(item.Tag as Extra);

            siparis.Adet = (int)nmrAdet.Value;
            siparis.Hesapla();


            mevcutSiparisler.Add(siparis);
            lstSiparisler.Items.Add(siparis);

            TutarHesapla();

            Tools.Clean(this.Controls);

        }

        private decimal TutarHesapla()
        {
            decimal toplamTutar = 0;
            for (int i = 0; i < lstSiparisler.Items.Count; i++)
            {
                Siparis siparis = lstSiparisler.Items[i] as Siparis;
                toplamTutar += siparis.ToplamTutar;
            }
            lblToplamTutar.Text = toplamTutar.ToString("C2");
            return toplamTutar;
        }

        private void btnSiparisTamamla_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"Toplam sipariş tutarı: {TutarHesapla().ToString("C2")}, Satınalmayı tamamlamak istermisiniz?","Sipariş Onay Bildirimi!...",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                siparisler.AddRange(mevcutSiparisler);
                mevcutSiparisler.Clear();
                lstSiparisler.Items.Clear();
                lblToplamTutar.Text = "0 TL";
                MessageBox.Show("Siparişiniz Tamamlandı!...");
                Tools.Clean(this.Controls);
            }
        }
    }
}
