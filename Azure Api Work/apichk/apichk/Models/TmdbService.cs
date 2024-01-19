using Humanizer;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace apichk.Models
{
    public class TmdbService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://api.themoviedb.org/3/";
        private const string ApiKey = "d7b33ee6f00cd6bb15737da7f98b3721";  
        public TmdbService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<TmdbResponse> GetPopularMoviesAsync()
        {
            var url = $"{BaseUrl}/movie/popular?language=en-US&page=1&api_key={ApiKey}";


            
            var response = await _httpClient.GetStringAsync(url);

            return JsonConvert.DeserializeObject<TmdbResponse>(response);
        }


        public async Task<UpComingRes> GetUpComingMovie()
        {
            var url = $"https://api.themoviedb.org/3/movie/upcoming?language=en-US&api_key={ApiKey}";
            var response = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<UpComingRes>(response);
        }

        public async Task<PopularPeopleRes> GetPopularPeople()
        {
            var url = $"https://api.themoviedb.org/3/person/popular?language=en-US&page=1&api_key={ApiKey}";
            var response = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<PopularPeopleRes>(response);
        }

        public async Task<NowPlayingRes> GetNowPlayingMovie()
        {
            var url = $"https://api.themoviedb.org/3/movie/now_playing?language=en-US&page=1&api_key={ApiKey}";
            var response = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<NowPlayingRes>(response);
        } 
        public async Task<TopRated_MovieRes> GetTopRatedMopvie()
        {
            var url = $"https://api.themoviedb.org/3/movie/top_rated?language=en-US&page=1&api_key={ApiKey}";
            var response = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<TopRated_MovieRes>(response);
        }
        //------------------------------------
        public async Task<TvPopular_Res> GetTvPopular()
        {
            var url = $"https://api.themoviedb.org/3/tv/popular?language=en-US&page=1&api_key={ApiKey}";
            var response = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<TvPopular_Res>(response);
        }

        public async Task<TopRated_TvRes> GetTopRatedTv()
        {
            var url = $"https://api.themoviedb.org/3/tv/top_rated?language=en-US&page=1&api_key={ApiKey}";
            var response = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<TopRated_TvRes>(response);
        }
       
    }
    //-------------------------------------------------------------------------
    public class TV
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string poster_path { get; set; }
        public DateTime first_air_date { get; set; }
    }
    public class TopRated_TvRes
    {
        public List<TV> Results { get; set; }
    }
    public class TvPopular
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string poster_path { get; set; }
        public DateTime first_air_date { get; set; }
    }
    public class TvPopular_Res
    {
        public List<TvPopular> Results { get; set; }
    }

    //---------------------------------------------------------

    public class MovieTR
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string poster_path { get; set; }
        public DateTime first_air_date { get; set; }
        public double vote_average { get; set; }
    }
    public class TopRated_MovieRes
    {
        public List<MovieTR> Results { get; set; }
    }
    //-------------------------------------------------------------------------------
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string poster_path { get; set; }
        public DateTime release_date { get; set; }
        public float vote_average { get; set; }
    }
    public class TmdbResponse
    {
        public List<Movie> Results { get; set; }
    }
    //-------------------------------------------------------------------------------
    public class NowPlayingMovie
    {
        public string Title { get; set; }
        public string poster_path { get; set; }
        public DateTime release_date { get; set; }
       
    }
    public class NowPlayingRes
    {
        public List<NowPlayingMovie> Results { get; set; }
    }
    //-------------------------------------------------------------------------------
    public class UpComingMovie
    {
        public string Title { get; set; }
        public string backdrop_path { get; set; }
        public DateTime release_date { get; set; }
        public string overview { get; set; }
    }
    public class UpComingRes
    {
        public List<UpComingMovie> Results { get; set; }
    }
 //-------------------------------------------------------------------------
    public class People
    {
        public string name { get; set; }
        public string profile_path { get; set; }
        public string popularity { get; set; }
        public string title { get; set; }
    }
    public class PopularPeopleRes
    {
        public List<People> Results { get; set; }
    }
  

}
