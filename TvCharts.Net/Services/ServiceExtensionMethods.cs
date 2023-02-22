using Microsoft.Extensions.DependencyInjection;
using TvCharts.Net.Interop;

namespace TvCharts.Net.Services
{
    public static class ServiceExtensionMethods
    {
        public static void AddTvCharts(this IServiceCollection services)
        {
            services.AddScoped<ITvChartInterop, TvChartInterop>();
        }
        // TvChartInterop
    }
}
