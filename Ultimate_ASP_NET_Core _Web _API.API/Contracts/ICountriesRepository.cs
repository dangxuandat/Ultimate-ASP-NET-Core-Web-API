using Ultimate_ASP_NET_Core__Web__API.API.Data;

namespace Ultimate_ASP_NET_Core__Web__API.API.Contracts;

public interface ICountriesRepository : IGenericRepository<Country>
{
	public Task<Country> GetDetails(int id);
}