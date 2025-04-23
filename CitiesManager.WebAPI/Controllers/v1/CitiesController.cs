using CitiesManager.Core.Models;
using CitiesManager.Core.ServiceContract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CitiesManager.WebAPI.Controllers.v1
{
    /// <summary>
    /// 
    /// </summary>
    //[Authorize]
    [ApiVersion("1.0")]

    //[EnableCors("4100Client")]

    public class CitiesController : CustomControllerBase
    {
        private readonly ICitiesService _citiesService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="citiesService"></param>
        public CitiesController(ICitiesService citiesService)
        {
            _citiesService = citiesService;
        }

        // GET: api/Cities
        /// <summary>
        /// To get all cities (including city id city name) from table
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Produces("application/xml")]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            //this.HttpContext.Response.Headers["Access-Control-Allow-Origin"] = "http://localhost:4200";
            var cities = await _citiesService.GetCitiesAsync();
            return cities.ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Cities/5
        [HttpGet("{id}")] /// same as use HttpGet and Route
        //[HttpGet]
        //[Route("{id}")]
        public async Task<ActionResult<City>> GetCity(Guid id)
        {
            var city = await _citiesService.GetCityByIdAsync(id);
            if (city == null)
            {
                return Problem(detail: "Invalid CityID", statusCode: 400, title: "City Search");
                //return NotFound();
            }
            return city;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        [HttpGet("GetCityByName/{name}")]
        public async Task<ActionResult<City>> GetCityByName(string name)
        {
            var city = await _citiesService.GetCityByNameAsync(name);
            if (city == null)
            {
                return Problem(detail: "Invalid City Name", statusCode: 400, title: "City Search");
                //return NotFound();
            }
            return city;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        [HttpGet("search/{searchString?}")]
        public async Task<ActionResult<IEnumerable<City>>> SeachForCity(string? searchString)
        {
            return (await _citiesService.SearchCitiesAsync(searchString)).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        // PUT: api/Cities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(Guid id, [Bind(nameof(City.CityID), nameof(City.CityName))] City city)
        {
            // auto generete by AspNetCore because [ApiController]
            //if(ModelState.IsValid == false)
            //{
            //    return ValidationProblem(ModelState);
            //}

            if (id != city.CityID)
            {
                //return Problem();
                return BadRequest();
            }

            var existingCity = await _citiesService.UpdateCityAsync(id, city);
            if (!existingCity)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        // POST: api/Cities
        [HttpPost]
        public async Task<ActionResult<City>> PostCity([Bind(nameof(City.CityID), nameof(City.CityName))] City city)
        {
            await _citiesService.AddCityAsync(city);
            return CreatedAtAction("GetCity", new { id = city.CityID }, city);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(Guid id)
        {
            var city = await _citiesService.DeleteCityAsync(id);
            if (!city)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
