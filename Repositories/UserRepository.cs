using Amazon.DynamoDBv2.DataModel;
using AutoMapper;
using AWSServerless.Domain;
using UserEntity = AWSServerless.Entities.User;

namespace AWSServerless.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDynamoDBContext _dynamoDBContext;
        private readonly IMapper _mapper;

        public UserRepository(IDynamoDBContext dynamoDBContext, IMapper mapper)
        {
            _dynamoDBContext = dynamoDBContext;
            _mapper = mapper;
        }

        public async Task<User> Create(User user)
        {
            await _dynamoDBContext.SaveAsync(_mapper.Map<UserEntity>(user));
            return user;
        }

        public async Task<IEnumerable<User>> Get()
        {
            var entities = await _dynamoDBContext.ScanAsync<UserEntity>(default).GetRemainingAsync();
            return _mapper.Map<IEnumerable<User>>(entities);
        }

        public async Task<User> GetById(Guid id)
        {
            var entity = await _dynamoDBContext.LoadAsync<UserEntity>(id);
            return _mapper.Map<User>(entity);
        }

        public Task<User> Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
