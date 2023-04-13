using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Data.Entityes;

namespace User.Data.Models
{
    public enum TransactionType
    {
        Income = 0,
        Expense = 1,
        all = 2,
    }

    public class TransactionEntity : EntityBase
    {

        public decimal Value { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public TransactionType? Type { get; set; }
        public string? Attachment { get; set; }
    }

    public class TransactionTypeConfiguration : EntityTypeConfigurationBase<TransactionEntity>
    {
        public override void Configure(EntityTypeBuilder<TransactionEntity> builder)
        {
            base.Configure(builder);


            builder.ToTable("Transaction");

            builder.Property(x => x.Value)
                .IsRequired();

            builder.Property(x => x.Title)
                .HasMaxLength(50);


            builder.Property(x => x.Description)
                .HasMaxLength(100);

            builder.Property(x => x.Type)
                .IsRequired();

            builder.Property(x => x.Attachment);
        }
    }
}
