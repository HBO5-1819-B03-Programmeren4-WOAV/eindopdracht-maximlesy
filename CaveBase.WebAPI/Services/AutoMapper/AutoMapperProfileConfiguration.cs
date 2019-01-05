using AutoMapper;
using CaveBase.Library.DTO;
using CaveBase.Library.Models;
using System;
using System.Linq;

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

            CreateMap<Caver, CaverBasic>().ForMember(destinationMember => destinationMember.FullName,
                                                     memberOptions => memberOptions.MapFrom(caver => $"{caver.FirstName} {caver.LastName}"));

            CreateMap<Cave, CaveStats>().ForMember(destinationMember => destinationMember.TotalRatings,
                                                   memberOptions => memberOptions.MapFrom(cave => cave.Ratings.Count))
                                        .ForMember(destinationMember => destinationMember.AverageDifficulty,
                                                   memberOptions => memberOptions.MapFrom(cave => (Difficulty)Convert.ToInt32(Math.Round(cave.Ratings.Average(rating => (int)rating.Difficulty)))))
                                        .ForMember(destinationMember => destinationMember.CaveName,
                                                   memberOptions => memberOptions.MapFrom(cave => cave.Name));

        }

        public AutoMapperProfileConfiguration() : this("CaveBaseMappingProfile") { }
    }
}
