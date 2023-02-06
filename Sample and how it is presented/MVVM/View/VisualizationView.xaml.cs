using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
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
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Sample_and_how_it_is_presented.MVVM.Model;
using SkiaSharp;
using System.Windows.Threading;
using Sample_and_how_it_is_presented.Core;

namespace Sample_and_how_it_is_presented.MVVM.View
{
	/// <summary>
	/// Interaction logic for VisualizationView.xaml
	/// </summary>
	public partial class VisualizationView : UserControl
	{

		public VisualizationView()
		{
			InitializeComponent();

			if (Probability_theory.Numbers.Count != 0)
			{
				displayChartRow1();
				displayChartRow2();
				displayChartRow3();
				displayChartRow4();
			}

			DataContext = this;
		}

		public SeriesCollection AverageSeries1 { get; private set; } = new SeriesCollection();
		public string[] LabelsAverageSeries1 { get; private set; } = new string[0];
		public Func<double, string> YFormatterAverageSeries1 { get; private set; } = value => value.ToString("C");
		public SeriesCollection AverageSeries2 { get; private set; } = new SeriesCollection();
		public string[] LabelsAverageSeries2 { get; private set; } = new string[0];
		public Func<double, string> YFormatterAverageSeries2 { get; private set; } = value => value.ToString("C");

		public SeriesCollection AccumulatedFrequencySeries1 { get; private set; } = new SeriesCollection();
		public string[] LabelsAccumulatedFrequency1 { get; private set; } = new string[0];
		public Func<double, string> YFormatterAccumulatedFrequency1 { get; private set; } = value => value.ToString("C");
		public SeriesCollection AccumulatedFrequencySeries2 { get; private set; } = new SeriesCollection();
		public string[] LabelsAccumulatedFrequency2 { get; private set; } = new string[0];
		public Func<double, string> YFormatterAccumulatedFrequency2 { get; private set; } = value => value.ToString("C");

		public SeriesCollection RelativeFrequencySeries1 { get; private set; } = new SeriesCollection();
		public string[] LabelsRelativeFrequency1 { get; private set; } = new string[0];
		public Func<double, string> YFormatterRelativeFrequency1 { get; private set; } = value => value.ToString("C");
		public SeriesCollection RelativeFrequencySeries2 { get; private set; } = new SeriesCollection();
		public string[] LabelsRelativeFrequency2 { get; private set; } = new string[0];
		public Func<double, string> YFormatterRelativeFrequency2 { get; private set; } = value => value.ToString("C");

		public SeriesCollection RelativeCumulativeFrequencySeries1 { get; private set; } = new SeriesCollection();
		public string[] LabelsRelativeCumulativeFrequency1 { get; private set; } = new string[0];
		public Func<double, string> YFormatterRelativeCumulativeFrequency1 { get; private set; } = value => value.ToString("C");
		public SeriesCollection RelativeCumulativeFrequencySeries2 { get; private set; } = new SeriesCollection();
		public string[] LabelsRelativeCumulativeFrequency2 { get; private set; } = new string[0];
		public Func<double, string> YFormatterRelativeCumulativeFrequency2 { get; private set; } = value => value.ToString("C");

		private void displayChartRow1()
		{
			var labels = Probability_theory.TableRowsView.Select(x => x.Average.ToString() + "lol!").ToArray();
			var values = new ChartValues<int>(Probability_theory.TableRowsView.Select(x => x.Frequency));
			
			AverageSeries1 = new SeriesCollection
			{
				new LineSeries
				{
					Title = "Полигон частот",
					Values = values
				}
			};
			LabelsAverageSeries1 = labels;
	

			
			AverageSeries2 = new SeriesCollection
			{
				new ColumnSeries
				{
					Title = "Гистограмма частот",
					Values =  values
				}
			};
			LabelsAverageSeries2 = labels;
		}
		private void displayChartRow2(){
			var labels = Probability_theory.TableRowsView.Select(x => x.Average.ToString()).ToArray();
			var values = new ChartValues<int>(Probability_theory.TableRowsView.Select(x => x.AccumulatedFrequency));

			AccumulatedFrequencySeries1 = new SeriesCollection
			{
				new LineSeries
				{
					Title = "Полигон накопленных частот",
					Values = values
				}
			};
			LabelsAccumulatedFrequency1 = labels;

			AccumulatedFrequencySeries2 = new SeriesCollection
			{
				new ColumnSeries
				{
					Title = "Гистограмма накопленных частот",
					Values =  values
				}
			};
			LabelsAccumulatedFrequency2 = labels;
		}
		private void displayChartRow3()
		{
			var labels = Probability_theory.TableRowsView.Select(x => x.Average.ToString()).ToArray();
			var values = new ChartValues<float>(Probability_theory.TableRowsView.Select(x => x.RelativeFrequency));

			RelativeFrequencySeries1 = new SeriesCollection
			{
				new LineSeries
				{
					Title = "Полигон относительных частот",
					Values = values
				}
			};
			LabelsAccumulatedFrequency1 = labels;

			RelativeFrequencySeries2 = new SeriesCollection
			{
				new ColumnSeries
				{
					Title = "Гистограмма относительных частот",
					Values =  values
				}
			};
			LabelsAccumulatedFrequency2 = labels;
		}
		private void displayChartRow4()
		{
			var labels = Probability_theory.TableRowsView.Select(x => x.Average.ToString()).ToArray();
			var values = new ChartValues<float>(Probability_theory.TableRowsView.Select(x => x.RelativeCumulativeFrequency));

			RelativeCumulativeFrequencySeries1 = new SeriesCollection
			{
				new LineSeries
				{
					Title = "Полигон относительных накопленных частот",
					Values = values
				}
			};
			LabelsRelativeCumulativeFrequency1 = labels;

			RelativeCumulativeFrequencySeries2 = new SeriesCollection
			{
				new ColumnSeries
				{
					Title = "Гистограмма относительных накопленных частот",
					Values =  values
				}
			};
			LabelsRelativeCumulativeFrequency2 = labels;
		}
	}
}
