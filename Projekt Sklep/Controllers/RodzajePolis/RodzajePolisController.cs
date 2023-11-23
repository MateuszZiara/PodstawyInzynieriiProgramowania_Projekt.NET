using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Models.Klient;
using Projekt_Sklep.Models;
using Projekt_Sklep.Persistence.Pojazdy;
using System.ComponentModel.DataAnnotations;
using Projekt_Sklep.Models.RodzajePolis;
using Projekt_Sklep.Persistence.RodzajePolis;

namespace Projekt_Sklep.Controllers.RodzajePolis
{
    [Route("api/[controller]")]
    [ApiController]
    public class RodzajePolisController : ControllerBase
    {

        readonly RodzajePolisService rodzajePolisService = new RodzajePolisService();  
        [HttpGet]
        public ActionResult<IEnumerable<Models.RodzajePolis.RodzajePolis>> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var RodzajePolis = session.Query<Models.RodzajePolis.RodzajePolis>().ToList();
                return Ok(RodzajePolis);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Models.RodzajePolis.RodzajePolis> GetById(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var rodzaje = session.Get<Models.RodzajePolis.RodzajePolis>(id);

                if (rodzaje == null)
                {
                    return NotFound();
                }

                return Ok(rodzaje);
            }

        }

        [HttpPost]
        public ActionResult<Models.RodzajePolis.RodzajePolis> CreateKlientEntity([FromBody] Models.RodzajePolis.RodzajePolis rodzaje)
        {
            if (rodzaje == null)
            {
                return BadRequest("Invalid data");
            }
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(rodzaje);
                        transaction.Commit();
                        return CreatedAtAction(nameof(GetById), new { id = rodzaje.Id }, rodzaje);
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
                        var rodzaje = session.Get<Models.RodzajePolis.RodzajePolis>(id);

                        if (rodzaje == null)
                        {
                            return NotFound();
                        }


                        session.Delete(rodzaje);


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
        public bool EditRodzajePolis(Guid Id, RodzajePolisEnum Rodzaj, DateTime DataRozpoczecia, DateTime DataZakonczenia, int CenaPodstawowa = -1)
        {

            return rodzajePolisService.edit(Id, Rodzaj, DataRozpoczecia, DataZakonczenia, CenaPodstawowa);

        }

    }
}
