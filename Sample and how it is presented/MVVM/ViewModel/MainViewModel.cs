using Sample_and_how_it_is_presented.Core;

namespace Sample_and_how_it_is_presented.MVVM.ViewModel
{
	class MainViewModel : ObservableObject
	{
		public HomeViewModel HomeVM { get; set; }

		private object _currentView;

		public object CurrentView
		{
			get { return _currentView; }
			set
			{ 
				_currentView = value;
				OnPropretyChanged();
			}
		}

		public MainViewModel()
		{
			HomeVM = new HomeViewModel();
			CurrentView= new HomeViewModel();
		}
	}
}
