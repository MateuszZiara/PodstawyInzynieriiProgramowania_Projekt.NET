using System.ComponentModel.DataAnnotations;

namespace Projekt_Sklep.Models.Klient
{
    public class KlientEntity
    {
        public KlientEntity() : base() 
        { }
        public KlientEntity(Guid id, string Name, string LastName)
        { 
            this.Id = id;
            this.Name = Name;
            this.LastName = LastName;
        }
        [Required(ErrorMessage = "Pole \"Id\" jest wymagane.")]
        public virtual Guid Id { get; set; }
        [Required(ErrorMessage = "Pole \"Name\" jest wymagane.")]
        public virtual string Name { get; set; }
        [Required(ErrorMessage = "Pole \"LastName\" jest wymagane.")]
        public virtual string LastName { get; set; }
        


    }
}
