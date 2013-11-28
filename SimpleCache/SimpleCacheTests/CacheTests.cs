using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCache;

namespace SimpleCacheTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class CacheTests
    {
        public CacheTests()
        {
        }


        [TestMethod]
        public void TestExistingPostcode()
        {
            Assert.AreEqual<string>("Sydney", PostcodeCache.GetPostcode(2000));
            Assert.AreEqual<string>("Melbourne", PostcodeCache.GetPostcode(3000));
            Assert.AreEqual<string>("Brisbane", PostcodeCache.GetPostcode(4000));
        }
        [TestMethod]
        public void TestPostcodeNonExisting()
        {
            Assert.AreEqual<string>(null, PostcodeCache.GetPostcode(1234));
        }
    }
}
