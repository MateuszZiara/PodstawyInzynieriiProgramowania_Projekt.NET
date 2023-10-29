using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Models.Polisy;
using Projekt_Sklep.Models;
using Projekt_Sklep.Persistence.Polisy;

namespace Projekt_Sklep.Controllers.Polisy
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolisyController : ControllerBase
    {
        readonly PolisyService polisyService = new PolisyService();
        [HttpGet]
        public ActionResult<IEnumerable<Models.Polisy.Polisy>> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var klientEntities = session.Query<Models.Polisy.Polisy>().ToList();
                return Ok(klientEntities);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Models.Polisy.Polisy> GetById(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var klientEntity = session.Get<Models.Polisy.Polisy>(id);

                if (klientEntity == null)
                {
                    return NotFound();
                }

                return Ok(klientEntity);
            }

        }
        [HttpPost]
        public ActionResult<Models.Polisy.Polisy> CreateKlientEntity([FromBody] Models.Polisy.Polisy polisy)
        {
            if (polisy == null)
            {
                return BadRequest("Invalid data");
            }
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(polisy);
                        transaction.Commit();
                        return CreatedAtAction(nameof(GetById), new { id = polisy.Id }, polisy);
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
        public ActionResult DeletePolisy(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var polisy = session.Get<Models.Polisy.Polisy>(id);

                        if (polisy == null)
                        {
                            return NotFound();
                        }


                        session.Delete(polisy);


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
        [HttpGet("czyAktywna/{id}")]
        public bool czyAktywna(Guid id)
        {
            return polisyService.czyAktywna(id);
        }
    }

}
