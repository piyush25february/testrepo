using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestAPIProject.Controllers.v2
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallExternalAPIController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public CallExternalAPIController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetMergedData()
        {
            var data1 = await CallAPI("https://abc.com/api/data");
            var data2 = await CallAPI("https://abc.com/api/data");
            var data3 = await CallAPI("https://abc.com/api/data");

            return Ok(new { APIData1=data1, APIData2 = data2, APIData3 = data3, });
        
        }

        private async Task<ActionResult<string>> CallAPI(string url)
        {
            var data=await _httpClient.GetAsync(url);
            data.EnsureSuccessStatusCode();
            return data.Content.ToString();
        }
    }
}
