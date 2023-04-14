using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using User.Data.Entityes;

namespace User.Data.Models
{

    // user model 
    public class AccountEntity : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Income { get; set; }
        public decimal Expense { get; set; }
    }
    public class AccountTypeConfiguration : EntityTypeConfigurationBase<AccountEntity>
    {
        public override void Configure(EntityTypeBuilder<AccountEntity> builder)
        {
            base.Configure(builder);


            builder.ToTable("Account");

            builder.Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength (50)
                .IsRequired();

            builder.Property(x => x.Income);
            builder.Property (x => x.Expense);
        }
    }
}
