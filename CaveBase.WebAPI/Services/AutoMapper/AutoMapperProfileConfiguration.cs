using AutoMapper;
using CaveBase.Library.DTO;
using CaveBase.Library.Models;

namespace CaveBase.WebAPI.Services.AutoMapper
{
    public class AutoMapperProfileConfiguration : Profile
    {
        protected AutoMapperProfileConfiguration(string profileName) : base(profileName)
        {
            //Without extra configuration
            CreateMap<Cave, CaveBasic>();
            CreateMap<Cave, CaveDetail>();

            //With extra configuration 
            CreateMap<Club, ClubBasic>().ForMember(destinationMember => destinationMember.Address, // The address property of 'ClubBasic'...
                                                   memberOptions => memberOptions.MapFrom(club => $"{club.Streetname} {club.Housenumber}, {club.PostalCode} {club.City}")); //is equal to this custom(composite) configuration
        }

        public AutoMapperProfileConfiguration() : this("CaveBaseMappingProfile") { }
    }
}
