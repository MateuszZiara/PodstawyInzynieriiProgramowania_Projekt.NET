using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Models.Logi;
using Projekt_Sklep.Models;
using Projekt_Sklep.Persistence.Logi;
using System.Text.RegularExpressions;

namespace Projekt_Sklep.Controllers.Logi
{
    [Route("api/[controller]")]
    [ApiController]
    public class Logi : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<Models.Logi.Logi>> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var klientEntities = session.Query<Models.Logi.Logi>().ToList();
                return Ok(klientEntities);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Models.Logi.Logi> GetById(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var klientEntity = session.Get<Models.Logi.Logi>(id);

                if (klientEntity == null)
                {
                    return NotFound();
                }

                return Ok(klientEntity);
            }

        }
        [HttpPost]
        public ActionResult<Models.Logi.Logi> CreateKlientEntity([FromBody] Models.Logi.Logi logi)
        {
            if (logi == null)
            {
                return BadRequest("Invalid data");
            }
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        /*//TASK AX-14
                        Regex regex = new Regex(@"^\d{3}-\d{3}-\d{2}-\d{2}$");
                        Match match = regex.Match(placowki.NIP);
                        if (match.Success)
                        {

                        }
                        else
                        {
                            throw new ArgumentException();
                        }
                        //END OF TASK*/
                        session.Save(logi);
                        transaction.Commit();
                        return CreatedAtAction(nameof(GetById), new { id = logi.Id }, logi);
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
        public ActionResult DeleteLogi(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var logi = session.Get<Models.Logi.Logi>(id);

                        if (logi == null)
                        {
                            return NotFound();
                        }


                        session.Delete(logi);


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
