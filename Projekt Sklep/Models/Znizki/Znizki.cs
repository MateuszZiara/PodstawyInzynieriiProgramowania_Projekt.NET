namespace Projekt_Sklep.Models.Znizki
{
    public class Znizki
    {
        public Znizki () : base () { }
        
        public Znizki (Guid Id, string Dorosly_dziecko, bool Wiek)
        {
            this.Id = Id;
            this.Dorosly_dziecko = Dorosly_dziecko;
            this.Wiek = Wiek;
        }
        
        public virtual Guid Id {  get; set; }
        public virtual string Dorosly_dziecko {  get; set; }
        public virtual bool Wiek { get; set; } // true > 26, false < 26
    }
}
