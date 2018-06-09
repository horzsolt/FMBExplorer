using System;
using FMBExplorer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class FMXParseTest
    {
        [TestMethod]
        public void TestGettingBlocks()
        {
            FMXParser.ProcessFormsXML(@"e:\KK.NET\FMB\KOD_fmb.xml");
        }
    }
}
