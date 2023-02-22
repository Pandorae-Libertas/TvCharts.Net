namespace TvCharts.Net.Series
{
    public class TvAreaSeries : TvSeries<ISeriesValue>
    {
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
