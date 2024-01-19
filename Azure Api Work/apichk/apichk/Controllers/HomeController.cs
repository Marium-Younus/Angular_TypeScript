using apichk.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text.Json.Nodes;
using static System.Net.WebRequestMethods;

namespace apichk.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TmdbService _tmdbService;
        public HomeController(ILogger<HomeController> logger, TmdbService tmdbService)
        {
            _logger = logger;
            _tmdbService = tmdbService;
        }   
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string movie_name)
        {
            WebClient web = new WebClient();
            string url = web.DownloadString("https://www.omdbapi.com/?t="+movie_name+"&apikey=746026c4");
            JsonNode data = JsonNode.Parse(url);
            var year = data["Year"];
            var title = data["Title"];
            var image = data["Poster"];
            ViewBag.img = image;
            ViewBag.t = title;            
            ViewBag.y = year;
            return View();
        }
        [HttpGet("popular")]
        public async Task<IActionResult> TheMovieDB_API()
         {
            var response = await _tmdbService.GetPopularMoviesAsync();
            ViewBag.imageurl = "https://image.tmdb.org/t/p/original";
            return View(response);
        }

        public async Task<IActionResult> NowPlayingMovie()
        {
            var response = await _tmdbService.GetNowPlayingMovie();
            ViewBag.imageurl = "https://image.tmdb.org/t/p/original";
            return View(response);
        }
        public async Task<IActionResult> UpComingMovie()
        {
            var response = await _tmdbService.GetUpComingMovie();
            ViewBag.imageurl = "https://image.tmdb.org/t/p/original";
            return View(response);
        }
        public async Task<IActionResult> TopRatedMovie()
        {
            var response = await _tmdbService.GetTopRatedMopvie();
            ViewBag.imageurl = "https://image.tmdb.org/t/p/original";
            return View(response);
        }
        //---------------------------------------------------------------
        public async Task<IActionResult> TvPopular()
        {
            var response = await _tmdbService.GetTvPopular();
            ViewBag.imageurl = "https://image.tmdb.org/t/p/original";
            return View(response);
        }
        public async Task<IActionResult> TopRatedTvShow()
        {
            var response = await _tmdbService.GetTopRatedTv();
            ViewBag.imageurl = "https://image.tmdb.org/t/p/original";
            return View(response);
        }

      

        //---------------------------------------------------------------
        public async Task<IActionResult> PopularPeople()
        {
            var response = await _tmdbService.GetPopularPeople();
            ViewBag.imageurl = "https://image.tmdb.org/t/p/original";
            return View(response);
        }
    }
}