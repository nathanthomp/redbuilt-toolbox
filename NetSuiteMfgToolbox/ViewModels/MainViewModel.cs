using System.Windows.Input;

namespace NetSuiteMfgToolbox.ViewModels
{
    public class MainViewModel : ObservableObject
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
	}
}
