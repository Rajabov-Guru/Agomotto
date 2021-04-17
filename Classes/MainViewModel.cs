using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agamotto.Classes
{
    class MainViewModel
    {
        public MainViewModel()
        {
            var model = new PlotModel { Title = "Cake Type Popularity" };
            //generate a random percentage distribution between the 5
            //cake-types (see axis below)
            var rand = new Random();
            double[] cakePopularity = new double[5];
            for (int i = 0; i < 5; ++i)
            {
                cakePopularity[i] = rand.NextDouble();
            }
            var sum = cakePopularity.Sum();
            var barSeries = new OxyPlot.Series.BarSeries
            {
                ItemsSource = new List<BarItem>(new[]
                {
                    new BarItem{ Value = (cakePopularity[0] / sum * 100) },
                    new BarItem{ Value = (cakePopularity[1] / sum * 100) },
                    new BarItem{ Value = (cakePopularity[2] / sum * 100) },
                    new BarItem{ Value = (cakePopularity[3] / sum * 100) },
                    new BarItem{ Value = (cakePopularity[4] / sum * 100) }
                }),
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0:.00}%"
            };
            model.Series.Add(barSeries);
            model.Axes.Add(new OxyPlot.Axes.CategoryAxis
            {
                Position = AxisPosition.Left,
                Key = "CakeAxis",
                ItemsSource = new[]
                {
                    "Apple cake",
                    "Baumkuchen",
                    "Bundt Cake",
                    "Chocolate cake",
                    "Carrot cake"
                }
            });
        
        }


    }
}
