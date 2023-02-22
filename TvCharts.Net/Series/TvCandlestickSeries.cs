namespace TvCharts.Net.Series
{
public class TvCandlestickSeries : TvSeries<ITvCandlestick>
{
public TvCandlestickSeries() : base()
{

}
public TvCandlestickSeries(string id) : base(id)
{

}

public override object? Format()
{
if (Data is not null)
{
return Data.Select(x => new
{
time = new DateTimeOffset(x.Date, TimeSpan.Zero).ToUnixTimeSeconds(),
open = x.Open,
high = x.High,
low = x.Low,
close = x.Close
});
}

return null;
}
}
}
