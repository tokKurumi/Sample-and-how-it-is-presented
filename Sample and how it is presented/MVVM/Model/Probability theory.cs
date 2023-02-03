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
	class Probability_theory
   {
      public List<float> Numbers { get; private set; }
      public uint CountOfPartitions { get; private set; }

      public Probability_theory()
      {
         Numbers = new List<float>();
			Numbers.Add(1);
			Numbers.Add(4);
			Numbers.Add(8);
			Numbers.Add(8);
			CountOfPartitions = 0;
		}

		async public void ReadFromJSON(string path)
      {
			try
			{
				using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
				{
					List<float>? person = await JsonSerializer.DeserializeAsync<List<float>>(fs);
				}
			}
			catch(Exception ex)
			{
				Numbers = new List<float>();
			}
      }

		async public void WriteToJSON(string path)
		{
			using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
			{
				await JsonSerializer.SerializeAsync<List<float>>(fs, Numbers);
			}
		}
   }
}
