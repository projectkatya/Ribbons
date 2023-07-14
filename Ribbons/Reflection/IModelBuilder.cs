using System;

namespace Ribbons.Reflection
{
    public interface IModelBuilder<T> where T : class
    {
        Type? Type { get; }
        Func<T>? DefaultConstructor { get; }

        T? CreateInstance();
    }
}