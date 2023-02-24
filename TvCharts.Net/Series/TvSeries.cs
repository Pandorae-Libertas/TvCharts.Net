namespace TvCharts.Net.Series
{
    public delegate void SeriesDataChangedHandler(TvSeries series);

    public interface ITvSeries
    {
        public string Id { get; }
        public event SeriesDataChangedHandler? DataChanged;
        public abstract object? Format();

    }

    public abstract class TvSeries : ITvSeries
    {
        protected IEnumerable<ISeriesValue>? _data;
        public IEnumerable<ISeriesValue> Data
        {
            get => _data!;
            set
            {
                _data = value;
                OnDataChanged();
            }
        }

        public TvSeries()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            Id = new string(Enumerable.Repeat(chars, 32).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public TvSeries(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public event SeriesDataChangedHandler? DataChanged;

        public abstract object? Format();

        protected void OnDataChanged() => DataChanged?.Invoke(this);
    }
    public abstract class TvSeries<T> : TvSeries where T : ISeriesValue
    {
        public TvSeries() : base() { }
        public TvSeries(string id) : base(id) { }

        public new IEnumerable<T> Data
        {
            get => _data?.Select(x => (T)x);
            set
            {
                _data = value.Select(x => (ISeriesValue)x);
                OnDataChanged();
            }
        }
    }
}
