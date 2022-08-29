namespace Ultimate_ASP_NET_Core__Web__API.API.Models.Hotels
{
	public class HotelDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public double Rating { get; set; }
		public int CountryId { get; set; }
	}
}
