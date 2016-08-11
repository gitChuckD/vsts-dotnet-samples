﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using VstsRestApiSamples.WorkItemTracking;
using System.Net;

namespace VstsRestApiSamples.Tests.WorkItemTracking
{
    [TestClass]
    public class SamplesTest
    {
        private IConfiguration _configuration = new Configuration();

        [TestInitialize]
        public void TestInitialize()
        {
            InitHelper.GetConfiguration(_configuration);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _configuration = null;
        }

        [TestMethod, TestCategory("REST API")]  
        public void WorkItemTracking_Samples_CreateBug_Success()
        {
            //arrange
            Samples samples = new Samples(_configuration);

            //act
            var response = samples.CreateNewBug();

            //assert
            Assert.AreEqual("success", response);

            samples = null;
        }       
    }
}
