using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infrastructure.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasOne(p=>p.Compte)
                .WithMany(p=>p.Transactions)
                .HasForeignKey(p=>p.NumeroCompteFk)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p=>p.Dab)
                .WithMany(p=>p.Transactions)
                .HasForeignKey(p=>p.DABFk)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasKey(t => new
            {
                t.NumeroCompteFk,
                t.DABFk,
                t.Date
            }
            );
                
        }
    }
}
