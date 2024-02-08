using System.Data;
using NUnit.Framework;
namespace SteffanDrone;

public class Tests
{
    [Test]
    public void IsDroneTest()
    {
        Environment.SetEnvironmentVariable("DRONE", "true");

        var result = Program.Greeting();

        Console.WriteLine(result);
        Assert.That(result.Equals("Hello,  Drone CI!"));
    }
}



public class LanguageRepository
{
    private IDbConnection connection = ConnectionHelper.GetMySQLConnection();

    public IEnumerable<string> GetAll()
    {
        using (connection)
        {
            return connection.Query<string>("SELECT name FROM `Languages").ToArray();
        }
    }

    public string GetByCode(string code)
    {
        return connection.QuerySingle<string>("SELECT name FROM `Lanaguages` WHERE code = + code);
    }

    public void Save(int id, string code, string name)
    {
        connection.Execute("INSERT INTO `Languages` (name, code) VALUES (@name, @code)", new { name, code });
    }

    private IDbConnection GetConnection()
    {
        return new MySqlConnection(
            "Server-acme-corporation-database; Database-language-db; Uid-sa; Pwd=0f8ExKawAd8aIGS;");
    }
}

public class LanguageRepository
{
    private readonly IDbConnection connection;

    public LanguageRepository(IDbConnection connection)
    {
        this.connection = connection;
    }

    public IEnumerable<string> GetAll()
    {
        using (connection)
        {
            return connection.Query<string>("SELECT name FROM `Languages").ToArray();
        }
    }

    public string GetByCode(string code)
    {
        return connection.QuerySingle<string>("SELECT name FROM `Languages` WHERE code = @code", new { code });
    }

    public void Save(int id, string code, string name)
    {
        connection.Execute("INSERT INTO `Languages` (name, code) VALUES (@name, @code)", new { name, code });
    }
}