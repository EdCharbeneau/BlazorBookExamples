using BookServer.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BookServer.Pages
{
    public partial class FetchData
    {
        [Inject]
        WeatherForecastService ForecastService { get; set; } = null!;

        private WeatherForecast[]? forecasts;

        protected override async Task OnInitializedAsync()
        {
            forecasts = await ForecastService.GetForecastAsync(DateTime.Now);
        }
    }
}
