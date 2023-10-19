using NHibernate.Linq.Visitors;
using System.ComponentModel.DataAnnotations;

namespace Projekt_Sklep.Models.Klient
{
    public class KlientEntity
    {
        public KlientEntity() : base() 
        { }
        public KlientEntity(Guid Id, string Name, string Pesel, string NumerTelefonu, string Email, string NIP, string LastName, Guid AdresID, Guid PolisaID)
        {
            this.Id = Id;
            this.Name = Name;
            this.LastName = LastName;
            this.Pesel = Pesel;
            this.NumerTelefonu = NumerTelefonu;
            this.Email = Email;
            this.NIP = NIP;
            this.AdresID = AdresID;
            //this.PolisaID = PolisaID;

        }
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Pesel { get; set; }
        public virtual string NumerTelefonu { get; set; }
        public virtual string Email { get; set; }
        public virtual string NIP { get; set; }
        public virtual Guid AdresID  { get; set; }
       // public virtual Guid PolisaID { get; set; }

    }
}
