using System;
using System.Collections.Generic;

namespace Generics.Container
{
    public class IocContainer
    {
        private readonly Dictionary<Type, Func<object>> _builders = new Dictionary<Type, Func<object>>();

        public void Register<TInterface, TConcrete>() where TConcrete : TInterface
        {
            Register(typeof(TInterface), new ConstructorTypeBuilder<TConcrete>(this));
        }

        public void Register<TConcrete>()
        {
            Register<TConcrete, TConcrete>();
        }

        public void RegisterSingleton<TConcrete>(TConcrete singleton)
        {
            Register(() => singleton);
        }

        public void RegisterSingleton<TConcrete>()
        {
            RegisterSingleton<TConcrete, TConcrete>();
        }

        public void RegisterSingleton<TConcrete>(Func<TConcrete> factoryFunc)
        {
            Register(typeof(TConcrete), new SingletonTypeBuilder<TConcrete>(new FactoryMethodTypeBuilder<TConcrete>(factoryFunc)));
        }

        public void RegisterSingleton<TInterface, TConcrete>()
        {
            Register(typeof(TInterface), new SingletonTypeBuilder<TConcrete>(new ConstructorTypeBuilder<TConcrete>(this)));
        }

        public void Register<TConcrete>(Func<TConcrete> factoryFunc)
        {
            Register(typeof(TConcrete), new FactoryMethodTypeBuilder<TConcrete>(factoryFunc));
        }

        private void Register(Type target, ITypeBuilder builder)
        {
            if (!_builders.ContainsKey(target))
            {
                _builders.Add(target, builder.Create);
            }
            else
            {
                throw new InvalidOperationException($"Duplicate registration for type {target.FullName}");
            }
        }

        public TTarget Resolve<TTarget>()
        {
            return (TTarget) Resolve(typeof(TTarget));
        }

        public object Resolve(Type target)
        {
            if (!_builders.ContainsKey(target))
            {
                throw new InvalidOperationException($"No registration for {target.FullName}");
            }
            return _builders[target]();
        }

        internal bool HasRegistration(Type target)
        {
            return _builders.ContainsKey(target);
        }
    }
}