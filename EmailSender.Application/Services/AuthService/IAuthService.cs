using EmailSender.Domain.Entites.Models.AuthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Application.Services.AuthService
{
    public interface IAuthService
    {
        public Task<string> GenerateToken(User user);
    }
}
