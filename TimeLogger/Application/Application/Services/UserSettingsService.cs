using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Security.AccessControl;

using Application.Entities;

namespace Application.Services
{
    public class UserSettingsService : IUserSettingsService
    {
        #region Private Fields
        private XmlSerializer xmlSerializer;
        #endregion

        #region Constructors
        public UserSettingsService()
        {
            xmlSerializer = new XmlSerializer(typeof(UserSettings));
            CreateFoldersStructure();
        }
        #endregion

        #region Properties
        public string UserSettingsFullPath { get { return Path.Combine(UserSettingsFolder, UserSettingsFileName); } }
        public string UserSettingsFileName { get { return "TimeLogger.config.xml"; } }
        public string UserSettingsFolder { get { return Path.Combine(Environment.ExpandEnvironmentVariables("%LOCALAPPDATA%"),"TimeLogger"); } }
        #endregion

        #region Public Methods
        public void Save(UserSettings userSettings)
        {
            using (FileStream fileStream = GetFileStream(UserSettingsFullPath))
            using (StreamWriter str = new StreamWriter(fileStream))
            {
                str.BaseStream.SetLength(0);
                str.Write(ToXml(userSettings));
                str.Flush();
            }
        }

        public void Load(UserSettings userSettings)
        {
            UserSettings deserialized = FromXml(UserSettingsFullPath);
            UpdateUserSettings(userSettings, deserialized);
        }

        public void UpdateUserSettings(UserSettings UserSettingsToUpdate, UserSettings updateFromUserSettings)
        {
            UserSettingsToUpdate.SaveFinishLunchAuto = updateFromUserSettings.SaveFinishLunchAuto;
            UserSettingsToUpdate.SaveStartWorkAuto = updateFromUserSettings.SaveStartWorkAuto;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// This method makes sure that config file exists on disk. 
        /// In typical situation this would be custom action in installer.
        /// </summary>
        private void CreateFoldersStructure()
        {
            try
            {
                if (!Directory.Exists(UserSettingsFolder))
                    Directory.CreateDirectory(UserSettingsFolder);

                if (Directory.Exists(UserSettingsFolder) && !File.Exists(UserSettingsFullPath))
                {
                    string templateFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Templates", UserSettingsFileName);

                    if (File.Exists(templateFullPath))
                        File.Copy(templateFullPath, UserSettingsFullPath);

                    if (File.Exists(UserSettingsFullPath))
                    {
                        try
                        {
                            FileSecurity fSec = File.GetAccessControl(UserSettingsFullPath);
                            System.Security.Principal.SecurityIdentifier everyone = new System.Security.Principal.SecurityIdentifier(System.Security.Principal.WellKnownSidType.WorldSid, null);
                            fSec.AddAccessRule(new FileSystemAccessRule(everyone, FileSystemRights.FullControl, AccessControlType.Allow));
                            File.SetAccessControl(UserSettingsFullPath, fSec);
                        }
                        catch (Exception ex)
                        {
                            throw new ApplicationException("No permissions to grant full rights to everyone user.", ex); 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No permissions to create config file on disk.", ex);
            }
        }
        #endregion

        #region Xml related
        private UserSettings FromXml(string basePath)
        {
            using (Stream reader = GetFileStream(UserSettingsFullPath))
            {
                StreamReader encodedReader = new StreamReader(reader, true);
                try
                {
                    return (UserSettings)xmlSerializer.Deserialize(encodedReader);
                }
                catch (Exception ex)
                {
                    //todo: log incorrect file format
                    throw new ApplicationException("Cannot deserialize config file.", ex);
                }
            }

        }

        private string ToXml(UserSettings userSettings)
        {
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                xmlSerializer.Serialize(sw, userSettings);
            }
            return sb.ToString();
        }

        private static FileStream GetFileStream(string fullFilename)
        {
            FileStream reader = new FileStream(fullFilename, FileMode.Open);
            return reader;
        }
        #endregion
    }
}
