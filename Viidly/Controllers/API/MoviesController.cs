using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Viidly.Models;
using Viidly.Dto;
using System.Data.Entity;
using AutoMapper;


namespace Viidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        //GET/api/movies
        public IHttpActionResult Getmovies()
        {
            
            return Ok( _context.movies.Include( m=>m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>));
        }
        //GET/api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var Movie = _context.movies.SingleOrDefault(c => c.Id == id);
            if (Movie == null)
                return NotFound();
            return Ok(Mapper.Map<Movie, MovieDto>(Movie));
        }
        //POST/api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            movie.NumInStock = movieDto.NumberInStock;
            _context.movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //PUT/api/movies/1
        [HttpPut]
        public IHttpActionResult EditMovie(int id, MovieDto MovieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var MovieInDb = _context.movies.SingleOrDefault(c => c.Id == id);
            if (MovieInDb == null)
                return NotFound();
            Mapper.Map(MovieDto, MovieInDb);
            MovieInDb.NumInStock = MovieDto.NumberInStock;
            _context.SaveChanges();
            return Ok();
        }
        //DELETE/api/Movies
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var MovieInDb = _context.movies.SingleOrDefault(c => c.Id == id);
            if (MovieInDb == null)
                return NotFound();
            _context.movies.Remove(MovieInDb);
            _context.SaveChanges();
            return Ok();
        }

    }
}
