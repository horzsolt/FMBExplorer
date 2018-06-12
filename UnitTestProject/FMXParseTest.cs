using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using FMBExplorer;
using FMBExplorer.FormsElement;
using FMBExplorer.FormsParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{

    [TestClass]
    public class FMXParseTest
    {

        private TestContext testContextInstance;

        /// <summary>
        ///  Gets or sets the test context which provides
        ///  information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void FindBlockByName()
        {
            XNamespace ns = String.Empty;
            XElement fmx = XElement.Load(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resource\\KOD_fmb.xml"));

            var block = BlockParser.GetBlockByName(ns, fmx, "KOD");

            Assert.IsNotNull(block);

            Assert.AreEqual("KOD", block.QueryDataSourceName);
            Assert.AreEqual("5", block.RecordsDisplayCount);

            var block2 = BlockParser.GetBlockByName(ns, fmx, "FORMS_SPEC");

            Assert.IsNotNull(block2);

            Assert.AreEqual("FORMS_SPEC_CTRL", block2.NextNavigationBlockName);
            Assert.AreEqual("false", block2.InsertAllowed);

            //Assert.IsTrue(x.Count() > 0);
        }

        [TestMethod]
        public void TestGettingBlocks()
        {
            string[] filePaths = Directory.GetFiles(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resource"), "*.xml");

            filePaths.ToList<string>().ForEach(xmlFile =>
            {
                FMXParser.ProcessFormsXML(xmlFile);
            });
        }
    }
}
