using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Data.Models;

namespace User.Data.Entityes
{
    public class Context : DbContext 
    {
        public DbSet<AccountEntity> AccountDB { get; set; } = null!;
        public DbSet<TransactionEntity> TransactionDB { get; set; } = null!;

        public Context(DbContextOptions options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //adicionar configuração (conection string default) no app setings
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly, t => t.FullName?.StartsWith("ApiBanco.Core.Database.Models", StringComparison.OrdinalIgnoreCase) ?? false);
        }
    }
}