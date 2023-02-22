namespace TvCharts.Net.Series
{
    public class TvLineSeries : TvSeries<ISeriesValue>
    {
        public TvLineSeries() : base() { }
        public TvLineSeries(string id) : base(id) { }

        public override object? Format()
        {
            if (Data is not null)
            {
                return Data.Select(x => new
                {
                    time = new DateTimeOffset(x.Date, TimeSpan.Zero).ToUnixTimeSeconds(),
                    value = x.GetValue()
                });
            }

            return null;
        }
    }
}
