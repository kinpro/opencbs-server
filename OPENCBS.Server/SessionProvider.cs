using System;
using System.Collections.Generic;

namespace OPENCBS.Server
{
    public class SessionProvider : ISessionProvider
    {
        readonly Dictionary<Guid, Session> _cache = new Dictionary<Guid, Session>();

        public void Add(Session session)
        {
            _cache[session.Id] = session;
        }

        public Session Get(Guid id)
        {
            return _cache.ContainsKey(id) ? _cache[id] : null;
        }

        public void Remove(Guid id)
        {
            _cache.Remove(id);
        }
    }
}
