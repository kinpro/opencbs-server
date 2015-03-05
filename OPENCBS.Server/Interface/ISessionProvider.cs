using System;

namespace OPENCBS.Server
{
    public interface ISessionProvider
    {
        void Add(Session session);
        Session Get(Guid id);
        void Remove(Guid id);
    }
}
