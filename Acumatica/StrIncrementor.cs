using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acumatica
{
    public class StrIncrementor : IStrIncrementor
    {
        public char[] Increment(char[] strToIncrement)
        {
            char[] ret = new char[strToIncrement.Length];
            strToIncrement.CopyTo(ret, 0);

            for (int i = strToIncrement.Length - 1; (i >= 0); i--)
                if (ret[i] < '9' && ret[i] >= '0') { ret[i]++;
                    break; }
                else
                if (ret[i] == '9') ret[i] = '0';
                else break;

            return ret;

        }
    }
}
