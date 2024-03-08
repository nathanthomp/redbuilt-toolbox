using NetSuiteMfgToolbox.Models;

namespace NetSuiteMfgToolbox.Commands
{
    internal class UnreleaseCommand : CommandBase
    {
        private readonly UnreleaseModel _model;
        private readonly string _soNumber;

        public UnreleaseCommand(UnreleaseModel model, string soNumber)
        {
            _model = model;
            _soNumber = soNumber;
        }

        public override bool CanExecute(object parameter)
        {
            // TODO:
            // SO Number must pass RegEx
            return base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            _model.Unrelease(_soNumber);
        }
    }
}
