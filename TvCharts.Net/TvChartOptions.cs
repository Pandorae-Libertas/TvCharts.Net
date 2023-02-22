namespace TvCharts.Net
{
public class TvChartOptions
{
// Style options
public string BackgroundColor { get; set; } = "#171b26";
public string TextColor { get; set; } = "#d1D4Dc";

public object Format()
{
return new
{
backgroundColor = BackgroundColor,
textColor = TextColor
};
}
}
}
