namespace DataTypes
{
    public class MyCounter
    {
        public int Value { get; private set; }

        public void Increment()
        {
            Value++;
        }
    }
}