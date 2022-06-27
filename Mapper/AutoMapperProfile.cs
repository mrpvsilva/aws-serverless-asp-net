using AutoMapper;

namespace AWSServerless.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Domain.User, Entities.User>().ReverseMap();
        }
    }
}
