using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalc_Z
{
    class Calculator : ICalculatorOperations
    {
        private int StackSize = 5; // Stack size
        private Stack<XInt> Stack { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Calculator()
        {
            Stack = new Stack<XInt>(StackSize);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="stackSize">stack size</param>
        public Calculator(int stackSize)
        {
            StackSize = stackSize;
            Stack = new Stack<XInt>(StackSize);
        }

        /// <summary>
        /// Add command
        /// </summary>
        /// <returns>the added result value</returns>
        public int Add()
        {
            XInt xNumber_1 = Stack.Pop();
            XInt xNumber_2 = Stack.Pop();
            XInt xNumber_result = new XInt();
            xNumber_result.SetNumber(xNumber_1.ConvertToInt() + xNumber_2.ConvertToInt());
            Stack.Push(xNumber_result);
            return xNumber_result.ConvertToInt();
        }

        /// <summary>
        /// Pops out the top most value
        /// </summary>
        /// <returns>popped value</returns>
        public int Pop()
        {
            XInt xNumber = Stack.Pop();
            return xNumber.ConvertToInt();
        }

        /// <summary>
        /// Peeks the top most value
        /// </summary>
        /// <returns>peeked value</returns>
        public int Peek()
        {
            XInt xNumber = Stack.Peek();
            return xNumber.ConvertToInt();
        }

        /// <summary>
        /// Pushes the given value into the stack
        /// </summary>
        /// <param name="number">value to push into stack</param>
        public void Push(int number)
        {
            XInt xNumber = new XInt();
            xNumber.SetNumber(number);
            Stack.Push(xNumber);
        }

        /// <summary>
        /// Subdivides two top most values
        /// </summary>
        /// <returns>subdivision result</returns>
        public int Sub()
        {
            XInt xNumber_1 = Stack.Pop();
            XInt xNumber_2 = Stack.Pop();
            XInt xNumber_result = new XInt();
            xNumber_result.SetNumber(xNumber_1.ConvertToInt() - xNumber_2.ConvertToInt());
            Stack.Push(xNumber_result);
            return xNumber_result.ConvertToInt();
        }

        /// <summary>
        /// Returns stack values as string format
        /// </summary>
        /// <returns>stack values</returns>
        public override string ToString()
        {
            string result = "stack is(";
            foreach(XInt xInt in Stack)
            {
                result += xInt.ConvertToInt() +",";
            }
            result = result.TrimEnd(',');
            result += ")";
            return result;

        }

        /// <summary>
        /// Returns amount of values inside stack
        /// </summary>
        /// <returns>int value representing count</returns>
        public int Count()
        {
            return Stack.Count();
        }

        /// <summary>
        /// Return stack maximum size
        /// </summary>
        /// <returns>int value</returns>
        public int Size()
        {
            return StackSize;
        }
    }
}
