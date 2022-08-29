using Microsoft.EntityFrameworkCore;
using Ultimate_ASP_NET_Core__Web__API.API.Contracts;
using Ultimate_ASP_NET_Core__Web__API.API.Data;

namespace Ultimate_ASP_NET_Core__Web__API.API.Repository
{
	public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
	{
		private readonly HotelListDbContext _context;
		public CountriesRepository(HotelListDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<Country> GetDetails(int id)
		{
			return await _context.Countries.Include(x => x.Hotels).FirstOrDefaultAsync(x => x.Id == id);
		}
	}
}
