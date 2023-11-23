namespace Projekt_Sklep.Models.WyplatyiSzkody
{
    public interface IWyplatyiSzkodyService
    {

        public bool edit(Guid Id,DateTime DataZgloszenia, int WartoscSzkody, string TypSzkody, bool StatusWyplaty, Guid Klient);


    

    }
}
