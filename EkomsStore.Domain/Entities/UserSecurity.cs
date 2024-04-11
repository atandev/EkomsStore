using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkomsStore.Domain.Entities
{
    [Table("UserSecurity")]
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
