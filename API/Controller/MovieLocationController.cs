

using Microsoft.AspNetCore.Mvc;
using Application.Service;
using System;
using System.Threading.Tasks;

namespace API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieLocationController : ControllerBase
    {
        private readonly MovieLocationService _movieLocationService;

        public MovieLocationController(MovieLocationService movieLocationService)
        {
            _movieLocationService = movieLocationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovieLocations()
        {
            try
            {
                var movieLocations = await _movieLocationService.GetMovieLocationsAsync();
                return Ok(movieLocations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao obter as locações dos filmes: {ex.Message}");
            }
        }

        [HttpGet("byname")]
        public async Task<IActionResult> GetMovieLocationsByMovieName(string movieName)
        {
            try
            {
                var movieLocations = await _movieLocationService.GetMovieLocationsByMovieName(movieName);
                return Ok(movieLocations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao obter as locações dos filmes por nome: {ex.Message}");
            }
        }

        [HttpGet("byyear")]
        public async Task<IActionResult> GetMovieLocationsByYear(int year)
        {
            try
            {
                var movieLocations = await _movieLocationService.GetMovieLocationsByYear(year);
                return Ok(movieLocations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao obter as locações dos filmes por ano: {ex.Message}");
            }
        }
    }
}