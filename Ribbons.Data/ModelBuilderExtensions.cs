using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ribbons.Data
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder HasOneToOne<TParent, TChild>(
            this ModelBuilder modelBuilder, 
            Expression<Func<TParent, TChild>> child,
            Expression<Func<TChild, TParent>> parent,
            Expression<Func<TChild, object>> foreignKey,
            DeleteBehavior deleteBehavior = DeleteBehavior.NoAction)
            where TParent : class
            where TChild : class
        {
            modelBuilder
                .Entity<TParent>()
                .HasOne(child)
                .WithOne(parent)
                .HasForeignKey(foreignKey)
                .OnDelete(deleteBehavior);

            return modelBuilder;
        }

        public static ModelBuilder HasOneToMany<TParent, TChild>(
            this ModelBuilder modelBuilder,
            Expression<Func<TParent, IEnumerable<TChild>>> children,
            Expression<Func<TChild, TParent>> parent,
            Expression<Func<TChild, object>> foreignKey,
            DeleteBehavior deleteBehavior = DeleteBehavior.NoAction)
            where TParent : class
            where TChild : class
        {
            modelBuilder
                .Entity<TParent>()
                .HasMany(children)
                .WithOne(parent)
                .HasForeignKey(foreignKey)
                .OnDelete(deleteBehavior);

            return modelBuilder;
        }

        public static ModelBuilder HasData<TEntity>(this ModelBuilder modelBuilder, TEntity data) where TEntity : class
        {
            modelBuilder
                .Entity<TEntity>()
                .HasData(data);

            return modelBuilder;
        }
    }
}