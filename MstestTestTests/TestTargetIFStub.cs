using MstestTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MstestTestTests
{
    public class TestTargetIFStub : ITestTargetIF
    {
        public bool IsEnable(string str)
        {
            if (str == "Test")
                return false;
            return true;
        }
    }
}
