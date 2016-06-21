using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configuration4Net
{
    public class Configuration4NetError:Exception
    {
        public Configuration4NetError()
        {
        }
        public Configuration4NetError(string message)
            : base(message)
        {
        }
        public Configuration4NetError(string format, params object[] data)
            : base(string.Format(format, data))
        {

        }
    }
}
