using AutoMapper;
using NeonWorld.Entities;
using NeonWorld.ViewModels.System.Users;

namespace NeonWorld.BackendApi.AutoMapper.Profiles
{
    public class BaseSystemsProfile : Profile
    {
        public BaseSystemsProfile()
        {
            CreateMap<RegisterRequest, User>().ReverseMap();
        }
    }
}
