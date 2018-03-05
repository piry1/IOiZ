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
            var cptn = new TrapNumGenerator<CPTN>();

            //  ZeroReduction(ctn);

            //var UZM1 = ctn.GetObject(Probability.VerySmall);
            //var UZM2 = ctn.GetObject(Probability.VerySmall);
            //var UZS = ctn.GetObject(Probability.VerySmall);
            //var UM = ctn.GetObject(Probability.Small);
            //var US1 = ctn.GetObject(Probability.Average);
            //var US2 = ctn.GetObject(Probability.Average);
            //var AAP = ctn.GetObject(Probability.Average);
            //var ASE = ctn.GetObject(Probability.Big);

            //var T0 = UZM1 * UZM2 + US1 + UZS + US2 + UM + AAP * ASE;
            //var T1 = UZM1 * UZM2 + US1 + UZS + US2 + UM + AAP * ASE;
            //var T2 = UZM1 * UZM2 + US1 + UZS + US2 + UM + AAP * ASE;

            //List<string> results = new List<string>();

            //results.Add(T0.ToString());

            //results.Add(T1.ToString());
            //results.Add(T2.ToString());

            //File.WriteAllLines("results.txt", results);

            var a = ctn.GetObject(Probability.Big);
            var b = cptn.GetObject(Probability.Big);

            var A = a * a;
            var B = b * b;

            _chartsControl.AddSeries(A, "Przybliżone");
            _chartsControl.AddSeries(B, "Dokładne");
        }

        private void ZeroReduction(TrapNumGenerator<CTN> ctn)
        {
            var zero = new CTN(0, 0, 0, 0);

            var UZM1 = ctn.GetObject(Probability.VerySmall);
            var UZM2 = ctn.GetObject(Probability.VerySmall);
            var UZS = ctn.GetObject(Probability.VerySmall);
            var UM = ctn.GetObject(Probability.Small);
            var US1 = ctn.GetObject(Probability.Average);
            var US2 = ctn.GetObject(Probability.Average);
            var AAP = ctn.GetObject(Probability.Average);
            var ASE = ctn.GetObject(Probability.Big);


            var T = UZM1 * UZM2 + US1 + UZS + US2 + UM + AAP * ASE;

            var TwUZM1 = T - (zero * UZM2 + US1 + UZS + US2 + UM + AAP * ASE);
            var TwUZM2 = T - (UZM1 * zero + US1 + UZS + US2 + UM + AAP * ASE);
            var TwUZS = T - (UZM1 * UZM2 + US1 + zero + US2 + UM + AAP * ASE);
            var TwUM = T - (UZM1 * UZM2 + US1 + UZS + zero + US2 + AAP * ASE);
            var TwUS1 = T - (UZM1 * UZM2 + zero + UZS + US2 + UM + AAP * ASE);
            var TwUS2 = T - (UZM1 * UZM2 + US1 + zero + UZS + UM + AAP * ASE);
            var TwAAP = T - (UZM1 * UZM2 + US1 + UZS + US2 + UM + ASE * zero);
            var TwASE = T - (UZM1 * UZM2 + US1 + UZS + US2 + UM + AAP * zero);


            List<string> results = new List<string>();

            results.Add(T.ToString());

            results.Add(TwUZM1.ToString());
            results.Add(TwUZM2.ToString());
            results.Add(TwUZS.ToString());
            results.Add(TwUM.ToString());
            results.Add(TwUS1.ToString());
            results.Add(TwUS2.ToString());
            results.Add(TwAAP.ToString());
            results.Add(TwASE.ToString());

            File.WriteAllLines("results.txt", results);

            _chartsControl.AddSeries(TwUZM1, "UZM1");
            _chartsControl.AddSeries(TwUZM2, "UZM2");
            _chartsControl.AddSeries(TwUZS, "UZS");
            _chartsControl.AddSeries(TwUM, "UM");
            _chartsControl.AddSeries(TwUS1, "US1");
            _chartsControl.AddSeries(TwUS2, "US2");
            _chartsControl.AddSeries(TwAAP, "AAP");
            _chartsControl.AddSeries(TwASE, "ASE");
        }
    }
}
