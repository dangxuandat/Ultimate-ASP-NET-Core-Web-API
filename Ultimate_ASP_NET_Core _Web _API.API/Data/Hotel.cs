using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ultimate_ASP_NET_Core__Web__API.API.Data
{
	public class Hotel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public double Rating { get; set; }
		[ForeignKey(nameof(CountryId))]
		public int CountryId { get; set; }
		public Country Country { get; set; }
	}
}
