using NetSuiteMfgToolbox.Models;
using System.Windows.Input;

namespace NetSuiteMfgToolbox.ViewModels
{
    public class UnreleaseViewModel : ObservableObject
    {
		private UnreleaseModel Model { get; set; }

		private string _soNumber;

		public string SONumber
		{
			get { return _soNumber; }
			set 
			{
				_soNumber = value;
				OnPropertyChanged();
			}
		}

		public ICommand UnreleaseCommand { get; }

		public UnreleaseViewModel()
		{
			this.Model = new UnreleaseModel();
			this.UnreleaseCommand = new RelayCommand(async o => 
			{
				await this.Model.Unrelease(SONumber);
			});
        }
	}
}
