using AutoTranslate.Services;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Resources.NetStandard;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AutoTranslate.ViewModels
{
    // to read
    // https://learn.microsoft.com/en-us/dotnet/api/system.resources.resxresourcereader?view=windowsdesktop-6.0
    // to write resx files
    // https://learn.microsoft.com/en-us/dotnet/api/system.resources.resxresourcewriter?view=windowsdesktop-6.0
    internal class MainWindowViewModel : ViewModelBase
    {
        #region Fields

        private ICommand aboutCommand;
        private Visibility aboutBoxVisibility = Visibility.Collapsed;
        private ICommand browseCommand;
        private string currentCulture;
        private ObservableCollection<DictionaryEntry> data = new ObservableCollection<DictionaryEntry>();
        private Visibility dataNeededVisibility = Visibility.Collapsed;
        private string fileForData;
        private MessageBoxViewModel messageBoxViewModel;
        private SettingsViewModel settingsViewModel;
        private ICommand showSettingsCommand;
        private ObservableCollection<LanguageViewModel> supportedLanguages = new ObservableCollection<LanguageViewModel>();
        private ICommand translateCommand;
        private string version;

        #endregion

        #region Properties

        public ICommand AboutCommand => aboutCommand ??= new RelayCommand(About);

        public Visibility AboutBoxVisibility
        {
            get => aboutBoxVisibility;
            set
            {
                aboutBoxVisibility = value;
                OnPropertyChanged();
            }
        }

        public ICommand BrowseCommand => browseCommand ??= new RelayCommand(Browse);

        public string CurrentCulture 
        { 
            get => currentCulture; 
            set
            {
                currentCulture = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<DictionaryEntry> Data
        {
            get => data;
            set
            {
                data = value;
                OnPropertyChanged();
            }
        }

        public Visibility DataNeededVisibility
        {
            get => dataNeededVisibility;
            set
            {
                dataNeededVisibility = value;
                OnPropertyChanged();
            }
        }

        public string FileForData
        {
            get => fileForData;
            set
            {
                fileForData = value;
                OnPropertyChanged();
            }
        }

        public MessageBoxViewModel MessageBoxViewModel
        {
            get { return messageBoxViewModel; }
            set
            {
                messageBoxViewModel = value;
                OnPropertyChanged();
            }
        }

        public SettingsViewModel SettingsViewModel
        {
            get { return settingsViewModel; }
            set
            {
                settingsViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowSettingsCommand => showSettingsCommand ??= new RelayCommand(ShowSettings);

        public ObservableCollection<LanguageViewModel> SupportedLanguages
        {
            get => supportedLanguages;
            set
            {
                supportedLanguages = value;
                OnPropertyChanged();
            }
        }

        public ICommand TranslateCommand => translateCommand ??= new RelayCommand(TranslateFile);

        public string Version
        {
            get => version;
            set
            {
                version = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods

        private void About()
        {
            AboutBoxVisibility = Visibility.Visible;
        }

        private void Browse()
        {
            Data.Clear();

            OpenFileDialog ofd = new OpenFileDialog
            {
                AddExtension = true,
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "Resx Files(*.resx)|*.resx|TS Files(*.ts)|*.ts",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                Multiselect = false,
                Title = Properties.Strings.BrowseTitle,
                ValidateNames = true
            };

            bool? result = ofd.ShowDialog();

            if (!result.HasValue) return;
            if (!result.Value) return;

            string file = ofd.FileName;

            FileForData = file;

            DataNeededVisibility = Visibility.Collapsed;

            ResXResourceReader reader = new ResXResourceReader(file);

            foreach (DictionaryEntry d in reader)
                Data.Add(d);
        }

        private void ShowSettings()
        {
            SettingsViewModel.Visibility = Visibility.Visible;
        }

        private void TranslateFile()
        {

        }

        #endregion
    }
}
