using NetSuiteMfgToolbox.Models;
using RedBuilt.NetSuite;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace NetSuiteMfgToolbox.ViewModels
{
    public class UnreleaseViewModel : ObservableObject
    {
		private UnreleaseModel Model { get; set; }

		private List<string> list { get; set; }

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

		private NSClient _nsClient;
        public NSClient nsClient
        {
            get { return _nsClient; }
            set { _nsClient = value; }
        }

        public ICommand UnreleaseCommand { get; }

		public UnreleaseViewModel()
		{
			this.Model = new UnreleaseModel();
			this.list = new List<string>();
			this.UnreleaseCommand = new RelayCommand(async o => 
			{
				// await this.Model.Login()
				// await this.Model.Load()
				// await this.Model.Unrelease()
				this.list.Add("Starting Unrelease...");
                await this.Model.Unrelease(this.SONumber);
                this.list.Add("Unrelease finished");
            });
			this.Model.ViewModel = this;
        }
	}
}
