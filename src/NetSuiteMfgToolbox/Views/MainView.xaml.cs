using NetSuiteMfgToolbox.ViewModels;
using RedBuilt.NetSuite;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NetSuiteMfgToolbox.Views
{
    public partial class MainView : Window
    {
        private readonly MainViewModel _viewModel;

        public MainView()
        {
            InitializeComponent();
            Title = $"NetSuite Manufacturing Toolbox version {Assembly.GetExecutingAssembly().GetName().Version}";

            _viewModel = new MainViewModel();
            DataContext = _viewModel;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
             //default to sandbox 
            //await Task.Run(() => Login(NSClient.NSEnvironment.Production));
        }

        private async void Environment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Status.Text = string.Empty;

            var comboBox = sender as ComboBox;
            var comboBoxItem = comboBox.SelectedValue as ComboBoxItem;

            var choosenEnvironment = comboBoxItem.Content.ToString();
            try
            {
                //Progress.Visibility = Visibility.Visible;
                switch (choosenEnvironment)
                {
                    case "Sandbox":
                        await Task.Run(() => Login(NSClient.NSEnvironment.Sandbox));
                        break;
                    case "Sandbox2":
                        await Task.Run(() => Login(NSClient.NSEnvironment.Sandbox2));
                        break;
                    case "Sandbox3":
                        await Task.Run(() => Login(NSClient.NSEnvironment.Sandbox3));
                        break;
                    case "ReleasePreview":
                        await Task.Run(() => Login(NSClient.NSEnvironment.ReleasePreview));
                        break;
                    default:
                        await Task.Run(() => Login(NSClient.NSEnvironment.Production));
                        break;
                }
                Progress.Visibility = Visibility.Hidden;
                Status.Text = $"Logged into NetSuite {choosenEnvironment}";
            }
            catch (Exception ex)
            {
                // There is no log in and nothing can be done
                Status.Text = $"Could not log in to NetSuite {choosenEnvironment}";
            }
        }

        private async Task Login(NSClient.NSEnvironment environment)
        {
            string azureAppId = "31fe67d2-9f85-4860-8abe-00e96abd3de6"; // Azure AD > App registrations > RB Mfg Toolbox
            string azureAppSecret = "~KO8Q~.rJe8nNP-3lUSRuQGVDVh4JLGZd_u2Pbkt"; // PWVault1 > RBMfgToolbox

            var nsRole = NSClient.NSIntegrationRoles.RBAppMfgToolbox;

            var client = new NSClient();
            client.SetEnvironment(environment);

            await client.LoginSSOAsync(nsRole, azureAppId, azureAppSecret);
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close the window?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Question) 
                != MessageBoxResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }
}
