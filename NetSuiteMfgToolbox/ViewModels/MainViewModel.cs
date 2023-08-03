using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /*
		 * To add new views, add the above line with the new view model type.
		 */

        public MainViewModel()
		{
			this.UnreleaseViewModel = new UnreleaseViewModel();
            /*
			 * To add new views, add the above line with the new view model type.
			 */
            CurrentView = UnreleaseViewModel;
		}


	}
}
