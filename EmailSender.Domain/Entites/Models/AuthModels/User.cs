using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Domain.Entites.Models.AuthModels
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserName {  get; set; }
        public string Login {  get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

    }
}
