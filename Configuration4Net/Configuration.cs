using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Configuration;
using System.Security.Cryptography;

namespace Configuration4Net
{
    public class Configuration
    {
        private System.Configuration.Configuration mConfiguration = null;

        private System.Collections.Specialized.NameValueCollection mAppSetting = null;

        public string ConfigMD5
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            set;
        }

        public static string MD5Encoding(string rawPass)
        {

            MD5 md5 = MD5.Create();
            byte[] bs = Encoding.UTF8.GetBytes(rawPass);
            byte[] hs = md5.ComputeHash(bs);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hs)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        public System.Collections.Specialized.NameValueCollection AppSetting
        {
            get
            {
                if (mAppSetting == null)
                {
                    mAppSetting = new NameValueCollection();
                    foreach (string key in mConfiguration.AppSettings.Settings.AllKeys)
                    {
                        mAppSetting[key] = mConfiguration.AppSettings.Settings[key].Value;
                    }
                }
                return mAppSetting;
            }
        }

        public ConfigurationSection GetSection(string name)
        {
            lock (this)
            {
                return mConfiguration.GetSection(name);
            }
        }

        public IConfigLoader ConfigLoader
        {
            get;
            private set;
        }

        public ConfigurationSectionGroup GetSectionGroup(string sectionGroupName)
        {
            lock (this)
            {
                return mConfiguration.GetSectionGroup(sectionGroupName);
            }
        }

        public T GetAppSetting<T>(string name)
        {
            string value = mConfiguration.AppSettings.Settings[name].Value;
            if (string.IsNullOrEmpty(value))
                return default(T);
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public static string LoadConfigData(IConfigLoader loader)
        {
            return loader.Load();
        }

        public void LoadConfig(string data)
        {
            lock (this)
            {
                ConfigMD5 = MD5Encoding(data);
                string filename;
                filename = AppDomain.CurrentDomain.BaseDirectory + string.Format("{0}{1}{2}.config", Name, "_tmp", "");
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filename, false, Encoding.UTF8))
                {
                    writer.Write(data);
                }
                System.Configuration.ExeConfigurationFileMap fm = new System.Configuration.ExeConfigurationFileMap();
                fm.ExeConfigFilename = filename;
                mConfiguration = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(fm, System.Configuration.ConfigurationUserLevel.None);
                mAppSetting = null;
            }
        }

        public static Configuration GetManager(IConfigLoader loader)
        {
            lock (typeof(ConfigurationManager))
            {
                Configuration result = new Configuration();
                result.Name = loader.Name;
                result.ConfigLoader = loader;
                result.LoadConfig(loader.Load());
                return result;
            }
        }
    }
}
