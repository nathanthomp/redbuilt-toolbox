using NetSuiteMfgToolbox.Models;
using RedBuilt.NetSuite;
using System.Windows.Input;

namespace NetSuiteMfgToolbox.ViewModels
{
    public class UpdateBOMRevisionViewModel : ViewModelBase
    {
        private UpdateBOMRevisionModel Model { get; set; }

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

        public ICommand UpdateCommand { get; set; }

        public UpdateBOMRevisionViewModel()
        {
            Model = new UpdateBOMRevisionModel();
            this.UpdateCommand = new RelayCommand(async o =>
            {
                await this.Model.Update(this.SONumber);
            });
        }

        private NSClient _nsClient;
        public NSClient nsClient
        {
            get { return _nsClient; }
            set { _nsClient = value; }
        }
    }
}
