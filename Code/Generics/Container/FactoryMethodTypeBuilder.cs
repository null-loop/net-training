using System;

namespace Generics.Container
{
    internal class FactoryMethodTypeBuilder<TConcrete> : ITypeBuilder
    {
        private readonly Func<TConcrete> _factoryFunc;

        public FactoryMethodTypeBuilder(Func<TConcrete> factoryFunc)
        {
            _factoryFunc = factoryFunc;
        }

        public object Create()
        {
            return _factoryFunc();
        }
    }
}