namespace Generics.Container
{
    internal class SingletonTypeBuilder<TConcrete> : Lazy<TConcrete>, ITypeBuilder
    {
        public SingletonTypeBuilder(ITypeBuilder inner) : base(()=>(TConcrete)inner.Create())
        {
        }

        public object Create()
        {
            return Value;
        }
    }
}