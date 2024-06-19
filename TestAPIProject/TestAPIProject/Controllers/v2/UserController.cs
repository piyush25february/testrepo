using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TestAPIProject.Interface;

namespace TestAPIProject.Controllers.v2
{
    [ApiController]
    [Route("api/v2/[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IUserInterface _user;
        private readonly HttpClient _httpClient;
        public UserController(IUserInterface user, IHttpClientFactory httpClientFactory)
        {
            _user = user;
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet]
        public ActionResult<string> UserIsAuth()
        {
            var result=_user.DoSomething();
            return result;
        }
        [HttpGet("combined")]
        public async Task<IActionResult> GetCombinedData()
        {
            try
            {
                // Make request to the first external API
                var firstApiResponse = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");
                firstApiResponse.EnsureSuccessStatusCode();
                var firstApiData = await firstApiResponse.Content.ReadAsStringAsync();

                // Make request to the second external API
                var secondApiResponse = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/comments");
                secondApiResponse.EnsureSuccessStatusCode();
                var secondApiData = await secondApiResponse.Content.ReadAsStringAsync();

                // Combine and return both responses
                return Ok(new { 
                    FirstApiData = firstApiData, 
                    SecondApiData = secondApiData 
                });
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error while fetching data from external API: {ex.Message}");
            }
        }
    }
}
