﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace User.Data.Entityes
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
    }

    public class EntityTypeConfigurationBase<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder) 
        { 
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Created)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Updated)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd()
                .IsRequired();
        }
    }
}
