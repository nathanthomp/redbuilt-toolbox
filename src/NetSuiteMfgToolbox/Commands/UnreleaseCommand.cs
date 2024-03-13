using NetSuiteMfgToolbox.Models;
using NetSuiteMfgToolbox.ViewModels;

namespace NetSuiteMfgToolbox.Commands
{
    public class UnreleaseCommand : CommandBase
    {
        private readonly UnreleaseViewModel _viewModel;

        public UnreleaseCommand(UnreleaseViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.IsValidSalesOrderName && _viewModel.IsLoggedIn && base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            UnreleaseModel.Unrelease(_viewModel.SalesOrderName);
        }
    }
}
