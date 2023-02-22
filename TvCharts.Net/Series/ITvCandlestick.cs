﻿namespace TvCharts.Net.Series
{
    public interface ITvCandlestick : ISeriesValue
    {
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal Volume { get; set; }
    }
}
