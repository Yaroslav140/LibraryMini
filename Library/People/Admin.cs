using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Admin : People
    {
        public Admin(string? name, string? firstName, string? uniqueKey, string? login, string? password)
            : base(name, firstName, uniqueKey, login, password)
        {
        }
    }
}
