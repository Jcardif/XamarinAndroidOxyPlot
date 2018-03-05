using Android.App;
using Android.Widget;
using Android.OS;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Xamarin.Android;

namespace XamarinAndroidOxyPlot
{
    [Activity(Label = "XamarinAndroidOxyPlot", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private PlotView view;
        private Button btn1, btn2, btn3, btn4;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            btn1 = FindViewById<Button>(Resource.Id.button1);
            btn2 = FindViewById<Button>(Resource.Id.button2);
            btn3 = FindViewById<Button>(Resource.Id.button3);
            btn4 = FindViewById<Button>(Resource.Id.button4);
            view = FindViewById<PlotView>(Resource.Id.oxyplotView1);

            btn1.Click += Btn1_Click;
            btn2.Click += Btn2_Click;
            btn3.Click += Btn3_Click;
            btn4.Click += Btn4_Click;

        }

        private void Btn4_Click(object sender, System.EventArgs e)
        {
            view.Model = ViewModel4();
        }

        private PlotModel ViewModel4()
        {
            throw new System.NotImplementedException();
        }

        private void Btn3_Click(object sender, System.EventArgs e)
        {
            view.Model = ViewModel3();
        }

        private PlotModel ViewModel3()
        {
            throw new System.NotImplementedException();
        }

        private void Btn2_Click(object sender, System.EventArgs e)
        {
            view.Model = ViewModel2();
        }

        private PlotModel ViewModel2()
        {
            throw new System.NotImplementedException();
        }


        private void Btn1_Click(object sender, System.EventArgs e)
        {
            view.Model = ViewModel1();
        }

        private PlotModel ViewModel1()
        {
            var plotModel=new PlotModel{Title = "Title Here"};
            plotModel.Axes.Add(new LinearAxis{Position = AxisPosition.Bottom});
            plotModel.Axes.Add(new LinearAxis {Position = AxisPosition.Left, Maximum = 10, Minimum = 0});

            var series1 = new LineSeries()
            {
                Color = OxyColors.Yellow,
                MarkerType = MarkerType.Star,
                MarkerSize = 5,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.Black,
                MarkerStrokeThickness = 4.0
            };
            series1.Points.Add(new DataPoint(0.0, 6.0));
            series1.Points.Add(new DataPoint(1.4, 2.1));
            series1.Points.Add(new DataPoint(2.0, 4.2));
            series1.Points.Add(new DataPoint(3.3, 2.3));
            series1.Points.Add(new DataPoint(4.7, 7.4));
            series1.Points.Add(new DataPoint(6.0, 6.2));
            series1.Points.Add(new DataPoint(8.9, 8.9));

            plotModel.Series.Add(series1);
            return plotModel;
        }
    }
}

