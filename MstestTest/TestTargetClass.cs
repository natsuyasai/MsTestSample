using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MstestTest
{
    public class TestTargetClass
    {
        private int _privateMember = 0;

        private static string _privateStaticMember = "";

        public int PublicMethod(int param)
        {
            return param + 1;
        }

        public int GetPrivateMemberValue()
        {
            return _privateMember;
        }

        private int PrivateMethod(int val1, int val2)
        {
            return val1 + val2;
        }

        private async Task<int> PrivateMethodAsync(int val1, int val2)
        {
            await Task.Delay(0);
            return val1 + val2;
        }

        private static string GetPrivateStaticMember()
        {
            return _privateStaticMember;
        }
    }
}
