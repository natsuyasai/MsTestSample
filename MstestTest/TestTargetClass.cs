using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MstestTest
{
    /// <summary>
    /// テスト対象クラス
    /// </summary>
    public class TestTargetClass
    {
        private ITestTargetIF _testInterface;

        /// <summary>
        /// コンストラクタ(デフォルト）
        /// </summary>
        public TestTargetClass() => _testInterface = new TestTargetIFConcrete();

        /// <summary>
        /// コンストラクタ(DI)
        /// </summary>
        /// <param name="testTargetIF"></param>
        public TestTargetClass(ITestTargetIF testTargetIF) => _testInterface = testTargetIF;

        /// <summary>
        /// Privateメンバ変数
        /// </summary>
        private int _privateMember = 0;

        /// <summary>
        /// PrivateStaticメンバ変数
        /// </summary>
        private static string _privateStaticMember = "";

        /// <summary>
        /// Publicメソッド
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public int PublicMethod(int param)
        {
            return param + 1;
        }

        /// <summary>
        /// 外部依存
        /// </summary>
        /// <returns></returns>
        public bool GetIFReturn(string str)
        {
            return _testInterface.IsEnable(str);
        }

        /// <summary>
        /// Privateメソッド
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        private int PrivateMethod(int val1, int val2)
        {
            return _privateMember + val1 + val2;
        }

        /// <summary>
        /// Privateメソッド(非同期)
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        private async Task<int> PrivateMethodAsync(int val1, int val2)
        {
            await Task.Delay(0);
            return val1 + val2;
        }

        /// <summary>
        /// PrivateStaticメソッド
        /// </summary>
        /// <returns></returns>
        private static string GetPrivateStaticMember()
        {
            return _privateStaticMember;
        }
    }
}
