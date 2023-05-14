using Examen.ApplicationCore.Domain;
using Examen.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infrastructure
{
    public class ExamContext:DbContext
    {
        //les dbsets

        public DbSet<Banque> Banque { get; set; }
        public DbSet<Compte> Compte { get; set; }
        public DbSet<DAB> DAB { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<TransactionRetrait> TransactionRetrait { get; set; }
        public DbSet<TransactionTransfert> TransactionTransfert { get; set; }
        //TPT 
       


        //....................
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                          Initial Catalog=DABdb;
                                          Integrated Security=true;
                                          MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies(); //activer lazy loading
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ExempleConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            //...................
            //tpt 
            modelBuilder.Entity<TransactionRetrait>().ToTable("TransactionRetrait");
            modelBuilder.Entity<TransactionTransfert>().ToTable("TransactionTransfert");
            //tph => config

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //configurationBuilder.Properties<DateTime>().HaveColumnType("date");SS
        }
    }
}
