using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using User.Data.Models;

namespace User.Data
{
    public class ApiBancoContext : DbContext
    {
        public DbSet<AccountEntity> AccountDB { get; set; } = null!;
        public DbSet<TransactionEntity> TransactionDB { get; set; } = null!;

        public ApiBancoContext(DbContextOptions options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //adicionar configuração (conection string default) no app setings
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), t => t.FullName?.StartsWith("User.Data", StringComparison.OrdinalIgnoreCase) ?? false);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}


//1 - conteczt 
//2 - program cs add dependencies/migrations services AddDbconteczt
//3 - app settings, configurar onde ta a db
//4 - criar entity base e config
//5- ir a cada entity e configurar e esportar 
//6 - Criar generic repo e add conteczt 
//7 - add generic repo na pool de services
//8 - no controller criar instancias para repository
//9 - usar instancias e alterar metodos