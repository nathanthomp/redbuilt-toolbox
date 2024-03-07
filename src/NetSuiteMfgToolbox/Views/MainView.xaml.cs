using NetSuiteMfgToolbox.ViewModels;
using RedBuilt.NetSuite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

namespace NetSuiteMfgToolbox.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {

        private MainViewModel ViewModel { get; set; }

        public MainView()
        {
            InitializeComponent();
            this.ViewModel = new MainViewModel();
            this.DataContext = ViewModel;
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            NSEnvironmentComboBox.SelectedIndex = 1; //default to sandbox 
            
            //var loginWorker = new BackgroundWorker();
            //loginWorker.DoWork += LoginWorker_DoWork;
            //loginWorker.RunWorkerCompleted += LoginWorker_RunWorkerCompleted;
            //pbStatus.Visibility = System.Windows.Visibility.Visible;
            //pbStatusText.Visibility = System.Windows.Visibility.Visible;
            //this.pbStatusText.Text = "Logging into NetSuite...";
            //loginWorker.RunWorkerAsync();
        }

        private void LoginWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var client = new NSClient();
            client.SetEnvironment(this.ViewModel.Environment);
            client.LoginSSO(NSClient.NSIntegrationRoles.RBAppMfgToolbox, this.ViewModel.azureAppId, this.ViewModel.azureAppSecret);
            
            //this.ViewModel.AdminUser = _adminUsers.Contains(client.AuthenticatedEmail);
        }

        private void LoginWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.pbStatusText.Text = "Could not sign into NetSuite. Please try restarting the application";
            }
            else
            {
                this.pbStatusText.Text = "";
                this.pbStatusText.Visibility = System.Windows.Visibility.Hidden;
            }
            pbStatus.Visibility = System.Windows.Visibility.Hidden;
        }

        private void NSEnvironmentComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var comboBox = sender as System.Windows.Controls.ComboBox;
            var comboBoxItem = comboBox.SelectedValue as System.Windows.Controls.ComboBoxItem;
            
            switch (comboBoxItem.Content.ToString())
            {
                // Login again but with the selected environment
                case "Production":
                    this.ViewModel.Environment = NSClient.NSEnvironment.Production;
                    break;
                case "Sandbox":
                    this.ViewModel.Environment = NSClient.NSEnvironment.Sandbox;
                    break;
                case "Sandbox3":
                    this.ViewModel.Environment = NSClient.NSEnvironment.Sandbox3;
                    break;
                case "ReleasePreview":
                    this.ViewModel.Environment = NSClient.NSEnvironment.ReleasePreview;
                    break;
                default:
                    throw new NotSupportedException("Environment not supported: " + comboBoxItem.Content.ToString());
            }
            var loginWorker = new BackgroundWorker();
            loginWorker.DoWork += LoginWorker_DoWork;
            loginWorker.RunWorkerCompleted += LoginWorker_RunWorkerCompleted;
            pbStatus.Visibility = System.Windows.Visibility.Visible;
            pbStatusText.Visibility = System.Windows.Visibility.Visible;
            pbStatusText.Text = $"Logging into NetSuite {this.ViewModel.Environment.ToString()}";
            loginWorker.RunWorkerAsync();
        }
       
    }
}
