using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IOiZ.Model;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace IOiZ.Charts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ChartsControl chartsControl = new ChartsControl();

        public MainWindow()
        {
            InitializeComponent();
            chartContent.Content = chartsControl;
            TrapNum a = new TrapNum(1, 2, 3, 4);
            TrapNum b = new TrapNum(2, 3, 4, 5);

            PreciseTrapNum a1 = new PreciseTrapNum(1, 2, 3, 4);
            PreciseTrapNum b1 = new PreciseTrapNum(2, 3, 4, 5);

            var c = a * b;
            var c1 = a1 * b1;
          //  chartsControl.AddNewSeries(a.GetPoints(), nameof(a));
            chartsControl.AddNewSeries(c1.GetPoints(), nameof(c1));
            chartsControl.AddNewSeries(c.GetPoints(), nameof(c));


        }
    }
}
