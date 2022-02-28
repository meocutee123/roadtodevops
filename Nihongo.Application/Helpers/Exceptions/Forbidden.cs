using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Application.Helpers.Exceptions
{
    public class Forbidden : Exception
    {
        public Forbidden() : base() { }

        public Forbidden(string message) : base(message) { }
    }
}
