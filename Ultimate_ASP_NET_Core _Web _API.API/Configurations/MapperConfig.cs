using AutoMapper;
using Ultimate_ASP_NET_Core__Web__API.API.Data;
using Ultimate_ASP_NET_Core__Web__API.API.Models.Country;
using Ultimate_ASP_NET_Core__Web__API.API.Models.Hotels;

namespace Ultimate_ASP_NET_Core__Web__API.API.Configurations
{
	public class MapperConfig : Profile
	{
		public MapperConfig()
		{
			CreateMap<CreateCountryDto, Country>().ReverseMap();
			CreateMap<Country, GetCountryDto>().ReverseMap();
			CreateMap<Country, CountryDto>().ReverseMap();
			CreateMap<UpdateCountryDto, Country>().ReverseMap();
			CreateMap<Hotel, HotelDto>().ReverseMap();
		}
	}
}

