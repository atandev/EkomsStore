using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkomsStore.Domain.Entities
{
    public class UserSecurity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string password { get; set; }
        public string password_salt { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
