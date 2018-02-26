using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using IOiZ.Model;

namespace IOiZ.Charts
{
    /// <summary>
    /// Interaction logic for ChartsControl.xaml
    /// </summary>
    public partial class ChartsControl : UserControl
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public ChartsControl()
        {
            InitializeComponent();
            SeriesCollection = new SeriesCollection();
            //Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" };
            // YFormatter = value => value.ToString("C");
            DataContext = this;
        }

        public void AddNewSeries(List<Point> points, string title)
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

    }
}
