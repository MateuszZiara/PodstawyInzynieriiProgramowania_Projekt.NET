using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Projekt_Sklep.Models.Adres;
using Projekt_Sklep.Models.Klient;
using Projekt_Sklep.Models.RodzajePolis;
using Projekt_Sklep.Models.Znizki;
using Projekt_Sklep.Models.WyplatyiSzkody;
using System.Data.SqlClient;
using Projekt_Sklep.Models.Roszczenia;

namespace Projekt_Sklep.Models
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static NHibernate.ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = Fluently.Configure()
                        .Database(
                            MsSqlConfiguration.MsSql2012.ConnectionString("Server=localhost\\SQLEXPRESS;Database=Test;Integrated Security=SSPI;Application Name=Projekt Sklep;TrustServerCertificate=true;")
                        )
                        .Mappings(m =>
                            m.FluentMappings.AddFromAssemblyOf<KlientEntity>()
                        )
                        .Mappings(m =>
                        m.FluentMappings.AddFromAssemblyOf<Adres.Adres>()
                        )
                        .Mappings(m =>
                        m.FluentMappings.AddFromAssemblyOf<Znizki.Znizki>()
                        )
                        .Mappings(m =>
                        m.FluentMappings.AddFromAssemblyOf<Placowki.Placowki>()
                        )
                        .Mappings(m =>
                        m.FluentMappings.AddFromAssemblyOf<WyplatyiSzkody.WyplatyiSzkody>()
                        )
                        .Mappings(m =>
                        m.FluentMappings.AddFromAssemblyOf<RodzajePolis.RodzajePolis>().Conventions.AddFromAssemblyOf<RodzajePolisEnum>()
                        )
                        .Mappings(m =>
                        m.FluentMappings.AddFromAssemblyOf<Ubezpieczyciele.Ubezpieczyciele>()
                        )
                        .Mappings(m =>
                        m.FluentMappings.AddFromAssemblyOf<Pojazdy.Pojazdy>()
                        )
                        .Mappings(m => 
                        m.FluentMappings.AddFromAssemblyOf<WyplatyiSzkody.WyplatyiSzkody>()
                        )
                        .Mappings(m =>
                        m.FluentMappings.AddFromAssemblyOf<Logi.Logi>()
                        )
                        .Mappings(m =>
                        m.FluentMappings.AddFromAssemblyOf<Roszczenia.Roszczenia>().Conventions.AddFromAssemblyOf<RoszczeniaEnum>()
                        )


                        .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                        .BuildSessionFactory();


                }
                return _sessionFactory;
            }
        }
    }
}
