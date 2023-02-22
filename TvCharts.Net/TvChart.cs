using TvCharts.Net.Series;

namespace TvCharts.Net
{
    public class TvChart
    {
        private List<TvSeries> _series;
        internal IReadOnlyList<TvSeries> Series
        {
            get => _series.AsReadOnly();
        }

        internal TvChartOptions Options { get; set; }
        internal event EventHandler<TvSeries>? SeriesAdded;
        internal event EventHandler<TvSeries>? SeriesDataChanged;

        public TvChart()
        {
            _series = new List<TvSeries>();
            Options = new TvChartOptions();
        }

        public void AddSeries(TvSeries series)
        {
            _series.Add(series);
            series.DataChanged += (changedSeries) => SeriesDataChanged?.Invoke(this, changedSeries);

            SeriesAdded?.Invoke(this, series);
        }

        public TvSeries? GetSeries(string seriesId) => _series.Find(x => x.Id == seriesId);
    }
}
