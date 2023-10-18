using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Models.Klient;
using Projekt_Sklep.Models;
using Projekt_Sklep.Persistence.Znizki;
using Projekt_Sklep.Models.Znizki;

namespace Projekt_Sklep.Controllers.Znizki
{

    [Route("api/[controller]")]
    [ApiController]
    public class ZnizkiController : ControllerBase
    {
        readonly ZnizkiService znizkiService;
        [HttpGet]
        public ActionResult<IEnumerable<Models.Znizki.Znizki>> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var ZnizkiEntities = session.Query<Models.Znizki.Znizki>().ToList();
                return Ok(ZnizkiEntities);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Models.Znizki.Znizki> GetById(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var ZnizkiEntities = session.Get<Models.Znizki.Znizki>(id);

                if (ZnizkiEntities == null)
                {
                    return NotFound();
                }

                return Ok(ZnizkiEntities);
            }

        }

        [HttpPost]
        public ActionResult<Models.Znizki.Znizki> CreateKlientEntity([FromBody] Models.Znizki.Znizki znizki)
        {
            if (znizki == null)
            {
                return BadRequest("Invalid data");
            }
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(znizki);
                        transaction.Commit();
                        return CreatedAtAction(nameof(GetById), new { id = znizki.Id }, znizki);
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
                        var znizki = session.Get<Models.Znizki.Znizki>(id);

                        if (znizki == null)
                        {
                            return NotFound();
                        }


                        session.Delete(znizki);


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
