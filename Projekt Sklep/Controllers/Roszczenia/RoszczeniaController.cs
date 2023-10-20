using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Models.Placowki;
using Projekt_Sklep.Models;
using Projekt_Sklep.Persistence.Placowki;
using System.Text.RegularExpressions;

namespace Projekt_Sklep.Controllers.Roszczenia
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoszczeniaController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<Models.Roszczenia.Roszczenia>> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var roszczeniaEntities = session.Query<Models.Roszczenia.Roszczenia>().ToList();
                return Ok(roszczeniaEntities);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Models.Roszczenia.Roszczenia> GetById(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var roszczeniaEntity = session.Get<Models.Roszczenia.Roszczenia>(id);

                if (roszczeniaEntity == null)
                {
                    return NotFound();
                }

                return Ok(roszczeniaEntity);
            }

        }
        [HttpPost]
        public ActionResult<Models.Roszczenia.Roszczenia> CreateRoszczeniaEntity([FromBody] Models.Roszczenia.Roszczenia roszczenia)
        {
            if (roszczenia == null)
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
                        session.Save(roszczenia);
                        transaction.Commit();
                        return CreatedAtAction(nameof(GetById), new { id = roszczenia.Id }, roszczenia);
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
        public ActionResult DeleteRoszczenia(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var roszczenia = session.Get<Models.Roszczenia.Roszczenia>(id);

                        if (roszczenia == null)
                        {
                            return NotFound();
                        }


                        session.Delete(roszczenia);


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
