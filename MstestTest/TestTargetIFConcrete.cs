using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MstestTest
{
    public class TestTargetIFConcrete : ITestTargetIF
    {
        public bool IsEnable(string str)
        {
            // 外部に依存する処理(通信やDBアクセスなど)
            return true;
        }
    }
}
