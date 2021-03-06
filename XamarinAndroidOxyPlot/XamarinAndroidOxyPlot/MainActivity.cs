﻿using System;
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

      

        private void Btn3_Click(object sender, System.EventArgs e)
        {
            view.Model = ViewModel3();
        }

        private void Btn2_Click(object sender, System.EventArgs e)
        {
            view.Model = ViewModel2();
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
        private PlotModel ViewModel2()
        {
            PlotModel myModel = new PlotModel { Title = "Title"};
            var ls = new LineSeries()
            {
                Color = OxyColors.Blue,
                MarkerType = MarkerType.Circle, 
                MarkerSize = 3,
                MarkerStroke = OxyColors.White,
                MarkerStrokeThickness = 1.0
            };
            //(sin(x)+sin(3x)/3+sin(5x)/5+...");
            int n= 10;
            for (double x = -10; x < 10; x+=0.2)
            {
                double y = 0;
                for (int i = 0 ; i < n; i++)
                {
                    int j = i * 2 + 1;
                    y += Math.Sin(j * x) / j;
                }
                ls.Points.Add(new DataPoint(x,y));
            }
            myModel.Series.Add(ls);
            return myModel;
        }
        private PlotModel ViewModel3()
        {
            PlotModel model = new PlotModel {Title = "Title"};
            PieSeries ps = new PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0
            };
            ps.Slices.Add(new PieSlice("Africa", 1030){IsExploded = false, Fill = OxyColors.PaleVioletRed});
            ps.Slices.Add(new PieSlice("Americas", 929){IsExploded = true});
            ps.Slices.Add(new PieSlice("Asia", 4157) { IsExploded = true });
            ps.Slices.Add(new PieSlice("Europa", 739) { IsExploded = true });
            ps.Slices.Add(new PieSlice("Oceania", 35) { IsExploded = true });

           model.Series.Add(ps);
            return model;
        }
        private PlotModel ViewModel4()
        {
            var model4 = new PlotModel
            {
                Title = "Title",
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0
            };
            var s1 = new BarSeries() {Title = "2015", StrokeColor = OxyColors.Black, FillColor = OxyColors.BlueViolet,StrokeThickness = 1};
            s1.Items.Add(new BarItem {Value= 25});
            s1.Items.Add(new BarItem { Value = 137});
            s1.Items.Add(new BarItem { Value = 18});
            s1.Items.Add(new BarItem { Value = 40});

            var s2 = new BarSeries() { Title = "2016", Background = OxyColors.Gold,StrokeColor = OxyColors.Blue,  StrokeThickness = 1};
            s2.Items.Add(new BarItem { Value = 12});
            s2.Items.Add(new BarItem { Value = 14});
            s2.Items.Add(new BarItem { Value = 120});
            s2.Items.Add(new BarItem { Value = 26});

            var categoryAxis = new CategoryAxis {Position = AxisPosition.Left};
            categoryAxis.Labels.Add("Tablets");
            categoryAxis.Labels.Add("PCs");
            categoryAxis.Labels.Add("Cameras");
            categoryAxis.Labels.Add("Laptops");

            var valueAxis = new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                MinimumPadding = 0,
                MaximumPadding = 0.06,
                AbsoluteMaximum = 0,
                Minimum = 0,
                Maximum = 150
            };

            model4.Series.Add(s1);
            model4.Series.Add(s2);

            model4.Axes.Add(categoryAxis);
            model4.Axes.Add(valueAxis);

            return model4;
        }
    }
}

