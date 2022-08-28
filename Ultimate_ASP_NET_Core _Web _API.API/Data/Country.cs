using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ultimate_ASP_NET_Core__Web__API.API.Data
{
	public class Country
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ShortName { get; set; }
		public virtual IList<Hotel> Hotels { get; set; }
	}
}
