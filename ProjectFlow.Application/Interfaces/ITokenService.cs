using ProjectFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFlow.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);

        string RefreshToken(User user);
        string cancelToken(string token);
    }
}
