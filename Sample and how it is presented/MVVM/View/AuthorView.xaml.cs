using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Sample_and_how_it_is_presented.MVVM.View
{
	/// <summary>
	/// Interaction logic for AuthorView.xaml
	/// </summary>
	public partial class AuthorView : UserControl
	{
		public AuthorView()
		{
			InitializeComponent();
		}

		private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
		{
			System.Diagnostics.Process.Start(new ProcessStartInfo
			{
				FileName = e.Uri.AbsoluteUri,
				UseShellExecute = true
			});
		}
	}
}
