using Microsoft.EntityFrameworkCore;

namespace Ultimate_ASP_NET_Core__Web__API.API.Data
{
	public class HotelListDbContext : DbContext
	{
		public HotelListDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Hotel> Hotels { get; set; }
		public DbSet<Country> Countries { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Country>().HasData(
				new Country
				{
					Id = 1,
					Name = "Viet Nam",
					ShortName = "VN"
				},
				new Country
				{
					Id = 2,
					Name = "American",
					ShortName = "US"
				},
				new Country
				{
					Id = 3,
					Name = "Cayman Island",
					ShortName = "CI"
				}
			);
			modelBuilder.Entity<Hotel>().HasData(
				new Hotel
				{
					Id = 1,
					Name = "Wonderland",
					Address = "Quan Tan Binh",
					Rating = 4.3,
					CountryId = 1
				},
				new Hotel
				{
					Id = 2,
					Name = "Comfort Suites",
					Address = "George Town",
					Rating = 4.6,
					CountryId = 2
				},
				new Hotel
				{
					Id = 3,
					Name = "Grand Palldium",
					Address = "Nassua",
					Rating = 4.0,
					CountryId = 3
				}
			);
		}
	}
}