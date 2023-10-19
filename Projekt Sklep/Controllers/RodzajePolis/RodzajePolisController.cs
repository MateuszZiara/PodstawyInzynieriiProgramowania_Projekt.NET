using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Models.Klient;
using Projekt_Sklep.Models;

namespace Projekt_Sklep.Controllers.RodzajePolis
{
    [Route("api/[controller]")]
    [ApiController]
    public class RodzajePolisController : ControllerBase
    {

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

    }
}
