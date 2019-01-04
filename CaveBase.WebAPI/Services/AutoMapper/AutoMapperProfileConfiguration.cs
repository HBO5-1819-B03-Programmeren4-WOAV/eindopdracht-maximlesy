using AutoMapper;
using CaveBase.Library.DTO;
using CaveBase.Library.Models;

namespace CaveBase.WebAPI.Services.AutoMapper
{
    public class AutoMapperProfileConfiguration : Profile
    {
        protected AutoMapperProfileConfiguration(string profileName) : base(profileName)
        {
            CreateMap<CaveBasic, Cave>();
        }

        public AutoMapperProfileConfiguration() : this("CaveBaseMappingProfile") { }
    }
}
