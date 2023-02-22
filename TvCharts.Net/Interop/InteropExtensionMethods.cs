using Microsoft.JSInterop;

namespace TvCharts.Net.Interop
{
    internal static class InteropExtensionMethods
    {
        public static JSModule LoadJSModule(this IJSRuntime jsRuntime, string path) => new JSModule(jsRuntime.InvokeAsync<IJSObjectReference>("import", path).AsTask());
    }
}
