namespace Projekt_Sklep.Models.Wiadomosci
{
    public class Wiadomosci
    {

        public Wiadomosci() : base() { }

        /*LMK gdyby ktoś miał lepszy pomysł na rozwiązanie kwestii określania kto jest odbiorcą, a kto nadawcą. 
         * Ja to widzę tak, że określamy pierw czy dostac ma to klient czy inny ubezpieczyciel, a następnie określamy która to ma być osoba z danej grupy*/
        public Wiadomosci(Guid Id, bool Odczytane, DateTime DataWyslania, string Wiadomosc, WiadomosciEnum Nadawca, WiadomosciEnum Odbiorca, Guid Klient, Guid Ubezpieczyciele, string ParentMessage)
        {
            this.Id = Id;
            this.Odczytane = Odczytane;
            this.DataWyslania= DataWyslania;
            this.Wiadomosc= Wiadomosc;
            this.Nadawca= Nadawca;
            this.Odbiorca= Odbiorca;
            this.Klient= Klient;   
            this.Ubezpieczyciele= Ubezpieczyciele;  
            this.ParentMessage= ParentMessage;
        }

        public virtual Guid Id { get; set; }
        public virtual bool Odczytane { get; set; }
        public virtual DateTime DataWyslania { get; set; }
        public virtual string Wiadomosc { get; set; }
        public virtual WiadomosciEnum Nadawca { get; set; }
        public virtual WiadomosciEnum Odbiorca { get; set; }
        public virtual Guid Klient { get; set; }
        public virtual Guid Ubezpieczyciele { get; set; }
        public virtual string ParentMessage { get; set;}

    }
}

