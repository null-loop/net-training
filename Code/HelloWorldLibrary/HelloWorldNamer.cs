namespace HelloWorldLibrary
{
    public class HelloWorldNamer
    {
        public static string GetHelloWorld(string[] names)
        {
            if (names.Length == 0)
            {
                return "Hello World!";
            }

            var allNames = string.Join(" and ", names);

            return $"Hello {allNames}!";

        }
    }
}
