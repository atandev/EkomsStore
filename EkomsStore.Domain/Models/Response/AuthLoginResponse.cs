using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkomsStore.Domain.Models.Response
{
    public class AuthLoginResponse
    {
        public string? ErrorMessage { get; set; }
        public string? Token { get;set; }
        public bool isAuthSuccessful { get; set; }
    }
}
