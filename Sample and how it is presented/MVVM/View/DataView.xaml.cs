using Microsoft.Win32;
using Sample_and_how_it_is_presented.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Data;


namespace Sample_and_how_it_is_presented.MVVM.View
{
	/// <summary>
	/// Interaction logic for DataView.xaml
	/// </summary>
	public partial class DataView : UserControl
	{
		public DataView()
		{
			InitializeComponent();
			dataGridData.ItemsSource = Probability_theory.Series;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "JSON Text|*.json";
			saveFileDialog.Title = "Сохранить JSON файл";

			if (saveFileDialog.ShowDialog() == true)
			{
				Probability_theory.WriteToJSON(saveFileDialog.FileName);
			}
      }

		private async void Button_Click_1(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "JSON Text|*.json";
			openFileDialog.Title = "Открыть JSON файл";

			if (openFileDialog.ShowDialog() == true)
			{
				if (await Probability_theory.ReadFromJSON(openFileDialog.FileName))
				{
					dataGridData.ItemsSource = Probability_theory.Series;
				}
				else
				{
					MessageBox.Show("Неправильный формат данных!");
				}
			}
		}
	}
}
