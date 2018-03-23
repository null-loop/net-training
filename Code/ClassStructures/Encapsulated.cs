using System;

namespace ClassStructures
{
    public class Encapsulated
    {
        private Guid _id;

        public Encapsulated(Guid id)
        {
            _id = id;
        }

        public override string ToString()
        {
            return _id.ToString();
        }
    }
}