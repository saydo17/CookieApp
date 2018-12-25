using System.IO;
using System.Reflection;
using CookieApp.SqlLiteDatabase.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Conventions.Instances;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace CookieApp.SqlLiteDatabase
{
    public class SessionFactory
    {
        public SessionFactory(string fileName)
        {
            _factory = BuildSessionFactory(fileName);
        }

        private readonly ISessionFactory _factory;

        public ISession OpenSession()
        {
            return _factory.OpenSession();
        }


        private static ISessionFactory BuildSessionFactory(string fileName)
        {
            var configuration = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile(fileName))
                .Mappings(m => m.FluentMappings
                    .AddFromAssemblyOf<TroopMap>()
                    .Conventions.Add(
                        ForeignKey.EndsWith("ID"),
                        ConventionBuilder.Property
                            .When(criteria => criteria.Expect(x => x.Nullable, Is.Not.Set), x => x.Not.Nullable())
                    )
                    .Conventions.Add<TableNamingConvention>()

                )
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true));

            return configuration.BuildSessionFactory();
        }

        // ReSharper disable once ClassNeverInstantiated.Local
        private class TableNamingConvention : IClassConvention
        {
            public void Apply(IClassInstance instance)
            {
                instance.Table(instance.EntityType.Name);
            }
        }
    }
}