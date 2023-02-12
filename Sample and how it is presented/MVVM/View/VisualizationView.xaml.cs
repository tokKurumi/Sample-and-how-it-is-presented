using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Sample_and_how_it_is_presented.MVVM.Model;

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
				chart1();
				chart2();
				chart3();
				chart4();
			}

			DataContext = this;
		}

		public SeriesCollection AverageSeries1 { get; private set; } = new SeriesCollection();
		public SeriesCollection AverageSeries2 { get; private set; } = new SeriesCollection();

		public SeriesCollection AccumulatedFrequencySeries1 { get; private set; } = new SeriesCollection();
		public SeriesCollection AccumulatedFrequencySeries2 { get; private set; } = new SeriesCollection();

		public SeriesCollection RelativeFrequencySeries1 { get; private set; } = new SeriesCollection();
		public SeriesCollection RelativeFrequencySeries2 { get; private set; } = new SeriesCollection();

		public SeriesCollection RelativeCumulativeFrequencySerise1 { get; private set; } = new SeriesCollection();
		public SeriesCollection RelativeCumulativeFrequencySerise2 { get; private set; } = new SeriesCollection();

		private void chart1()
		{
			var values = new ChartValues<ObservablePoint>
			(
				Probability_theory.TableRowsView.Select(x => x.Average)
				.Zip(Probability_theory.TableRowsView.Select(x => x.Frequency),
					(x, y) => new ObservablePoint(x, y))
			);

			AverageSeries1 = new SeriesCollection
			{
				new LineSeries
				{
					Values = values,
					Title = "Полигон частот"
				}
			};
			averageSeriesChartAxisX1.LabelFormatter = values => values.ToString("F2", CultureInfo.InvariantCulture);
			averageSeriesChartAxisY1.LabelFormatter = values => values.ToString("F2", CultureInfo.InvariantCulture);
			
			AverageSeries2 = new SeriesCollection
			{
				new ColumnSeries
				{
					Values = values,
					Title = "Гистограмма частот"
				}
			};
			averageSeriesChartAxisX2.LabelFormatter = values => values.ToString("F2", CultureInfo.InvariantCulture);
			averageSeriesChartAxisY2.LabelFormatter = values => values.ToString("F2", CultureInfo.InvariantCulture);

		}
		private void chart2()
		{
			var values = new ChartValues<ObservablePoint>
			(
				Probability_theory.TableRowsView.Select(x => x.Average)
				.Zip(Probability_theory.TableRowsView.Select(x => x.AccumulatedFrequency),
					(x, y) => new ObservablePoint(x, y))
			);

			AccumulatedFrequencySeries1 = new SeriesCollection
			{
				new LineSeries
				{
					Values = values,
					Title = "Полигон накопленных частот"
				}
			};
			accumulatedFrequencySeriesChartAxisX1.LabelFormatter = values => values.ToString("F2", CultureInfo.InvariantCulture);
			accumulatedFrequencySeriesChartAxisY1.LabelFormatter = values => values.ToString("F2", CultureInfo.InvariantCulture);

			AccumulatedFrequencySeries2 = new SeriesCollection
			{
				new ColumnSeries
				{
					Values = values,
					Title = "Гистограмма накопленных частот"
				}
			};
			accumulatedFrequencySeriesChartAxisX2.LabelFormatter = values => values.ToString("F2", CultureInfo.InvariantCulture);
			accumulatedFrequencySeriesChartAxisY2.LabelFormatter = values => values.ToString("F2", CultureInfo.InvariantCulture);
		}
		private void chart3()
		{
			var values = new ChartValues<ObservablePoint>
			(
				Probability_theory.TableRowsView.Select(x => x.Average)
				.Zip(Probability_theory.TableRowsView.Select(x => x.RelativeFrequency),
					(x, y) => new ObservablePoint(x, y))
			);

			RelativeFrequencySeries1 = new SeriesCollection
			{
				new LineSeries
				{
					Values = values,
					Title = "Полигон относительных частот"
				}
			};
			relativeFrequencySeriesChartAxisX1.LabelFormatter = values => values.ToString("F2", CultureInfo.InvariantCulture);
			relativeFrequencySeriesChartAxisY1.LabelFormatter = values => values.ToString("F2", CultureInfo.InvariantCulture);

			RelativeFrequencySeries2 = new SeriesCollection
			{
				new ColumnSeries
				{
					Values = values,
					Title = "Гистограмма относительных частот"
				}
			};
			relativeFrequencySeriesChartAxisX2.LabelFormatter = values => values.ToString("F2", CultureInfo.InvariantCulture);
			relativeFrequencySeriesChartAxisY2.LabelFormatter = values => values.ToString("F2", CultureInfo.InvariantCulture);
		}
		private void chart4()
		{
			var values = new ChartValues<ObservablePoint>
			(
				Probability_theory.TableRowsView.Select(x => x.Average)
				.Zip(Probability_theory.TableRowsView.Select(x => x.RelativeCumulativeFrequency),
					(x, y) => new ObservablePoint(x, y))
			);

			RelativeCumulativeFrequencySerise1 = new SeriesCollection
			{
				new LineSeries
				{
					Values = values,
					Title = "Полигон относительных накопленных частот"
				}
			};
			relativeCumulativeFrequencySeriseChartAxisX1.LabelFormatter = values => values.ToString("F2", CultureInfo.InvariantCulture);
			relativeCumulativeFrequencySeriseChartAxisY1.LabelFormatter = values => values.ToString("F2", CultureInfo.InvariantCulture);

			RelativeCumulativeFrequencySerise2 = new SeriesCollection
			{
				new ColumnSeries
				{
					Values = values,
					Title = "Гистограмма относительных накопленных частот"
				}
			};
			relativeCumulativeFrequencySeriseChartAxisX2.LabelFormatter = values => values.ToString("F2", CultureInfo.InvariantCulture);
			relativeCumulativeFrequencySeriseChartAxisY2.LabelFormatter = values => values.ToString("F2", CultureInfo.InvariantCulture);
			
		}
	}
}
