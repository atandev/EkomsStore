using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkomsStore.Application.Utilities
{
    public class PasswordSecurityHelper
    {
        public static bool CheckPassword(string password, string loginPassword)
        {
            return password == loginPassword ? true : false;
        }
    }
}
