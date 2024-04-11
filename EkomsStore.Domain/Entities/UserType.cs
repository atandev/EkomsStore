using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkomsStore.Domain.Entities
{
    [Table("UserType")]
    public class UserType
    {
        public byte Code { get; set; }
        public string Type { get; set; }
    }
}
