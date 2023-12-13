using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Models;
using Projekt_Sklep.Models.Adres;
using Projekt_Sklep.Models.Klient;
using Projekt_Sklep.Persistence.Adres;
using Projekt_Sklep.Persistence.Klient;

namespace Projekt_Sklep.Controllers.Adres
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdresController : ControllerBase
    {
        readonly AdresService adresService = new AdresService();

        [HttpGet]
        public ActionResult<IEnumerable<Models.Adres.Adres>> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var Adres = session.Query<Models.Adres.Adres>().ToList();
                return Ok(Adres);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Models.Adres.Adres> GetById(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var Adres = session.Get<Models.Adres.Adres>(id);

                if (Adres == null)
                {
                    return NotFound();
                }

                return Ok(Adres);
            }

        }
        [HttpPost]
        public ActionResult<Models.Adres.Adres> CreateAdresEntity([FromBody] Models.Adres.Adres Adres)
        {
            if (Adres == null)
            {
                return BadRequest("Invalid data");
            }
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(Adres);
                        transaction.Commit();
                        return CreatedAtAction(nameof(GetById), new { id = Adres.Id }, Adres);
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
        public ActionResult DeleteAdresEntity(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var adres = session.Get<Models.Adres.Adres>(id);

                        if (adres == null)
                        {
                            return NotFound();
                        }


                        session.Delete(adres);


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
        [HttpPost("Edit/{id}")]
        public bool EditAdresEntity(Guid id, string kodPocztowy = null, string miasto = null, string wojewodztwo = null, string panstwo = null)
        {
           
            return adresService.edit(id, kodPocztowy, miasto, wojewodztwo, panstwo);
        }
    }
}
