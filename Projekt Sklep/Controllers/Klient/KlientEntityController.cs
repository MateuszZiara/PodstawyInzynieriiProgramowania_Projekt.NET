using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Models;
using Projekt_Sklep.Models.Klient;
using Projekt_Sklep.Persistence.Klient;

namespace Projekt_Sklep.Controllers.Klient
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlientEntityController : ControllerBase
    {
        readonly KlientEntityService klientEntityService;
        [HttpGet]
        public ActionResult<IEnumerable<KlientEntity>> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var klientEntities = session.Query<KlientEntity>().ToList();
                return Ok(klientEntities);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<KlientEntity> GetById(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var klientEntity = session.Get<KlientEntity>(id);

                if (klientEntity == null)
                {
                    return NotFound();
                }

                return Ok(klientEntity);
            }

        }
        [HttpPost]
        public ActionResult<KlientEntity> CreateKlientEntity([FromBody] KlientEntity klientEntity)
        {
            if (klientEntity == null)
            {
                return BadRequest("Invalid data");
            }
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                       session.Save(klientEntity); 
                        transaction.Commit();
                        return CreatedAtAction(nameof(GetById), new { id = klientEntity.Id }, klientEntity);
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
                        var klientEntity = session.Get<KlientEntity>(id);

                        if (klientEntity == null)
                        {
                            return NotFound();
                        }

                      
                        session.Delete(klientEntity);

                       
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
