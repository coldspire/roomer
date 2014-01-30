using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Roomer
{
    public class RoomerSettings
    {
        private const string settingsFilePath = "RoomerSettings.roomer";
        private Dictionary<string,string> settings = new Dictionary<string,string>();

        public bool InitSuccessful { get; set; }

        private void ClearSettings()
        {
            settings.Clear();
            return;
        }
        
        private bool LoadSettingsFromFile(string filepath)
        {
            const char CommentLineStart = '#';
            const string FormatRegex = "^[a-zA-Z]+ *= *[a-zA-Z0-9.]+$";

            ClearSettings();

            if (!System.IO.File.Exists(filepath))
            {
                return (false);
            }

            using (System.IO.StreamReader sr = new System.IO.StreamReader(filepath))
            {
                Regex regex = new Regex(FormatRegex);

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine().Trim();

                    // First see if line is probably worthless.
                    if (line.Length == 0 ||             // Blank line
                        line[0] == CommentLineStart ||  // Comment line
                        !regex.IsMatch(line))           // Doesn't match format
                    {
                        continue;
                    }

                    string[] lineParts = line.Split('=');
                    string newSettingKey = lineParts[0].ToLower(); // keys are always lowercase to prevent separate case-based keys
                    string newSettingValue = lineParts[1];
                    
                    // Next, see if this key doesn't meet our criteria for storage.
                    if (settings.ContainsKey(newSettingKey))    // Already have this key
                    {
                        continue;
                    }
                    
                    // Everything checked out. Store the key/value.
                    settings[newSettingKey] = newSettingValue;
                }
            }

            return (true);
        }
        
        public string GetSett(string settingName)
        {
            string lcSettingName = settingName.ToLower();

            if (!InitSuccessful)
            {
                // Should this throw an exception?
                return null;
            }

            if (settings.ContainsKey(lcSettingName))
            {
                return (settings[lcSettingName]);
            }

            return null; // Not returning "", since "" could be a valid setting
        }
        
        public RoomerSettings()
        {
            InitSuccessful = LoadSettingsFromFile(settingsFilePath);
        }
    }
}
