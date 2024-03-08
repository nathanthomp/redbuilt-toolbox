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

        private UnreleaseViewModel UnreleaseViewModel { get; set; }
        private UpdateBOMRevisionViewModel UpdateBOMRevisionViewModel { get; set; }

		public ICommand UnreleaseViewCommmand { get; set; }
		public ICommand UpdateBOMRevisionCommand { get; set; }

        public MainViewModel()
		{
			this.UnreleaseViewModel = new UnreleaseViewModel();
            this.UpdateBOMRevisionViewModel = new UpdateBOMRevisionViewModel();

			this.UnreleaseViewCommmand = new RelayCommand(o =>
			{
				this.CurrentView = this.UnreleaseViewModel;
			});

			this.UpdateBOMRevisionCommand = new RelayCommand(o =>
			{
				this.CurrentView = this.UpdateBOMRevisionViewModel;
			});

            this.CurrentView = UnreleaseViewModel;
		}

        public string azureAppId = "31fe67d2-9f85-4860-8abe-00e96abd3de6"; // Azure AD > App registrations > RB Mfg Toolbox
        public string azureAppSecret = "~KO8Q~.rJe8nNP-3lUSRuQGVDVh4JLGZd_u2Pbkt"; // PWVault1 > RBMfgToolbox

        private NSClient.NSEnvironment _environment = NSClient.NSEnvironment.Sandbox;
        public NSClient.NSEnvironment Environment
        {
            get { return _environment; }
            set { _environment = value; }
        }

        private NSClient _nsClient;
        public NSClient nsClient
        {
            get { return _nsClient; }
            set 
            { 
                _nsClient = value;
                this.UnreleaseViewModel.nsClient = _nsClient;
                this.UpdateBOMRevisionViewModel.nsClient = _nsClient;
            }
        }
    }
}
