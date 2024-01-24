using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Projekt_Sklep.Pages
{
    public class Wybor_PolisyModel : PageModel
    {
        private readonly ILogger<Wybor_PolisyModel> _logger;

        public Wybor_PolisyModel(ILogger<Wybor_PolisyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string policyType, string additionalData)
        {
            PolicyType = policyType;
            AdditionalData = additionalData;

            _logger.LogInformation($"PolicyType: {PolicyType}, AdditionalData: {AdditionalData}");
        }

        public string PolicyType { get; set; }
        public string AdditionalData { get; set; }
    }
}