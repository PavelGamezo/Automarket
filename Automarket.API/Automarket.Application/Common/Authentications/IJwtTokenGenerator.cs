﻿using Automarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Application.Common.Authentications
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Account account);
    }
}
