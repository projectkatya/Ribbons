using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ribbons.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
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
    }
}