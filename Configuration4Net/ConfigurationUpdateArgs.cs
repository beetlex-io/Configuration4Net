using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configuration4Net
{
    public class ConfigurationUpdateArgs:EventArgs
    {
        public Configuration Configuration
        {
            get;
            set;
        }
    }
}
