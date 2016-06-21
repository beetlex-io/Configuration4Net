using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configuration4Net.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string value;
                value = System.Configuration.ConfigurationManager.AppSettings["PreserveLoginUrl"];
                value = Configuration4Net.ConfigurationManager.AppSettings["PreserveLoginUrl"];
                AgentConfiguration4NetSection section ;
                section = (AgentConfiguration4NetSection)System.Configuration.ConfigurationManager.GetSection("agentConfiguration4NetSection");
                section = (AgentConfiguration4NetSection)Configuration4Net.ConfigurationManager.GetSection("agentConfiguration4NetSection");
                Console.WriteLine(section);
                Console.WriteLine(value);
            }
            catch (Exception e_)
            {
                Console.WriteLine(e_.Message);
            }
            Console.Read();

        }
    }
}
