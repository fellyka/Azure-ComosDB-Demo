using Microsoft.Azure.Cosmos;

using System;

namespace ComosDB_Demo
{
    public class Program
    {
        private static readonly string connectionString = "AccountEndpoint=https://cos-azsollers.documents.azure.com:443/;AccountKey=nbasL34Pa3MRaH5fEvAlkmbidTzk0GaPzNPLvsVIDpRVnK3tCE95bIzex2YMSPJ2sZSRIDYxzJ6kACDbCZY0SA==;";
        private static readonly string databaseName = "TestDataBase";
        private static readonly string containerName = "TestContainer";
        private static readonly string partitionKey = "/courseid";

        static void Main(string[] args)
        {
            CosmosClient client = new CosmosClient(connectionString);
            client.CreateDatabaseAsync(databaseName).GetAwaiter().GetResult();
            //Operation on database
            Database database = client.GetDatabase(databaseName);

            database.CreateContainerAsync(containerName, partitionKey).GetAwaiter().GetResult();

            Console.WriteLine("Database and container have been created");
            Console.ReadKey();
        }
    }
}
