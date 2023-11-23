using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Models.WyplatyiSzkody;
using Projekt_Sklep.Models;
using Projekt_Sklep.Persistence.WyplatyiSzkody;
using System.Text.RegularExpressions;
using Projekt_Sklep.Persistence.Pojazdy;
using System.ComponentModel.DataAnnotations;

namespace Projekt_Sklep.Controllers.WyplatyiSzkody
{
    [Route("api/[controller]")]
    [ApiController]
    public class WyplatyiSzkodyController : ControllerBase
    {
        WyplatyiSzkodyService wyplatyiSzkodyService = new WyplatyiSzkodyService();
        [HttpGet]
        public ActionResult<IEnumerable<Models.WyplatyiSzkody.WyplatyiSzkody>> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var klientEntities = session.Query<Models.WyplatyiSzkody.WyplatyiSzkody>().ToList();
                return Ok(klientEntities);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Models.WyplatyiSzkody.WyplatyiSzkody> GetById(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var klientEntity = session.Get<Models.WyplatyiSzkody.WyplatyiSzkody>(id);

                if (klientEntity == null)
                {
                    return NotFound();
                }

                return Ok(klientEntity);
            }

        }
        [HttpPost]
        public ActionResult<Models.WyplatyiSzkody.WyplatyiSzkody> CreateKlientEntity([FromBody] Models.WyplatyiSzkody.WyplatyiSzkody wyplatyiSzkody)
        {
            if (wyplatyiSzkody == null)
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
                        session.Save(wyplatyiSzkody);
                        transaction.Commit();
                        return CreatedAtAction(nameof(GetById), new { id = wyplatyiSzkody.Id }, wyplatyiSzkody);
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
        public ActionResult DeleteWyplatyiSzkody(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var wyplatyiSzkody = session.Get<Models.WyplatyiSzkody.WyplatyiSzkody>(id);

                        if (wyplatyiSzkody == null)
                        {
                            return NotFound();
                        }


                        session.Delete(wyplatyiSzkody);


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
        public bool EditPojazdy([Required] bool StatusWyplaty, Guid Id, DateTime DataZgloszenia, int WartoscSzkody = -1, string TypSzkody = null,Guid? Klient = null)
        {
            Guid guid = Guid.NewGuid();
            if (Klient == null)
            {

                guid = Guid.Empty;
            }
            else
                guid = Klient.Value;
            return wyplatyiSzkodyService.edit(Id, DataZgloszenia, WartoscSzkody, TypSzkody, StatusWyplaty, guid);

        }

    }

}
