namespace HealthyHeaven
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vegetable vegetable = new Vegetable("dgsdgsd", 123);
            Salad salad = new Salad("cesar");
            System.Console.WriteLine(salad.GetProductCount());

            System.Console.WriteLine(salad.ToString());
        }
    }
}