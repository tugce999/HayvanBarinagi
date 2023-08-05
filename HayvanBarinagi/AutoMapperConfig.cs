using AutoMapper;
using HayvanBarinagi.Entities;
using HayvanBarinagi.Models;

namespace HayvanBarinagi
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, UserModel>().ReverseMap();

        }
    }
}
