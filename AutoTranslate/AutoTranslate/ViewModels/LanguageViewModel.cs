namespace AutoTranslate.ViewModels
{
    internal class LanguageViewModel : ViewModelBase
    {
        #region Fields

        private bool isSelected;
        private string language;

        #endregion

        #region Properties

        public bool IsSelected 
        { 
            get => isSelected; 
            set
            {
                isSelected = value;
                OnPropertyChanged();
            }
        }

        public string Language 
        { 
            get => language; 
            set
            {
                language=value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
