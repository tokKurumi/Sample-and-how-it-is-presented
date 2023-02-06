using Sample_and_how_it_is_presented.Core;

namespace Sample_and_how_it_is_presented.MVVM.ViewModel
{
	class MainViewModel : ObservableObject
	{
		public MainViewModel()
		{
			HomeVM = new HomeViewModel();
			DataVM = new DataViewModel();
			TableVM = new TableViewModel();
			VisualizationVM = new VisualizationViewModel();
			CurrentView = HomeVM;

			HomeViewCommand = new RelayCommand(x =>
			{
				CurrentView = HomeVM;
			});

			DataViewCommand = new RelayCommand(x =>
			{
				CurrentView = DataVM;
			});

			TableViewCommand = new RelayCommand(x =>
			{
				CurrentView = TableVM;
			});

			VisualizationViewCommand = new RelayCommand(x =>
			{
				CurrentView = VisualizationVM;
			});
		}

		public RelayCommand HomeViewCommand { get; set; }
		public RelayCommand DataViewCommand { get; set; }
		public RelayCommand TableViewCommand { get; set; }
		public RelayCommand VisualizationViewCommand { get; set; }

		public HomeViewModel HomeVM { get; set; }
		public TableViewModel TableVM { get; set; }
		public DataViewModel DataVM { get; set; }
		public VisualizationViewModel VisualizationVM { get; set; }

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
	}
}
