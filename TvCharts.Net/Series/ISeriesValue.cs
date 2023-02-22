namespace TvCharts.Net.Series
{
public interface ISeriesValue
{
public DateTime Date { get; }
public object GetValue();
}
}
