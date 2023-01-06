using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using AutoMapper;
using Vidly.Models.DTOs;
namespace Vidly.Controllers.API
{
    public class MovieController : ApiController
    {
        
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/movie
        public IEnumerable<MovieDTO> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDTO>);
        }


        // GET /api/movie/id

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null) return NotFound();


            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }

        // POST /api/movie/id
        [HttpPost]
        public IHttpActionResult Action(MovieDTO movieDto)
        {
            var movie = Mapper.Map<MovieDTO, Movie>(movieDto);

            if (!ModelState.IsValid) return NotFound();

            _context.Movies.Add(movie);
            _context.SaveChanges();

            // get newly created movie id

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //update movie into database

        // PUT /api/movie/id
        public void UpdateMovie(MovieDTO moviedto, int id)
        {
            //validate the sent object from client side
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDB = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDB == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<MovieDTO, Movie>(moviedto, movieInDB);
            _context.SaveChanges();
        }

        // DELETE /api/movie/id
        public void DeleteMovie(int id)
        {
            var movieInDB = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDB == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDB);

            _context.SaveChanges();
        }
    }
}
