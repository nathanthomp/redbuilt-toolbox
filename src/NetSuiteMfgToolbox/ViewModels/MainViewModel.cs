using NetSuiteMfgToolbox.Commands;
using RedBuilt.NetSuite;
using System.Collections.Generic;
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



        private UnreleaseViewModel _unreleaseViewModel;
        private UpdateBOMRevisionViewModel _updateBOMRevisionViewModel;

		public ICommand UnreleaseViewCommmand { get; }
		public ICommand UpdateBOMRevisionCommand { get; }

        public MainViewModel()
		{
            _unreleaseViewModel = new UnreleaseViewModel();
            _updateBOMRevisionViewModel = new UpdateBOMRevisionViewModel();

            UnreleaseViewCommmand = new RelayCommand(o =>
            {
                CurrentView = _unreleaseViewModel;
            });

            UpdateBOMRevisionCommand = new RelayCommand(o =>
            {
                CurrentView = _updateBOMRevisionViewModel;
            });

            CurrentView = _unreleaseViewModel;
		}

        // ----------------------------------------- CAN BE REMOVED -----------------------------------------

        //public string azureAppId = "31fe67d2-9f85-4860-8abe-00e96abd3de6"; // Azure AD > App registrations > RB Mfg Toolbox
        //public string azureAppSecret = "~KO8Q~.rJe8nNP-3lUSRuQGVDVh4JLGZd_u2Pbkt"; // PWVault1 > RBMfgToolbox

        //private NSClient.NSEnvironment _environment = NSClient.NSEnvironment.Sandbox;
        //public NSClient.NSEnvironment Environment
        //{
        //    get { return _environment; }
        //    set { _environment = value; }
        //}

        //private NSClient _nsClient;
        //public NSClient nsClient
        //{
        //    get { return _nsClient; }
        //    set 
        //    { 
        //        _nsClient = value;
        //        this.UnreleaseViewModel.nsClient = _nsClient;
        //        this.UpdateBOMRevisionViewModel.nsClient = _nsClient;
        //    }
        //}

        // ----------------------------------------- CAN BE REMOVED -----------------------------------------
    }
}
