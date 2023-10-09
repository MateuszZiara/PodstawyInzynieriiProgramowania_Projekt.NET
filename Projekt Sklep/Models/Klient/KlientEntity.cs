using NHibernate.Linq.Visitors;
using System.ComponentModel.DataAnnotations;

namespace Projekt_Sklep.Models.Klient
{
    public class KlientEntity
    {
        public KlientEntity() : base() 
        { }
        public KlientEntity(Guid id, string Name, string LastName, string NIP, string Regon, string Nazwa_Firmy, string Pan_Pani)
        { 
            this.Id = id;
            this.Imie = Name;
            this.Nazwisko = LastName;
            this.NIP = NIP;
            this.REGON = Regon;
            this.Nazwa_firmy = Nazwa_Firmy;
            this.Pan_Pani = Pan_Pani;
        }
        [Required(ErrorMessage = "Pole \"Id\" jest wymagane.")]
        public virtual Guid Id { get; set; }
        [Required(ErrorMessage = "Pole \"Name\" jest wymagane.")]
        public virtual string Imie { get; set; }
        [Required(ErrorMessage = "Pole \"LastName\" jest wymagane.")]
        public virtual string Nazwisko { get; set; }

        [Required(ErrorMessage = "Pole \"NIP\" jest wymagane.")]
        public virtual string NIP { get; set; }

        [Required(ErrorMessage = "Pole \"REGON\" jest wymagane.")]
        public virtual string REGON { get; set; }

        [Required(ErrorMessage = "Pole \"Nazwa_firmy\" jest wymagane.")]
        public virtual string Nazwa_firmy { get; set;}
        [Required(ErrorMessage = "Pole \"Pan_Pani\" jest wymagane.")]
        public virtual string Pan_Pani { get; set; }
    }
}
