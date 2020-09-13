using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalc_Z
{
    interface ICalculatorOperations
    {
        void Push(int number);
        int Pop();
        int Add();
        int Sub();
        int Peek();
        int Count();
        int Size();
    }
}
