using NHibernate;
using NHibernate.Criterion;

public class DBService
{
    private readonly ISessionFactory _sessionFactory;

    public DBService(ISessionFactory sessionFactory)
    {
        _sessionFactory = sessionFactory;
    }

    public void Save<T>(T entity)
    {
        using (var session = _sessionFactory.OpenSession())
        using (var transaction = session.BeginTransaction())
        {
            session.Save(entity);
            transaction.Commit();
        }
    }

    public T GetById<T>(int id)
    {
        using (var session = _sessionFactory.OpenSession())
        {
            return session.Get<T>(id);
        }
    }
    public T Get<T>(ICriterion restrictions ) where T : class
    {
        using(var session = _sessionFactory.OpenSession())
        {
            var criteria = session.CreateCriteria<T>();
            criteria.Add(restrictions);
            return criteria.UniqueResult<T>();
        }
    }
    public void Update<T>(T entity)
    {
        using (var session = _sessionFactory.OpenSession())
        using (var transaction = session.BeginTransaction())
        {
            session.Update(entity);
            transaction.Commit();
        }
    }

    public void Delete<T>(T entity)
    {
        using (var session = _sessionFactory.OpenSession())
        using (var transaction = session.BeginTransaction())
        {
            session.Delete(entity);
            transaction.Commit();
        }
    }
}