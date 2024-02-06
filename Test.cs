using NUnit.Framework;

namespace MichaelDrone;

public class Tests
{
    [Test]
    public void IsDroneTest()
    {
        Environment.SetEnvironmentVariable("DRONE", "true");

        var result = Program.Greeting();

        Console.WriteLine(result);
        Assert.That(result.Equals("Hello, Drone CI!"));
    }
}