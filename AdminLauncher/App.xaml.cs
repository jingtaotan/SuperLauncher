using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows;
using AdminLauncher.Model;

namespace AdminLauncher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SettingsModel Settings;

        private const string SettingsFilePath = "SuperLauncher.Settings.dat";
        private static readonly BinaryFormatter Formatter = new BinaryFormatter();

        public App()
        {
            Settings = new SettingsModel();
            LoadSettings();
        }

        private static void LoadSettings()
        {
            try
            {
                if (File.Exists(SettingsFilePath))
                {
                    Stream stream = File.OpenRead(SettingsFilePath);
                    Settings = (SettingsModel)Formatter.Deserialize(stream);
                    stream.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Settings could not be read: " + e.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public static void SaveSettings()
        {
            try
            {
                Stream stream = File.OpenWrite(SettingsFilePath);
                Formatter.Serialize(stream, Settings);
                stream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Settings could not be saved: " + e.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}
