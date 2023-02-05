using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Xml;
using System.Windows.Media;
using System.Windows;

namespace Sample_and_how_it_is_presented.MVVM.Model
{
	static class Probability_theory
   {
		static public List<float> Numbers { get; private set; } = new List<float>();
		static public Dictionary<float, int> Series { get; private set; } = new Dictionary<float, int>();
		static public List<TableRow> TableRowsView { get; private set; } = new List<TableRow>();
		static public int CountOfPartitions { get; private set; } = 0;

		static async public Task<bool> ReadFromJSON(string path)
      {
			try
			{
				using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
				{
					Numbers = await JsonSerializer.DeserializeAsync<List<float>>(fs);
				}
				Numbers.Sort();
				Series = Numbers.GroupBy(x => x).ToDictionary(keySelector: g => g.Key, elementSelector: g => g.Count());
				CountOfPartitions = 1 + Convert.ToInt32(3.32 * Math.Log10(Numbers.Count));
				return true;
			}
			catch(Exception ex)
			{
				Numbers = new List<float>();
				return false;
			}
		}

		static async public void WriteToJSON(string path)
		{
			using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
			{
				await JsonSerializer.SerializeAsync<List<float>>(fs, Numbers);
			}
		}

		static public void CreateRowViews()
		{
			TableRowsView.Clear();

			float min = Numbers.Min();
			float max = Numbers.Max();
			float step = (float)Math.Round((max - min) / CountOfPartitions, 3);

			for (int i = 0; i < CountOfPartitions; ++i)
			{
				float BottomLine = (float)Math.Round(min + step * i, 3);
				float TopLine = (float)Math.Round(BottomLine + step, 3);
				int Frequency = Numbers.Count(x => (x >= min + step * i) && (x < min + step * (i + 1)));
				int AccumulatedFrequency = TableRowsView.Select(x => x.Frequency).Sum() + Frequency;
				float RelativeFrequency =  (float)Math.Round((float)Frequency / Numbers.Count(), 3);
				float RelativeCumulativeFrequency = (float)Math.Round(TableRowsView.Select(x => x.RelativeFrequency).Sum() + RelativeFrequency, 2);

				TableRowsView.Add(new TableRow(
					i,
					BottomLine,
					TopLine,
					Frequency,
					AccumulatedFrequency,
					RelativeFrequency,
					RelativeCumulativeFrequency
				));
			}
		}
   }
}
