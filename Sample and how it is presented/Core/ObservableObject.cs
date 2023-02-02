using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Sample_and_how_it_is_presented.Core
{
	class ObservableObject : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropretyChanged([CallerMemberName] string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}