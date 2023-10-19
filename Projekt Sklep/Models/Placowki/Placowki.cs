using System.Text.RegularExpressions;

namespace Projekt_Sklep.Models.Placowki
{
    public class Placowki
    {
        public Placowki() : base() { }

        public Placowki(Guid Id, int NrPlacowki , string NIP, Guid Adres)
        {
            this.Id = Id;
            this.NrPlacowki = NrPlacowki;
            this.NIP = NIP;
            this.Adres = Adres;
        }

        public virtual Guid Id { get; set; }
        public virtual int NrPlacowki { get; set; }
        public virtual string NIP { get; set; }
        public virtual Guid Adres { get; set; }
        
    }
}

