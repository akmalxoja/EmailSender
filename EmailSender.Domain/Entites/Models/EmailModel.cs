using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmailSender.Domain.Entites.Models
{
    public class EmailModel
    {
        [EmailAddress]
        public string To { get; set; }
        public string Subject {  get; set; }


        [JsonIgnore]
        public string? Body { get; set; }
    }
}
