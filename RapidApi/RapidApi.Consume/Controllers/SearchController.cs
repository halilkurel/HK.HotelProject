using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.Consume.Models;
using System.Net.Http.Headers;

namespace RapidApi.Consume.Controllers
{
    public class SearchController : Controller
    {
        public async Task<IActionResult> IndexAsync(string cityName)
        {
            if(!string.IsNullOrEmpty(cityName))
            {
                List<BookingApiLocationSeachViewModel> model = new();

                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "0e26a75149msh5e771ca1305e2f8p114cf4jsnc2d2d74ea375" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                var response = await client.SendAsync(request);
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<List<BookingApiLocationSeachViewModel>>(body);
                    return View(model.Take(1).ToList());
                }
            }
            else
            {
                List<BookingApiLocationSeachViewModel> model = new();

                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?name=Berlin&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "0e26a75149msh5e771ca1305e2f8p114cf4jsnc2d2d74ea375" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                var response = await client.SendAsync(request);
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<List<BookingApiLocationSeachViewModel>>(body);
                    return View(model.Take(1).ToList());
                }
            }
            
        }
    }
}
