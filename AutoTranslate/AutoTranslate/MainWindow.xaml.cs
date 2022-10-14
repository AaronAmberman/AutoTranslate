using AutoTranslate.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoTranslate
{
    public partial class MainWindow : Window
    {
        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string ver = string.Empty;

            try
            {
                ver = Assembly.GetExecutingAssembly()?.GetName()?.Version?.ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred attempting to get the version information.{Environment.NewLine}{ex}");
                ServiceLocator.Instance.Logger.Error($"An error occurred attempting to get the version information.{Environment.NewLine}{ex}");

                ver = "Unable to retrieve version information.";
            }

            MainWindowViewModel viewModel = new MainWindowViewModel
            {
                DataNeededVisibility = Visibility.Visible, // show data needed control right away
                MessageBoxViewModel = new MessageBoxViewModel(),
                SettingsViewModel = new SettingsViewModel(),
                Version = ver,
            };

            DataContext = viewModel;

            ServiceLocator.Instance.MainWindowViewModel = viewModel;

            // gets our focus in the "popup" so the controls it covers can't be interacted with via the keyboard
            browseForFile.Focus();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
