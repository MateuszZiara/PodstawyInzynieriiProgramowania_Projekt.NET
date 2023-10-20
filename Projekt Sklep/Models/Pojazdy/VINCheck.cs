using Projekt_Sklep.Models.Placowki;
using System.Text.RegularExpressions;

namespace Projekt_Sklep.Models.Pojazdy
{
    public class VINCheck : IPojazdyService
    {
        void IPojazdyService.VINCheck(string VIN)
        {
            Regex regex = new Regex(@"^[A-HJ-NPR-Z0-9]{17}$");
            Match match = regex.Match(VIN);
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
