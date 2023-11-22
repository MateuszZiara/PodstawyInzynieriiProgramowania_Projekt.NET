using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Models;
using Projekt_Sklep.Models.Ubezpieczyciele;
using Projekt_Sklep.Persistence.Placowki;
using Projekt_Sklep.Persistence.Ubezpieczyciele;

namespace Projekt_Sklep.Controllers.Ubezpieczyciele
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbezpieczycieleController : ControllerBase
    {

        UbezpieczycieleService ubezpieczycieleService = new UbezpieczycieleService();

        [HttpGet]
        public ActionResult<IEnumerable<Models.Ubezpieczyciele.Ubezpieczyciele>> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var x = session.Query<Models.Ubezpieczyciele.Ubezpieczyciele>().ToList();
                return Ok(x);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Models.Ubezpieczyciele.Ubezpieczyciele> GetById(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var x = session.Get<Models.Ubezpieczyciele.Ubezpieczyciele>(id);

                if (x == null)
                {
                    return NotFound();
                }

                return Ok(x);
            }

        }
        [HttpPost]
        public ActionResult<Models.Ubezpieczyciele.Ubezpieczyciele> CreateKlientEntity([FromBody] Models.Ubezpieczyciele.Ubezpieczyciele x)
        {
            if (x == null)
            {
                return BadRequest("Invalid data");
            }
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(x);
                        transaction.Commit();
                        return CreatedAtAction(nameof(GetById), new { id = x.Id }, x);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
                    }
                }
            }

        }
        [HttpDelete("{id}")]
        public ActionResult DeleteKlientEntity(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var x = session.Get<Models.Ubezpieczyciele.Ubezpieczyciele>(id);

                        if (x == null)
                        {
                            return NotFound();
                        }


                        session.Delete(x);


                        transaction.Commit();

                        return NoContent();
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                        return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
                    }
                }
            }
        }

        //Funkcje własne
        [HttpPost("Edit/{Id}")]
        public bool EditUbezpieczyciele(Guid Id, string Nazwisko = null, string Email = null, string Phone = null, string OsobaKontaktowa = null, string NazwaFirmy = null, Guid? Placowki = null)
        {
            Guid guid = Guid.NewGuid();
            if (Placowki == null)
            {

                guid = Guid.Empty;
            }
            else
                guid = Placowki.Value;
            return ubezpieczycieleService.edit(Id, Nazwisko, Email, Phone, OsobaKontaktowa, NazwaFirmy, guid);

        }

    }
}
