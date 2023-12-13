using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Models;
using Projekt_Sklep.Models.Klient;
using Projekt_Sklep.Models.Placowki;
using Projekt_Sklep.Persistence.Placowki;

namespace Projekt_Sklep.Controllers.Wiadomosci
{
    [Route("api/[controller]")]
    [ApiController]
    public class WiadomosciController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Models.Wiadomosci.Wiadomosci>> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var klientEntities = session.Query<Models.Wiadomosci.Wiadomosci>().ToList();
                return Ok(klientEntities);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Models.Wiadomosci.Wiadomosci> GetById(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var wiadomosc = session.Get<Models.Wiadomosci.Wiadomosci>(id);

                if (wiadomosc == null)
                {
                    return NotFound();
                }

                return Ok(wiadomosc);
            }

        }

        [HttpPost]
        public ActionResult<Models.Wiadomosci.Wiadomosci> CreateWiadomosc([FromBody] Models.Wiadomosci.Wiadomosci wiadomosci)
        {
            if (wiadomosci == null)
            {
                return BadRequest("Invalid data");
            }
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(wiadomosci);
                        transaction.Commit();
                        return CreatedAtAction(nameof(GetById), new { id = wiadomosci.Id }, wiadomosci);
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
        public ActionResult DeleteWiadomosc(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var wiadomosc = session.Get<Models.Wiadomosci.Wiadomosci>(id);

                        if (wiadomosc == null)
                        {
                            return NotFound();
                        }


                        session.Delete(wiadomosc);


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
