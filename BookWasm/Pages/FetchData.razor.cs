using BookWasm.Data;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BookWasm.Pages
{
    public partial class FetchData
    {
        [Inject] HttpClient Http { get; set; } = null!;

        private WeatherForecast[]? forecasts;

        protected override async Task OnInitializedAsync()
        {
            forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
        }

    }
}
