using Hope.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hope.Services
{
    public interface ITokenService
    {
        Token GetByToken(string accessToken);
    }
}
