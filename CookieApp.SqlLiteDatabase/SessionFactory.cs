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
        private static ISessionFactory _factory;
        private static string _fileName;

        public static ISession OpenSession()
        {
            return _factory.OpenSession();
        }

        public static void Init(string fileName)
        {
            _factory = BuildSessionFactory(fileName);
        }

        private static ISessionFactory BuildSessionFactory(string fileName)
        {
            _fileName = fileName;
            FluentConfiguration configuration = Fluently.Configure()
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

        private static void BuildSchema(Configuration obj)
        {
            if (File.Exists(_fileName)) File.Delete(_fileName);

            var se = new SchemaExport(obj);
            se.Create(true, true);
        }

        public class TableNamingConvention : IClassConvention
        {
            public void Apply(IClassInstance instance)
            {
                instance.Table(instance.EntityType.Name);
            }
        }

        private class HiLoConvention : IIdConvention
        {
            public void Apply(IIdentityInstance instance)
            {
                instance.Column(instance.EntityType.Name + "ID");
                instance.GeneratedBy.Native();
            }
        }
    }
}