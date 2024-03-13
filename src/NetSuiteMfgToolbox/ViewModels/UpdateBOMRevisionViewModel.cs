using NetSuiteMfgToolbox.Commands;
using System.Windows.Input;

namespace NetSuiteMfgToolbox.ViewModels
{
    public class UpdateBOMRevisionViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainViewModel;

        private string _salesOrderName;

        public string SalesOrderName
        {
            get { return _salesOrderName; }
            set
            {
                _salesOrderName = value;
                OnPropertyChanged();
                UpdateCommand.OnCanExecuteChanged();
            }
        }

        public bool IsLoggedIn { get => _mainViewModel.IsLoggedIn; }

        // Sales order name must be non empty, 5 characters, and a number
        public bool IsValidSalesOrderName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(SalesOrderName))
                    return false;
                if (SalesOrderName.Length != 5)
                    return false;
                foreach (var c in SalesOrderName)
                {
                    if (!char.IsDigit(c))
                        return false;
                }
                return true;
            }
        }

        public CommandBase UpdateCommand { get; set; }

        public UpdateBOMRevisionViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            UpdateCommand = new UpdateCommand(this);
        }
    }
}
