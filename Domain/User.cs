namespace AWSServerless.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Idade { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
        }

        public User(string name, int idade) : this()
        {
            Name = name;
            Idade = idade;
        }
    }
}
