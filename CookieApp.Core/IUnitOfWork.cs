using System;
using System.Linq;

namespace CookieApp.Core
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        T Get<T>(int id) where T: class;

        void SaveOrUpdate<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        IQueryable<T> Query<T>() where T : class;
    }
}