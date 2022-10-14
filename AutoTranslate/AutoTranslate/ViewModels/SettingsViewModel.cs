using System.Windows;
using System.Windows.Input;

namespace AutoTranslate.ViewModels
{
    internal class SettingsViewModel : ViewModelBase
    {
        #region Fields

        private ICommand cancelCommand;
        private ICommand okCommand;
        private MessageBoxResult result;
        private Visibility visibility = Visibility.Collapsed;

        #endregion

        #region Properties

        public ICommand CancelCommand => cancelCommand ??= new RelayCommand(Cancel);

        public ICommand OkCommand => okCommand ??= new RelayCommand(Ok);

        public MessageBoxResult Result
        {
            get => result;
            set
            {
                result = value;
                OnPropertyChanged();
            }
        }

        public Visibility Visibility
        {
            get => visibility;
            set
            {
                visibility = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods

        private void Cancel()
        {
            Result = MessageBoxResult.Cancel;
            Visibility = Visibility.Collapsed;
        }

        private void Ok()
        {
            Result = MessageBoxResult.OK;
            Visibility = Visibility.Collapsed;
        }

        #endregion
    }
}
