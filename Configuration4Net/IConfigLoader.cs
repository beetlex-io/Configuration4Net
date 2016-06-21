using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configuration4Net
{
    public interface IConfigLoader
    {
        string Name { get; set; }
        string AppName { get; set; }
        string Load();
    }
}
