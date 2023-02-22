using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using TvCharts.Net.Series;

namespace TvCharts.Net.Interop
{
    internal interface ITvChartInterop
    {
        public Task LoadChartAsync(ElementReference container, TvChart chart);
        public Task AddSeries(ITvSeries series, string chartId);
        public Task UpdateSeriesData(TvSeries series);

    }

    internal class TvChartInterop : ITvChartInterop
    {
        private readonly JSModule _jsModule;

        public TvChartInterop(IJSRuntime jsRuntime)
        {
            _jsModule = jsRuntime.LoadJSModule("./_content/TvCharts.Net/js/chartInterop.js");
        }
        public async Task LoadChartAsync(ElementReference container, TvChart chart)
        {
            await _jsModule.InvokeVoidAsync("loadChart", container, container.Id, chart.Options.Format());

            foreach (ITvSeries series in chart.Series)
                await AddSeries(series, container.Id);
        }

        public async Task AddSeries(ITvSeries series, string chartId)
        {
            switch (series)
            {
                case TvCandlestickSeries: await _jsModule.InvokeVoidAsync("addCandlestickSeries", chartId, series.Id, series.Format()); break;
                case TvLineSeries: await _jsModule.InvokeVoidAsync("addLineSeries", chartId, series.Id, series.Format()); break;
                case TvAreaSeries: await _jsModule.InvokeVoidAsync("addAreaSeries", chartId, series.Id, series.Format()); break;
                case TvHistogramSeries: await _jsModule.InvokeVoidAsync("addHistogramSeries", chartId, series.Id, series.Format()); break;
                default: throw new NotImplementedException(nameof(series));
            }
        }
        public async Task UpdateSeriesData(TvSeries series)
        {
            await _jsModule.InvokeVoidAsync("updateSeriesData", series.Id, series.Format());
        }
    }
}
