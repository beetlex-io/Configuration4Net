using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configuration4Net
{
    public class LocalFileLoader:IConfigLoader
    {
        public string Load()
        {
            string regex = string.Format(@"^({0})|([a-zA-z]\:{0})", System.IO.Path.DirectorySeparatorChar);
            if (!System.Text.RegularExpressions.Regex.IsMatch(ConfigFile, regex))
                ConfigFile = AppDomain.CurrentDomain.BaseDirectory + ConfigFile;
            using(System.IO.StreamReader reader = new System.IO.StreamReader(ConfigFile))
            {
                return reader.ReadToEnd();
            }
        }
        public string ConfigFile
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string AppName
        {
            get;
            set;
        }
    }
}
