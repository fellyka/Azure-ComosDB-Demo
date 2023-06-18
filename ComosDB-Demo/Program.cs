using Microsoft.Azure.Cosmos;

using System;

namespace ComosDB_Demo
{
    public class Program
    {
        private static readonly string connectionString = "AccountEndpoint=https://cos-azsollers.documents.azure.com:443/;AccountKey=nbasL34Pa3MRaH5fEvAlkmbidTzk0GaPzNPLvsVIDpRVnK3tCE95bIzex2YMSPJ2sZSRIDYxzJ6kACDbCZY0SA==;";
        private static readonly string databaseName = "TestDataBase";
        private static readonly string containerName = "TestContainer";
       

        static void Main(string[] args)
        {
            CosmosClient client = new CosmosClient(connectionString);
            Course course = new Course()
            {
                 id = "A1", courseId = "AZ-900", courseName = "Azure Fundamentals", rating = 4.5m
            };

            Container container = client.GetContainer(databaseName, containerName);
            container.CreateItemAsync<Course>(course, new PartitionKey(course.courseId)).GetAwaiter();//.GetResult();
          

            Console.WriteLine("Course item has been created");
            Console.ReadKey();
        }
    }
}
