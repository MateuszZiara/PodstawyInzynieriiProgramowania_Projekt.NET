using Projekt_Sklep.Models.Adres;

namespace Projekt_Sklep.Persistence.Adres
{

    public class AdresService : IAdresService
    {
        readonly AdresRepository _repository = new AdresRepository();

        public bool edit(Guid id, string kodPocztowy, string miasto, string wojewodztwo, string panstwo)
        {
          return  _repository.edit(id, kodPocztowy, miasto, wojewodztwo, panstwo);
        }
    }
}
