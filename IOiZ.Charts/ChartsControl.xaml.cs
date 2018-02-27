using IOiZ.Model;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using LiveCharts.Configurations;

namespace IOiZ.Charts
{
    /// <summary>
    /// Interaction logic for ChartsControl.xaml
    /// </summary>
    public partial class ChartsControl
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        public Func<double, string> Formatter { get; set; }
        public double Base { get; set; }

        public ChartsControl()
        {
            InitializeComponent();
            Base = 10;

            var mapper = Mappers.Xy<ObservablePoint>()
                .X(point => Math.Log(point.X, Base)) //a 10 base log scale in the X axis
                .Y(point => point.Y);

            SeriesCollection = new SeriesCollection(mapper);



            //Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" };
            YFormatter = value => value.ToString("C");
            Formatter = value => Math.Pow(Base, value).ToString();
            DataContext = this;
        }

        public void AddSeries(TrapNum tn, string title)
        {
            AddSeries(PreciseTrapNum.Convert(tn).GetPoints(), title);
        }

        public void AddSeries(PreciseTrapNum ptn, string title)
        {
            AddSeries(ptn.GetPoints(), title);
        }

        public void AddSeries(List<Point> points, string title)
        {
            var values = new ChartValues<ObservablePoint>();
            foreach (var point in points)
                values.Add(new ObservablePoint((double)point.X, (double)point.Y));

            SeriesCollection.Add(new LineSeries
            {
                Title = title,
                Values = values,
                LineSmoothness = 0, //0: straight lines, 1: really smooth lines
                //  PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                PointGeometrySize = 0
            });
        }

        public void Clear()
        {
            SeriesCollection.Clear();
        }

    }
}
