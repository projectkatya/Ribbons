using System;
using System.Linq.Expressions;

namespace Ribbons.Reflection
{
    public class ExpressionModelBuilder<T> : IModelBuilder<T> where T : class
    {
        public Type Type { get; private set; }
        public Func<T>? DefaultConstructor { get; private set; }

        public ExpressionModelBuilder()
        {
            Type = typeof(T);
            DefaultConstructor = GetConstructor();
        }
        
        public T? CreateInstance()
        {
            return (DefaultConstructor ?? throw new InvalidOperationException($"No default constructor for {Type.FullName}"))();   
        }

        private Func<T> GetConstructor()
        {
            NewExpression newExpression = Expression.New(Type);
            Expression<Func<T>> constructorExpression = Expression.Lambda<Func<T>>(newExpression);
            return constructorExpression.Compile();
        }
    }
}