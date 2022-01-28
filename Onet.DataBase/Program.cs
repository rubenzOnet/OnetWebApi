

using DbUp;
using DbUp.SqlServer;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;



namespace Onet.DataBase

{
    internal class Program
    {
        private static string _schema = "North";

        static void Main(string[] args)
        {

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Console.WriteLine("===env===");
            Console.WriteLine(env);
            Console.WriteLine("===env===");


            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env}.json")
                .Build();

            var connectionString = config["Connections:SqlCommandConnection"];

            var runner = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();

            var result = runner.PerformUpgrade();

            if (!result.Successful)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Scripts deploy sucessfully");
            }

            Console.ReadKey();


        }
    }
}
