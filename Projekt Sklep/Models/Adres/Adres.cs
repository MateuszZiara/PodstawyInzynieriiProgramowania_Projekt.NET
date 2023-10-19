using NHibernate.Linq.Visitors;
namespace Projekt_Sklep.Models.Adres
{
    public class Adres
    {
        public Adres () : base () { }

        public Adres (Guid id, string kodPocztowy, string miasto, string wojewodztwo, string panstwo)
        {
            this.Id = id;
            this.KodPocztowy = kodPocztowy;
            this.Miasto = miasto;
            this.Wojewodztwo = wojewodztwo;
            this.Panstwo = panstwo;
        }
        public virtual string KodPocztowy {  get; set; }
        public virtual string Miasto { get; set; }
        public virtual string Wojewodztwo { get; set; }
        public virtual string Panstwo { get; set; }
        public virtual Guid Id { get; set; }
        

    }
}
