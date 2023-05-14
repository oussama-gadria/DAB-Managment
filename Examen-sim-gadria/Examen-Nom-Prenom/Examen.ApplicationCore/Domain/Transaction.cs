using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public double Montant { get; set; }

        public string DABFk { get; set; }
        public string NumeroConpteFk { get; set; }

        [ForeignKey("DABFk")]
        public DAB Dab { get; set; }

        [ForeignKey("NumeroConpteFk")]
        public Compte Compte { get; set; }
    }
}
