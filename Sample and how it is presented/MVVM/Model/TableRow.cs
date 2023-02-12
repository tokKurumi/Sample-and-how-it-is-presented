using System;

namespace Sample_and_how_it_is_presented.MVVM.Model
{
	public class TableRow
	{
		public TableRow(int number, float bottomLine, float topLine, int frequency, int accumulatedFrequency, float relativeFrequency, float relativeCumulativeFrequency)
		{
			Number = number;
			BottomLine = bottomLine;
			TopLine = topLine;
			Average = (float)Math.Round((bottomLine + topLine) / 2, 3);
			Frequency = frequency;
			AccumulatedFrequency = accumulatedFrequency;
			RelativeFrequency = relativeFrequency;
			RelativeCumulativeFrequency = relativeCumulativeFrequency;
		}

		public int Number { get; set; }
		public float BottomLine { get; set; }
		public float TopLine { get; set; }
		public float Average { get; set; }
		public int Frequency { get; set; }
		public int AccumulatedFrequency { get; set; }
		public float RelativeFrequency { get; set; }
		public float RelativeCumulativeFrequency { get; set; }
	}
}
