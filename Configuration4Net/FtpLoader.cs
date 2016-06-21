using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Configuration4Net
{
    public class FtpLoader:IConfigLoader
    {
        public string Load()
        {
            System.Net.FtpWebRequest request = (FtpWebRequest)System.Net.WebRequest.Create(ConfigURL);
            if (!string.IsNullOrEmpty(User))
            {
                request.Credentials = new NetworkCredential(User, PassWord);
               
            }
            using (System.Net.FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
           
        }

        public string ConfigURL
        {
            get;
            set;
        }

        public string User { get; set; }

        public string PassWord { get; set; }

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
