﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Compte
    {
        [Key]
        public string NumeroCompte { get; set; }
        public string Propriétaire { get; set; }
        public double Solde { get; set; }
        public TypeCompte Type { get; set; }

        public virtual IList<Transaction> Transactions { get; set; }
        public virtual int BanqueFk { get; set; }
        [ForeignKey("BanqueFk")]
        public  Banque banque;
    }
}
