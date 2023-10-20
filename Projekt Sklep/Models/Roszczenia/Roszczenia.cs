namespace Projekt_Sklep.Models.Roszczenia
{
    public class Roszczenia
    {
        public Roszczenia() : base() { }

        public Roszczenia(Guid Id,string Opis,RoszczeniaEnum StanRoszczenia, Guid Ubezpieczyciele, Guid Klient, Guid Polisa, Guid WyplatyiSzkody, byte[] Zalacznik)
        {
            this.Id = Id;
            this.Opis = Opis;
            this.StanRoszczenia = StanRoszczenia;
            this.Ubezpieczyciele = Ubezpieczyciele;
            this.Klient = Klient;
            this.Polisa = Polisa;
            this.WyplatyiSzkody = WyplatyiSzkody;
            this.Zalacznik = Zalacznik;
        }

        public virtual Guid Id { get; set; }
        public virtual string Opis { get; set; }
        public virtual RoszczeniaEnum StanRoszczenia { get; set; }
        public virtual Guid Ubezpieczyciele { get; set; }
        public virtual Guid Klient { get; set; }
        public virtual Guid Polisa { get; set; }
        public virtual Guid WyplatyiSzkody { get; set; }
        public virtual byte[] Zalacznik { get; set; }


    }
}
