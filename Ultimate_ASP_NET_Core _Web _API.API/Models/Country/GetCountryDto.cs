using Ultimate_ASP_NET_Core__Web__API.API.Models.Hotels;

namespace Ultimate_ASP_NET_Core__Web__API.API.Models.Country
{
	public class GetCountryDto : BaseCountryDto
	{
		public int Id { get; set; }
	}

	public class CountryDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ShortName { get; set; }
		public List<HotelDto> Hotels { get; set; }
	}
}
