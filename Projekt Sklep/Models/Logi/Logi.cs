namespace Projekt_Sklep.Models.Logi
{
    public class Logi
    {
        public Logi() : base() { }

        public Logi(Guid Id, DateTime DataZdarzenia, string OpisZdarzenia,/*Guid Polisa,*/ Guid Klient, Guid WyplataiSzkoda, Guid Ubezpieczyciele)
        {
            this.Id = Id;
            this.DataZdarzenia = DataZdarzenia;
            this.OpisZdarzenia = OpisZdarzenia;
            // this.Polisa = Polisa;
            this.Klient = Klient;
            this.WyplataiSzkoda = WyplataiSzkoda;
            this.Ubezpieczyciele = Ubezpieczyciele;
        }

        public virtual Guid Id { get; set; }
        public virtual DateTime DataZdarzenia { get; set; }
        public virtual string OpisZdarzenia { get; set; }

        // public virtual Guid Polisa { get; set; }
        public virtual Guid Klient { get; set; } 
        public virtual Guid WyplataiSzkoda { get; set; }
        public virtual Guid Ubezpieczyciele { get; set; }


    }
}
