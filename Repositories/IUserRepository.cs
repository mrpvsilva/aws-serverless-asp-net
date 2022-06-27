using AWSServerless.Domain;

namespace AWSServerless.Repositories
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<IEnumerable<User>> Get();
        Task<User> GetById(Guid id);
        Task Update(User user);
        Task<User> Remove(Guid id);
    }
}
