using _21_OOP_Hamburgerci.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21_OOP_Hamburgerci
{
    public partial class frmHamburgerEkle : Form
    {
        public frmHamburgerEkle()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            frmSiparisOlustur.menuler.Add(new Models.Menu { MenuAdi = txtMenuAdi.Text, Fiyat = nmrFiyat.Value });
            Tools.Clean(this.Controls);
            MessageBox.Show("Menü ekleme işlemi başarılı!...");
        }
    }
}
