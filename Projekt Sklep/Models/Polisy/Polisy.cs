namespace Projekt_Sklep.Models.Polisy
{
    public class Polisy
    {
        public Polisy() : base()
        { }
        public Polisy(Guid Id, DateTime DataRozpoczecia, DateTime DataZakonczenia, double Cena, Guid Klient, Guid RodzajePolis, Guid Ubezpieczyciele, Guid Znizki)
        {
            this.Id = Id;
            this.DataRozpoczecia = DataRozpoczecia;
            this.DataZakonczenia = DataZakonczenia;
            this.Cena = Cena;
            this.Klient = Klient;
            this.RodzajePolis = RodzajePolis;
            this.Ubezpieczyciele = Ubezpieczyciele;
            this.Znizki = Znizki;

        }

        public virtual Guid Id { get; set; }
        public virtual DateTime DataRozpoczecia { get; set; }
        public virtual DateTime DataZakonczenia { get; set; }
        public virtual double Cena { get; set; }
        public virtual Guid Klient { get; set; }
        public virtual Guid RodzajePolis { get; set; }
        public virtual Guid Ubezpieczyciele { get; set; }
        public virtual Guid Znizki { get; set; }

    }
}
