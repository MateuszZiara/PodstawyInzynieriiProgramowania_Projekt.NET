using System.ComponentModel.DataAnnotations;

namespace Projekt_Sklep.Models.Pojazdy
{
    public class Pojazdy
    {
        public Pojazdy() : base() { }

        public Pojazdy(Guid Id, string NrRejestracyjny, string Marka, string Model, int Rocznik, string VIN, bool Uszkodzony, Guid Klient)
        {
            this.Id = Id;
            this.NrRejestracyjny = NrRejestracyjny;
            this.Marka = Marka;
            this.Model = Model;
            this.Rocznik = Rocznik;
            this.VIN = VIN;
            this.Uszkodzony = Uszkodzony;
            this.Klient = Klient;
        }

        public virtual Guid Id { get; set; }
        public virtual string NrRejestracyjny { get; set; }
        public virtual string Marka { get; set; }
        public virtual string Model { get; set; }
        public virtual int Rocznik { get; set; }
        public virtual string VIN { get; set; }
        public virtual bool Uszkodzony { get; set; }
        public virtual Guid Klient { get; set; }

    }
}
