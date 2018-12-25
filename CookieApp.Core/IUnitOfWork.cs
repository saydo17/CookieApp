namespace CookieApp.Core
{
    public interface IUnitOfWork
    {
        void Commit();
        T Get<T>(int id);
    }
}