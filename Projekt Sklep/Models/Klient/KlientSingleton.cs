using Projekt_Sklep.Models.Adres;

namespace Projekt_Sklep.Models.Klient
{ 
    public class KlientSingleton : KlientEntity
{
    private static KlientSingleton _instance;

    private KlientSingleton() : base()
    {
        // Your initialization code here
        this.Id = Guid.Empty;
        this.Name = null;
        this.LastName = null;
        this.Pesel = null;
        this.NumerTelefonu = null;
        this.Email = null;
        this.NIP = null;
        this.Login = null;
        this.Password = null;
        this.Adres = Guid.Empty;
    }

    public static KlientSingleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new KlientSingleton();
            }
            return _instance;
        }
    }

        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Pesel { get; set; }
        public virtual string NumerTelefonu { get; set; }
        public virtual string Email { get; set; }
        public virtual string NIP { get; set; }
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
        public virtual Guid Adres { get; set; }

    }
}

