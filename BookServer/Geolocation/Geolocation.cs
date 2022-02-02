using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BookServer.Geolocation
{
    public class Geolocation
    {
        private Action<Position>? OnGetPosition;
        private Action<PositionError>? OnGetPositionError;

        private readonly IJSRuntime js;
        public Geolocation(IJSRuntime js)
        {
            this.js = js;
        }

        public async ValueTask<bool> HasGeolocationFeature() =>
            await js.InvokeAsync<bool>("blazorGeolocation.hasGeolocaitonFeature");


        [JSInvokable]
        public void RaiseOnGetPosition(Position p) => OnGetPosition?.Invoke(p);

        [JSInvokable]
        public void RaiseOnGetPositionError(PositionError err) => OnGetPositionError?.Invoke(err);

        public async ValueTask GetCurrentPosition(Action<Position> onSuccess, Action<PositionError> onError, PositionOptions? options = null)
        {
            OnGetPosition = onSuccess;
            OnGetPositionError = onError;
            await js.InvokeVoidAsync("blazorGeolocation.getCurrentPosition", DotNetObjectReference.Create(this), options);
        }
    }

    public class PositionOptions
    {
        public bool EnableHighAccuracy { get; set; } = false;
        public int Timeout { get; set; }
        public int MaximumAge { get; set; } = 0;
    }

    public class Coords
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class Position
    {
        public Coords? Coords { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public enum PositionError
    {
        PERMISSION_DENIED = 1,
        POSITION_UNAVAILABLE,
        TIMEOUT
    }
}
