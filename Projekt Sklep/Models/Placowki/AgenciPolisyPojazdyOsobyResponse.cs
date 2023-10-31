namespace Projekt_Sklep.Models.Placowki
{ 
    public class AgenciPolisyPojazdyOsobyResponse
    {
        public List<Ubezpieczyciele.Ubezpieczyciele> UbezpieczycieleList { get; set; }
        public List<Polisy.Polisy> PolisyList { get; set; }
        public List<Pojazdy.Pojazdy> PojazdyList { get; set; }
        public List<Klient.KlientEntity> KlientList { get; set; }
    }
}
