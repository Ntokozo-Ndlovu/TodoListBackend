using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain.JwtAuthorization
{
    public interface IJwtAuthorization
    {
        public string DecodeJwtToken(string token);
        public string GenerateJwtToken(Guid userId);

    }
}
