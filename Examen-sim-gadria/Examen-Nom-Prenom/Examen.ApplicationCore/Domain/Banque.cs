using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Banque
    {
        [Key]
        public int Code { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Email should be valid ")]
        public string Email { get; set; }
        public string Nom { get; set; }
        public string Rue { get; set; }
        public string Ville { get; set; }
        public IList<Compte> Comptes { get; set; }
    }
}
