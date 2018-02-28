using System.Collections.Generic;
using System.IO;
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
            var ctn = new TrapNumGenerator<CTN>();
            //TrapNumGenerator<CPTN> cptn = new TrapNumGenerator<CPTN>();

            var UZM1 = ctn.GetObject(Probability.VerySmall);
            var UZM2 = ctn.GetObject(Probability.VerySmall);
            var UZS = ctn.GetObject(Probability.VerySmall);
            var UM = ctn.GetObject(Probability.Small);
            var US1 = ctn.GetObject(Probability.Average);
            var US2 = ctn.GetObject(Probability.Average);
            var AAP = ctn.GetObject(Probability.Average);
            var ASE = ctn.GetObject(Probability.Big);


            var T = UZM1 * UZM2 + US1 + UZS + US2 + UM + AAP * ASE;

            var TwUZM1 = T - (UZM2 + US1 + UZS + US2 + UM + AAP * ASE);
            var TwUZM2 = T - (UZM1 + US1 + UZS + US2 + UM + AAP * ASE);
            var TwUZS = T - (UZM1 * UZM2 + US1 + US2 + UM + AAP * ASE);
            var TwUM = T - (UZM1 * UZM2 + US1 + UZS + US2 + AAP * ASE);
            var TwUS1 = T - (UZM1 * UZM2 + UZS + US2 + UM + AAP * ASE);
            var TwUS2 = T - (UZM1 * UZM2 + US1 + UZS + UM + AAP * ASE);
            var TwAAP = T - (UZM1 * UZM2 + US1 + UZS + US2 + UM + ASE);
            var TwASE = T - (UZM1 * UZM2 + US1 + UZS + US2 + UM + AAP);


            List<string> results = new List<string>();

            // results.Add(T.ToString());

            results.Add(TwUZM1.ToString());
            results.Add(TwUZM2.ToString());
            results.Add(TwUZS.ToString());
            results.Add(TwUM.ToString());
            results.Add(TwUS1.ToString());
            results.Add(TwUS2.ToString());
            results.Add(TwAAP.ToString());
            results.Add(TwASE.ToString());

            File.WriteAllLines("results.txt", results);

            // var d = c / c;
            //   var d1 = c1 / c1;
            //  _chartsControl.AddSeries(d.GetPoints(), nameof(d));
            // _chartsControl.AddSeries(CountT.Count(), "T");
            // _chartsControl.AddSeries(CountT.CountPrecise(), "Tp");
            _chartsControl.AddSeries(TwUZM1, nameof(TwUZM1));
            _chartsControl.AddSeries(TwUZM2, nameof(TwUZM2));
            _chartsControl.AddSeries(TwUZS, nameof(TwUZS));
            _chartsControl.AddSeries(TwUM, nameof(TwUM));
            _chartsControl.AddSeries(TwUS1, nameof(TwUS1));
            _chartsControl.AddSeries(TwUS2, nameof(TwUS2));
            _chartsControl.AddSeries(TwAAP, nameof(TwAAP));
            _chartsControl.AddSeries(TwASE, nameof(TwASE));





            // _chartsControl.AddSeries(a.GetPoints(), nameof(a));
        }
    }
}
