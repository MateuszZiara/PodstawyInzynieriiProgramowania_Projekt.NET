using System.Runtime.CompilerServices;

namespace Projekt_Sklep.Models.RodzajePolis
{
    public class RodzajePolis
    {

        public RodzajePolis() : base() { }

        public RodzajePolis(Guid Id, Enum Rodzaj, DateTime DataRozpoczecia, DateTime DataZakonczenia, int CenaPodstawowa)
        {
            this.Id = Id;
            this.Rodzaj = Rodzaj;
            this.DataRozpoczecia = DataRozpoczecia;
            this.DataZakonczenia = DataZakonczenia;
            this.CenaPodstawowa = CenaPodstawowa;
        }


        public virtual Guid Id { get; set; }
        public virtual Enum Rodzaj { get; set; }
        public virtual DateTime DataRozpoczecia { get; set; }
        public virtual DateTime DataZakonczenia { get; set; }

        public virtual int CenaPodstawowa { get; set; }
    }
}
