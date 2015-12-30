using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace AdminLauncher
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();

            UsernameField.Text              = App.Settings.Username;
            PasswordField.Password          = App.Settings.Password;
            CustomCommand1NameField.Text    = App.Settings.CustomCommand1Name;
            CustomCommand1PathField.Text    = App.Settings.CustomCommand1Path;
            CustomCommand2NameField.Text    = App.Settings.CustomCommand2Name;
            CustomCommand2PathField.Text    = App.Settings.CustomCommand2Path;
            CustomCommand3NameField.Text    = App.Settings.CustomCommand3Name;
            CustomCommand3PathField.Text    = App.Settings.CustomCommand3Path;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            App.Settings.Username = UsernameField.Text;
            App.Settings.Password = PasswordField.Password;
            App.Settings.CustomCommand1Name = CustomCommand1NameField.Text;
            App.Settings.CustomCommand1Path = CustomCommand1PathField.Text;
            App.Settings.CustomCommand2Name = CustomCommand2NameField.Text;
            App.Settings.CustomCommand2Path = CustomCommand2PathField.Text;
            App.Settings.CustomCommand3Name = CustomCommand3NameField.Text;
            App.Settings.CustomCommand3Path = CustomCommand3PathField.Text;

            App.SaveSettings();

            Close();
        }
    }
}
