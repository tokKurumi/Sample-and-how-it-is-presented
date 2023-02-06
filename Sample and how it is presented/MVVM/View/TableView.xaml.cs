using Sample_and_how_it_is_presented.MVVM.Model;
using System.Windows.Controls;

namespace Sample_and_how_it_is_presented.MVVM.View
{
	/// <summary>
	/// Interaction logic for TableView.xaml
	/// </summary>
	public partial class TableView : UserControl
	{
		public TableView()
		{
			InitializeComponent();
			if(Probability_theory.Numbers.Count != 0)
			{
				Probability_theory.CreateRowViews();
				dataGridTableView.ItemsSource = Probability_theory.TableRowsView;
			}
		}
	}
}