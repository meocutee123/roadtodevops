﻿using Nihongo.Shared.Interfaces.Reposiroty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Application.Interfaces.Reposiroty
{
    public interface IRepositoryWrapper
    {
        IAccountRepository Account { get; }
        IPropertyRepository Property { get; }
        Task SaveChangesAsync();
    }
}
