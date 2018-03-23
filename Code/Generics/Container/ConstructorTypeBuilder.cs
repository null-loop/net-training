using System;
using System.Linq;
using System.Reflection;

namespace Generics.Container
{
    internal class ConstructorTypeBuilder<TConcrete> : ITypeBuilder
    {
        private readonly IocContainer _originatingContainer;

        public ConstructorTypeBuilder(IocContainer originatingContainer)
        {
            _originatingContainer = originatingContainer;
        }

        public object Create()
        {
            // locate the constructor via reflection
            var allConstructors = typeof(TConcrete).GetConstructors(BindingFlags.Public | BindingFlags.Instance);

            // find a constructor that we can fufill
            var validConstructors = allConstructors
                .Where(ctr => ctr.GetParameters().All(p => _originatingContainer.HasRegistration(p.ParameterType)))
                .ToArray();

            if (validConstructors.Length != 1)
            {
                throw new InvalidOperationException($"Couldn't locate single constructor for type {typeof(TConcrete).FullName}");
            }
            var targetConstructor = validConstructors.First();
            var parameters = targetConstructor.GetParameters()
                .Select(p => _originatingContainer.Resolve(p.ParameterType))
                .ToArray();

            return Activator.CreateInstance(typeof(TConcrete), parameters);
        }
    }
}