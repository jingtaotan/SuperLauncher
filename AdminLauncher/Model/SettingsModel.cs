using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLauncher.Model
{
    [Serializable]
    public class SettingsModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string CustomCommand1Name { get; set; }
        public string CustomCommand1Path { get; set; }
        public string CustomCommand2Name { get; set; }
        public string CustomCommand2Path { get; set; }
        public string CustomCommand3Name { get; set; }
        public string CustomCommand3Path { get; set; }

        public SettingsModel()
        {
            Username = string.Empty;
            Password = string.Empty;
            CustomCommand1Name = string.Empty;
            CustomCommand1Path = string.Empty;
            CustomCommand2Name = string.Empty;
            CustomCommand2Path = string.Empty;
            CustomCommand3Name = string.Empty;
            CustomCommand3Path = string.Empty;
        }
    }
}
