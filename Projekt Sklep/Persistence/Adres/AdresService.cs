using Projekt_Sklep.Models.Adres;
using System.Text.RegularExpressions;

namespace Projekt_Sklep.Persistence.Adres
{

    public class AdresService : IAdresService
    {
        readonly AdresRepository _repository = new AdresRepository();

        public bool edit(Guid id, string kodPocztowy, string miasto, string wojewodztwo, string panstwo)
        {
          return  _repository.edit(id, kodPocztowy, miasto, wojewodztwo, panstwo);
        }

        void IAdresService.PostalCodeCheck(string kodPocztowy)
        {
            Regex regex = new Regex(@"^\d{2}-\d{3}$");
            Match match = regex.Match(kodPocztowy);
            if (match.Success)
            {

            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
