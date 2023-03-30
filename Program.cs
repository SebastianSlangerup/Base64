namespace Base64
{
    public class Program
    {
        public static void Main()
        {
            char result = Base64.Encode("M");
            
            Console.WriteLine(result);
        }
    }
}
