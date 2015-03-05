using Nancy.Security;
using System.Collections.Generic;

namespace OPENCBS.Server
{
    public class User : IUserIdentity
    {
        public IEnumerable<string> Claims
        {
            get
            {
                return null;
            }
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Deleted { get; set; }
    }
}
