using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ribbons.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder HasOneToOne<TParent, TChild>(
            this ModelBuilder modelBuilder, 
            Expression<Func<TParent, TChild>> child, 
            Expression<Func<TChild, TParent>> parent, 
            Expression<Func<TChild, object>> foreignKey) 
            where TParent : class 
            where TChild : class
        {
            modelBuilder
                .Entity<TParent>()
                .HasOne(child)
                .WithOne(parent)
                .HasForeignKey(foreignKey);

            return modelBuilder;
        }

        public static ModelBuilder HasOneToMany<TParent, TChild>(
            this ModelBuilder modelBuilder,
            Expression<Func<TParent, IEnumerable<TChild>>> children,
            Expression<Func<TChild, TParent>> parent,
            Expression<Func<TChild, object>> foreignKey)
            where TParent : class
            where TChild : class
        {
            modelBuilder
                .Entity<TParent>()
                .HasMany(children)
                .WithOne(parent)
                .HasForeignKey(foreignKey);

            return modelBuilder;
        }
    }
}