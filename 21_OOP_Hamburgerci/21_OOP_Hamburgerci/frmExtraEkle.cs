using _21_OOP_Hamburgerci.Helpers;
using System;
using System.Windows.Forms;

namespace _21_OOP_Hamburgerci
{
    public partial class frmExtraEkle : Form
    {
        public frmExtraEkle()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            frmSiparisOlustur.extralar.Add(new Models.Extra { ExtraAdi = txtExtradi.Text, Fiyat = nmrFiyat.Value });
            Tools.Clean(this.Controls);
            MessageBox.Show("Extra ekleme işlemi başarılı!...");
        }
    }
}
