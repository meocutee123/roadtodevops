using Nihongo.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Shared.Interfaces.Services
{
    public interface ICookieService
    {
        Account ActiveAccount();
    }
}
