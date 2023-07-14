using System;

namespace Ribbons.Reflection
{
    public abstract class ModelBuilder<T> : IModelBuilder<T> where T : class
    {
        public Type? Type { get; }
        public Func<T>? DefaultConstructor { get; }

        protected ModelBuilder()
        {
            Type = typeof(T);
            
        }

        public T? CreateInstance()
        {
            throw new NotImplementedException();
        }
    }
}