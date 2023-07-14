using System;

namespace Ribbons.Reflection
{
    public class ClassicModelBuilder<T> : IModelBuilder<T> where T : class
    {
        public Type? Type { get; private set; }
        public Func<T>? DefaultConstructor { get; private set; }

        public T? CreateInstance()
        {
            return Activator.CreateInstance<T>();
        }
    }
}