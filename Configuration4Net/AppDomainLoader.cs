using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configuration4Net
{
    public class AppDomainLoader:IConfigLoader
    {
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

        public string Load()
        {
            string file = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            using (System.IO.StreamReader reader = new System.IO.StreamReader(file))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
