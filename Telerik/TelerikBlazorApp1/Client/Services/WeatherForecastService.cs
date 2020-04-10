using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TelerikBlazorApp1.Shared;
using Microsoft.AspNetCore.Components;

namespace TelerikBlazorApp1.Services
{
    public class WeatherForecastService
    {
        [Inject]
        private HttpClient Http { get; set; }

        public WeatherForecastService(HttpClient client)
        {
            Http = client;
        }

        public async Task<List<WeatherForecast>> GetForecastListAsync(DateTime startDate)
        {
            var data = await Http.GetJsonAsync<List<WeatherForecast>>("WeatherForecast?startDate=" + startDate.ToString(CultureInfo.InvariantCulture));
            return data;
        }

        public async Task UpdateForecastAsync(WeatherForecast forecastToUpdate)
        {
            await Http.PostJsonAsync("WeatherForecast", forecastToUpdate);
        }

        public async Task DeleteForecastAsync(WeatherForecast forecastToRemove)
        {
            await Http.DeleteAsync("WeatherForecast?idToRemove=" + forecastToRemove.Id);
        }

        public async Task InsertForecastAsync(WeatherForecast forecastToInsert)
        {
            await Http.PutJsonAsync("WeatherForecast", forecastToInsert);
        }
    }
}