using Ribbons.Reflection;
using Ribbons.TestConsole.Reflection;

namespace Ribbons.TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExpressionModelBuilder<BaseClass> modelBuilder = new ExpressionModelBuilder<BaseClass>();

            BaseClass? instance = modelBuilder.CreateInstance();

            if (instance == null)
            {
                Console.Write($"{nameof(instance)} is null");
            }
        }
    }
}