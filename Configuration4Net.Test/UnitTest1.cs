using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Configuration4Net.Test
{
    [TestClass]
    public class UnitTest1
    {
       
        [TestMethod]
        public void TestMethod1()
        {
            string value = ConfigurationManager.AppSettings["PreserveLoginUrl"];
            object section = ConfigurationManager.GetSection("System.Web");
        }
    }
}
