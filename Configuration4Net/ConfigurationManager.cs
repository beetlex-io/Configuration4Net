using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;
namespace Configuration4Net
{
    public class ConfigurationManager
    {
        const string DEFAULT_CONFIGURATION = "Default";

        private System.Threading.Timer mTimer;

        private Dictionary<string, IConfigLoader> mConfigLoaders = new Dictionary<string, IConfigLoader>();

        public event EventHandler<ConfigurationUpdateArgs> ConfigurationUpdated;

        private void OnTrackUpdate(object state)
        {
            mTimer.Change(-1, -1);
            foreach (Configuration item in mManagers.Values)
            {
                try
                {
                    string config = item.ConfigLoader.Load();
                    if (Configuration.MD5Encoding(config) != item.ConfigMD5)
                    {
                        item.LoadConfig(config);
                        if (ConfigurationUpdated != null)
                            ConfigurationUpdated(this, new ConfigurationUpdateArgs { Configuration= item });
                    }
                }
                catch (Exception e_)
                {

                }
            }
            mTimer.Change(10000, 10000);
            
        }

        public Dictionary<string, Configuration> mManagers = new Dictionary<string, Configuration>();

        public static System.Collections.Specialized.NameValueCollection AppSettings
        {
            get
            {
                return Default.AppSetting;
            }

        }

        public ConfigurationManager()
        {
            Load(AgentConfiguration4NetSection.Instance);
            mTimer = new System.Threading.Timer(OnTrackUpdate, null, 10000, 10000);
        }

        public ConfigurationManager(string section)
        {
            AgentConfiguration4NetSection ns = (AgentConfiguration4NetSection)System.Configuration.ConfigurationManager.GetSection(section);
            if (ns == null)
                throw new Configuration4NetError("{0} configuration factory section not found", section);
            Load(ns);
            mTimer = new System.Threading.Timer(OnTrackUpdate, null, 10000, 10000);
        }

        public static ConfigurationManager mInstance = null;

        public static ConfigurationManager Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = new ConfigurationManager();
                }
                return mInstance;
            }
        }

        public static Configuration GetConfiguration(string name)
        {
            return Instance[name];
        }

        public static Configuration Default
        {
            get
            {
                return Instance[DEFAULT_CONFIGURATION];
            }
        }

        public static ConfigurationSection GetSection(string name)
        {
            return Default.GetSection(name);
        }

        public static ConfigurationSectionGroup GetSectionGroup(string sectionGroupName)
        {
            return Default.GetSectionGroup(sectionGroupName);
        }

        public static T GetAppSetting<T>(string name)
        {
            return Default.GetAppSetting<T>(name);
        }

        private void Load(AgentConfiguration4NetSection section)
        {
            if (section != null)
            {
                foreach (ManagerSection item in section.ConfigManagers)
                {
                    string name = item.Name;
                    Type loaderType = Type.GetType(item.LoaderType);
                    if (loaderType == null)
                    {
                        throw new Configuration4NetError("loader type {0} not found", item.LoaderType);
                    }
                    IConfigLoader loader = (IConfigLoader)Activator.CreateInstance(loaderType);
                    loader.AppName = item.AppName;
                    loader.Name = item.Name;
                    mConfigLoaders[name] = loader;
                    SetLoadProperty(loader, item.Properties);
                    Managers[item.Name] = CreateManager(loader);
                }
            }
        }

        private void SetLoadProperty(IConfigLoader loader, PropertyCollections properties)
        {
            foreach (Property p in properties)
            {
                PropertyInfo pi = loader.GetType().GetProperty(p.Name, BindingFlags.Public | BindingFlags.Instance);
                if (pi != null && pi.CanWrite)
                {
                    try
                    {
                        object value = Convert.ChangeType(p.Value, pi.PropertyType);
                        pi.SetValue(loader, value, null);
                    }
                    catch
                    {
                    }
                }

            }
        }

        public IDictionary<string, Configuration> Managers
        {
            get
            {
                return mManagers;
            }
        }

        public Configuration this[string name]
        {
            get
            {
                Configuration result;
                if (!Managers.TryGetValue(name, out result))
                {
                    if (name == DEFAULT_CONFIGURATION)
                    {
                        Configuration config = CreateManager(new AppDomainLoader());
                        Managers[DEFAULT_CONFIGURATION] = config;
                        result = config;
                    }
                    else
                    {
                        throw new Configuration4NetError("{0} config section not found", name);
                    }
                }
                return result;

            }
        }

        public void Reload(string name)
        {
            if (mManagers.ContainsKey(name))
                mManagers.Remove(name);
            IConfigLoader loader = null;
            if (!mConfigLoaders.TryGetValue(name, out loader))
            {
                throw new Configuration4NetError("{0} config loader not found", name);
            }
            mManagers[name] = CreateManager(loader);
        }

        private Configuration CreateManager(IConfigLoader loader)
        {
            Configuration manager = Configuration.GetManager(loader);
            return manager;
        }
    }
}
