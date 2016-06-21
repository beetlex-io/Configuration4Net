using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
namespace Configuration4Net
{
    public class HttpLoader:IConfigLoader
    {
        public string Load()
        {
            System.Net.HttpWebRequest request = (HttpWebRequest)System.Net.WebRequest.Create(ConfigURL);
            using (System.Net.HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (System.IO.Stream stream = response.GetResponseStream())
                {
                    Encoding coding = string.IsNullOrEmpty(response.ContentEncoding) ? Encoding.UTF8 : Encoding.GetEncoding(response.ContentEncoding);
                    System.IO.StreamReader reader = new System.IO.StreamReader(stream, coding);
                    return reader.ReadToEnd();
                       
                }
            }
        }

        public string ConfigURL
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
