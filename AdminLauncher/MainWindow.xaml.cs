using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Security.Principal;
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
using System.Linq;

namespace AdminLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            bool isAdmin = false;
            var identity = WindowsIdentity.GetCurrent();
            if (identity != null)
            {
                var principal = new WindowsPrincipal(identity);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
                UsernameField.Content = identity.Name;
            }
            else
            {
                UsernameField.Content = "<unknown>";
            }

            RelaunchButton.IsEnabled = !isAdmin;

            InitializeCommandButtons();
        }

        private void InitializeCommandButtons()
        {
            if (App.Settings.CustomCommand1Name != null)
            {
                Command1_Button.Content = App.Settings.CustomCommand1Name;    
            }
            if (App.Settings.CustomCommand2Name != null)
            {
                Command2_Button.Content = App.Settings.CustomCommand2Name;
            }
            if (App.Settings.CustomCommand3Name != null)
            {
                Command3_Button.Content = App.Settings.CustomCommand3Name;
            }
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(App.Settings.Password);
        }

        private void RelaunchButton_Click(object sender, RoutedEventArgs e)
        {
            var password = new SecureString();
            foreach (char c in App.Settings.Password)
            {
                password.AppendChar(c);
            }
            var startInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = Assembly.GetExecutingAssembly().Location,
                Verb = "runas"
            };
            // launch the app again
            var process = Process.Start(startInfo);
            // shutdown the current instance
            Application.Current.Shutdown();
        }

        private void VisualStudio_Button_Click(object sender, RoutedEventArgs e)
        {
            var startInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                FileName = @"C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\devenv.exe",
            };
            // launch the app again
            var process = Process.Start(startInfo);
        }

        private void Settings_Button_Click(object sender, RoutedEventArgs e)
        {
            var settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog();
            InitializeCommandButtons();
        }

        private void Command_Button_Click(object sender, RoutedEventArgs e)
        {
            string command;

            if (Equals(sender, Command1_Button))
            {
                command = App.Settings.CustomCommand1Path;
            }
            else if (Equals(sender, Command2_Button))
            {
                command = App.Settings.CustomCommand2Path;
            }
            else
            {
                command = App.Settings.CustomCommand3Path;
            }

            var startInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                FileName = command
            };
            // launch the app again
            var process = Process.Start(startInfo);
        }
    }
}
