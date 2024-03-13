using NetSuiteMfgToolbox.Commands;
using RedBuilt.NetSuite;
using System.Windows.Input;

namespace NetSuiteMfgToolbox.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private object _currentView;

		public object CurrentView
		{
			get { return _currentView; }
			set
			{ 
				_currentView = value;
				OnPropertyChanged();
			}
		}

        private NSClient.NSEnvironment _environment = NSClient.NSEnvironment.Production;

        public NSClient.NSEnvironment Environment
        {
            get { return _environment; }
            set { _environment = value; }
        }

        public bool IsLoggedIn { get; set; }

        private readonly UnreleaseViewModel _unreleaseViewModel;
        private readonly UpdateBOMRevisionViewModel _updateBOMRevisionViewModel;

		public ICommand UnreleaseViewCommmand { get; }
		public ICommand UpdateBOMRevisionCommand { get; }

        public MainViewModel()
		{
            _unreleaseViewModel = new UnreleaseViewModel(this);
            _updateBOMRevisionViewModel = new UpdateBOMRevisionViewModel(this);

            UnreleaseViewCommmand = new RelayCommand(o =>
            {
                CurrentView = _unreleaseViewModel;
            });

            UpdateBOMRevisionCommand = new RelayCommand(o =>
            {
                CurrentView = _updateBOMRevisionViewModel;
            });

            IsLoggedIn = false;

            CurrentView = _unreleaseViewModel;
		}
    }
}
