namespace Projekt_Sklep.Models.WyplatyiSzkody
{
    public class WyplatyiSzkody
    {
        public WyplatyiSzkody() : base() { }

        public WyplatyiSzkody(Guid Id, DateTime DataZgloszenia, int WartoscSzkody, string TypSzkody, bool StatusWyplaty,/*Guid Polisa,*/ Guid Klient)
        {
            this.Id = Id;
            this.DataZgloszenia = DataZgloszenia;
            this.WartoscSzkody = WartoscSzkody;
            this.TypSzkody = TypSzkody;
            this.StatusWyplaty = StatusWyplaty;
            // this.Polisa = Polisa;
            this.Klient = Klient;
        }

        public virtual Guid Id { get; set; }
        public virtual DateTime DataZgloszenia { get; set; }
        public virtual int WartoscSzkody { get; set; }
        public virtual string TypSzkody { get; set; }
       
        public virtual bool StatusWyplaty { get; set; }
        // public virtual Guid Polisa { get; set; }
        public virtual Guid Klient { get; set; }

    }
}
