using NetSuiteMfgToolbox.Commands;
using NetSuiteMfgToolbox.Models;
using RedBuilt.NetSuite;
using System.Windows.Input;

namespace NetSuiteMfgToolbox.ViewModels
{
    public class UnreleaseViewModel : ViewModelBase
    {
		private readonly UnreleaseModel _model;

		private string _soNumber = string.Empty;

		public string SONumber
		{
			get { return _soNumber; }
			set 
			{
				_soNumber = value;
				OnPropertyChanged();
			}
		}

        public bool IsLoggedIn { get => _mainViewModel.IsLoggedIn; }

		// TODO: Might be better to go into MainViewModel
		private NSClient _nsClient;
        public NSClient nsClient
        {
            get { return _nsClient; }
            set { _nsClient = value; }
        }

        public ICommand UnreleaseCommand { get; }

		public UnreleaseViewModel()
		{
			_model = new UnreleaseModel();
			UnreleaseCommand = new UnreleaseCommand(_model, _soNumber);

			//this.UnreleaseCommand = new RelayCommand(async o => 
			//{
			//	// await this.Model.Login()
			//	// await this.Model.Load()
			//	// await this.Model.Unrelease()
			//	this.list.Add("Starting Unrelease...");
   //             await this.Model.Unrelease(this.SONumber);
   //             this.list.Add("Unrelease finished");
   //         });

			// TODO
			_model.ViewModel = this;
        }
	}
}
