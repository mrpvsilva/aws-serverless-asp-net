using Amazon.DynamoDBv2.DataModel;

namespace AWSServerless.Entities
{
    [DynamoDBTable("Users")]
    public class User
    {
        [DynamoDBHashKey("Id")]
        public Guid? Id { get; set; }

        [DynamoDBProperty("Name")]
        public string? Name { get; set; }

        [DynamoDBProperty("Idade")]
        public int? Idade { get; set; }
    }
}
