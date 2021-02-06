using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MstestTest;
using MstestTestTests;
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
        /// Privateメソッド
        /// </summary>
        [TestMethod()]
        public void PrivateMethodTest()
        {
            var instance = new TestTargetClass();
            var privateObject = new PrivateObject(instance);

            // メンバ変数値変更
            privateObject.SetFieldOrProperty("_privateMember", 100);
            // Privateメソッド呼び出し
            var ret = privateObject.Invoke("PrivateMethod", 100, 200);
            Assert.AreEqual(ret, 400);
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
            // 戻り値の型でくるんでawait
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
            // static変数値変更
            privateType.SetStaticFieldOrProperty("_privateStaticMember", "ヨシッ！");
            // staticメソッド呼び出し
            var ret = privateType.InvokeStatic("GetPrivateStaticMember");

            Assert.AreEqual(ret, "ヨシッ！");
        }

        [TestMethod()]
        public void GetIFReturnTest()
        {
            var mock = new Mock<ITestTargetIF>();
            mock.Setup(x => x.IsEnable("Test"))
                .Returns(false);
            var instance = new TestTargetClass(mock.Object);
            var ret = instance.GetIFReturn("Test");
            Assert.AreEqual(ret, false);
        }

        [TestMethod()]
        public void GetIFReturnTest_Error()
        {
            var instance = new TestTargetClass(new TestTargetIFStub());
            var ret = instance.GetIFReturn("Test");
            Assert.AreEqual(ret, false);
        }
    }
}