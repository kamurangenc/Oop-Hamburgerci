namespace _21_OOP_Hamburgerci.Models
{
    public class Menu
    {
        public string MenuAdi { get; set; }
        public decimal Fiyat { get; set; }

        public override string ToString()
        {
            return this.MenuAdi + " Menü";
        }
    }
}
