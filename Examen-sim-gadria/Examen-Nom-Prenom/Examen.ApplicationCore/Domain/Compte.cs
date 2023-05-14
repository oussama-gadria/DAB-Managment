using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Compte
    {
        public int CompteId { get; set; }
        public string NumeroCompte { get; set; }
        public string Propriétaire { get; set; }
        public double Solde { get; set; }
        public TypeCompte Type { get; set; }
    }
}
