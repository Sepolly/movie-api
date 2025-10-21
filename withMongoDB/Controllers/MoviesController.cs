using Microsoft.AspNetCore.Mvc;
using withMongoDB.Models;
using withMongoDB.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace withMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController(MoviesService moviesService) : ControllerBase
    {
        // GET: api/<MoviesController>
        [HttpGet]
        public async Task<List<Movie>> Get() =>
            await moviesService.GetAsync();

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie?>> Get(string id) => 
            await moviesService.GetAsync(id) is Movie movie
                ? Ok(movie)
                : NotFound();

        // POST api/<MoviesController>
        [HttpPost]
        public async Task<IActionResult> Post(Movie movie)
        {
            await moviesService.CreateAsync(movie);
            return CreatedAtAction(
                nameof(Get),
                new { id = movie.Id },
                movie
            );
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Movie updatedMovie)
        {
            var movie = await moviesService.GetAsync(id);
            if (movie is null)
            {
                return NotFound();
            }
            updatedMovie.Id = movie.Id;
            await moviesService.UpdateAsync(id, updatedMovie);

            return NoContent();
        }
            
          

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var movie = await moviesService.GetAsync(id);
            if (movie is null)
            {
                return NotFound();
            }
            await moviesService.RemoveAsync(id);
            return NoContent();
        }
    }
}
