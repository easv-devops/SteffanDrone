public class Program
{
    static void Main()
    {
        Console.WriteLine(Greeting());
        
    }

    public static string Greeting()
    {
        bool isDroneCI = Environment.GetEnvironmentVariable("DRONE") == "true";

        if (isDroneCI)
        {
            return "Hello, Drone CI!";
        }
        else
        {
            return "Hello, World!";
        }
    }
}

