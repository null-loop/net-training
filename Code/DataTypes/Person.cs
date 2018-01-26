namespace DataTypes
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public override string ToString()
        {
            return $"Hello, my name is '{Name}'";
        }
    }
}