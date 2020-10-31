using Microsoft.VisualStudio.TestTools.UnitTesting;
using MstestTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MstestTest.Tests
{
    [TestClass()]
    public class TestTargetClassTests
    {
        /// <summary>
        /// Public
        /// </summary>
        [TestMethod()]
        public void PublicMethodTest()
        {
            var instance = new TestTargetClass();
            var ret = instance.PublicMethod(1);
            Assert.AreEqual(ret, 2);
        }

        /// <summary>
        /// Private変数
        /// </summary>
        [TestMethod()]
        public void GetPrivateMemberValueTest()
        {
            var instance = new TestTargetClass();
            var privateObject = new PrivateObject(instance);
            privateObject.SetFieldOrProperty("_privateMember", 100);
            var ret = instance.GetPrivateMemberValue();
            Assert.AreEqual(ret,100);
        }

        /// <summary>
        /// Privateメソッド
        /// </summary>
        [TestMethod()]
        public void PrivateMethodTest()
        {
            var instance = new TestTargetClass();
            var privateObject = new PrivateObject(instance);
            var ret = privateObject.Invoke("PrivateMethod", 100, 200);
            Assert.AreEqual(ret, 300);
        }

        /// <summary>
        /// Privateメソッド(非同期)
        /// </summary>
        /// <returns></returns>
        [TestMethod()]
        public async Task PrivateMethodAsyncTest()
        {
            var instance = new TestTargetClass();
            var privateObject = new PrivateObject(instance);
            var ret = await (privateObject.Invoke("PrivateMethodAsync", 100, 200) as Task<int>);
            Assert.AreEqual(ret, 300);
        }

        /// <summary>
        /// Privateメソッド
        /// </summary>
        [TestMethod()]
        public void GetPrivateStaticMemberTest()
        {
            var privateType = new PrivateType(typeof(TestTargetClass));
            privateType.SetStaticFieldOrProperty("_privateStaticMember", "ヨシッ！");
            var ret = privateType.InvokeStatic("GetPrivateStaticMember");

            Assert.AreEqual(ret, "ヨシッ！");
        }
    }
}