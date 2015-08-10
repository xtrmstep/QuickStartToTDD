using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickStartToTDD.Calculators.Interfaces;

namespace QuickStartToTDD.Calculators.Impl
{
    public class CalcFibonacci : IFibonacci
    {
        #region Implementation of IFibonacci

        public int Calc(int highBoundary)
        {
            var a = 0;
            var b = 1;
            while (a + b < highBoundary)
            {
                var t = b;
                b += a;
                a = t;
            }
            return b;
        }

        #endregion
    }
}
