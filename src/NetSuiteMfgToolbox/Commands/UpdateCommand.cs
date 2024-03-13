using NetSuiteMfgToolbox.Models;
using NetSuiteMfgToolbox.ViewModels;

namespace NetSuiteMfgToolbox.Commands
{
    public class UpdateCommand : CommandBase
    {
        private readonly UpdateBOMRevisionViewModel _updateBOMRevisionViewModel;

        public UpdateCommand(UpdateBOMRevisionViewModel updateBOMRevisionViewModel)
        {
            _updateBOMRevisionViewModel = updateBOMRevisionViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return _updateBOMRevisionViewModel.IsLoggedIn && _updateBOMRevisionViewModel.IsValidSalesOrderName && base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            UpdateBOMRevisionModel.Update();
        }
    }
}
