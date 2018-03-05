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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            view = FindViewById<PlotView>(Resource.Id.plot_view);

            var plotModel = new PlotModel
            {
                Title = "OxyPlot Demo"
            };
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom});
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0 });

            var series1 = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White
            };

            series1.Points.Add(new DataPoint(0.0, 6.0));
            series1.Points.Add(new DataPoint(1.4, 2.1));
            series1.Points.Add(new DataPoint(2.0, 4.2));
            series1.Points.Add(new DataPoint(3.3, 2.3));
            series1.Points.Add(new DataPoint(4.7, 7.4));
            series1.Points.Add(new DataPoint(6.0, 6.2));
            series1.Points.Add(new DataPoint(8.9, 8.9));

            plotModel.Series.Add(series1);
        }
    }
}

