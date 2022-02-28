using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Application.Helpers.Exceptions
{
    public class Unauthorized : Exception
    {
        public Unauthorized() : base() { }

        public Unauthorized(string message) : base(message) { }
    }
}
