using NetSuiteMfgToolbox.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		public ICommand UnreleaseCommand { get; set; }

		public UnreleaseViewModel()
		{
			this.Model = new UnreleaseModel();
			this.UnreleaseCommand = new RelayCommand(o => 
			{
				this.Model.Unrelease(SONumber);
			});
        }
	}
}
