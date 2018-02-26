using IOiZ.Model;
using System.Windows;

namespace IOiZ.Charts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ChartsControl _chartsControl = new ChartsControl();

        public MainWindow()
        {
            InitializeComponent();
            ChartContent.Content = _chartsControl;
            var a = new TrapNum(1, 2, 3, 4);
            var b = new TrapNum(2, 3, 4, 5);

            var a1 = new PreciseTrapNum(1, 2, 3, 4);
            var b1 = new PreciseTrapNum(2, 3, 4, 5);

            var c = a * b;
            var c1 = a1 * b1;
            var d = c / c;
            var d1 = c1 / c1;
            _chartsControl.AddNewSeries(d.GetPoints(), nameof(d));
            _chartsControl.AddNewSeries(d1.GetPoints(), nameof(d1));
            _chartsControl.AddNewSeries(c1.GetPoints(), nameof(c1));
            _chartsControl.AddNewSeries(c.GetPoints(), nameof(c));
        }
    }
}
