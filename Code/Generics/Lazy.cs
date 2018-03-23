using System;

namespace Generics
{
    public class Lazy<TValue>
    {
        private TValue _value;
        private bool _isEvaluated;
        private readonly Func<TValue> _valueAccessor;

        public Lazy(Func<TValue> valueAccessor)
        {
            _valueAccessor = valueAccessor;
        }

        public TValue Value
        {
            get
            {
                if (!_isEvaluated)
                {
                    _value = _valueAccessor();
                    _isEvaluated = true;
                }
                return _value;
            }
        }
    }
}