using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ultimate_ASP_NET_Core__Web__API.API.Contracts;
using Ultimate_ASP_NET_Core__Web__API.API.Data;
using Ultimate_ASP_NET_Core__Web__API.API.Models.Country;

namespace Ultimate_ASP_NET_Core__Web__API.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CountriesController : ControllerBase
	{
		private readonly ICountriesRepository _countriesRepository;
		private readonly IMapper _mapper;

		public CountriesController(ICountriesRepository countriesRepository, IMapper mapper)
		{
			_countriesRepository = countriesRepository;
			_mapper = mapper;
		}

		// GET: api/Countries
		[HttpGet]
		public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
		{
			var results = await _countriesRepository.GetAllAsync();
			var records = _mapper.Map<IEnumerable<GetCountryDto>>(results);
			return Ok(records);
		}

		// GET: api/Countries/5
		[HttpGet("{id}")]
		public async Task<ActionResult<CountryDto>> GetCountry(int id)
		{
			var country = await _countriesRepository.GetDetails(id);
			if (country == null)
			{
				return NotFound();
			}

			var result = _mapper.Map<CountryDto>(country);
			return result;
		}

		// PUT: api/Countries/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updateCountry)
		{
			if (id != updateCountry.Id)
			{
				return BadRequest();
			}

			//_context.Entry(country).State = EntityState.Modified;
			var country = await _countriesRepository.GetAsync(id);
			if (country == null)
			{
				return NotFound();
			}

			_mapper.Map(updateCountry, country);
			try
			{
				await _countriesRepository.UpdateAsync(country);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await CountryExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Countries
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Country>> PostCountry(CreateCountryDto newCountry)
		{
			var country = _mapper.Map<Country>(newCountry);
			await _countriesRepository.AddAsync(country);
			return CreatedAtAction("GetCountry", new { id = country.Id }, country);
		}

		// DELETE: api/Countries/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCountry(int id)
		{
			var country = await _countriesRepository.GetAsync(id);
			if (country == null)
			{
				return NotFound();
			}

			await _countriesRepository.DeleteAsync(id);
			return NoContent();
		}

		private async Task<bool> CountryExists(int id)
		{
			return await _countriesRepository.Exists(id);
		}
	}
}
