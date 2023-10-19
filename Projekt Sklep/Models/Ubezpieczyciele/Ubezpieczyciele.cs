namespace Projekt_Sklep.Models.Ubezpieczyciele
{
    public class Ubezpieczyciele
    {
        public Ubezpieczyciele() : base() { }
        public Ubezpieczyciele(Guid Id, string Nazwisko, string Email, string Phone, string OsobaKontaktowa, string NazwaFirmy, Guid Placowka)
        {
            this.Id = Id;
            this.Nazwisko = Nazwisko;
            this.Email = Email;
            this.Phone = Phone;
            this.OsobaKontaktowa = OsobaKontaktowa;
            this.NazwaFirmy = NazwaFirmy;
            this.Placowki = Placowka;
        }
        public virtual Guid Id { get; set; }
        public virtual string Nazwisko { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        public virtual string OsobaKontaktowa { get; set;}
        public virtual string NazwaFirmy { get; set;}
        public virtual Guid Placowki { get; set;}
       
    }
}
