using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalc_Z
{
    class XInt
    {
        private BitArray Bits { get; set; } // Array where number represented in bits is saved
        private int size = 10; // bit amount

        /// <summary>
        /// Constructor
        /// </summary>
        public XInt()
        {
            Bits = new BitArray(size);
        }
        
        /// <summary>
        /// Constructor with bitamount
        /// </summary>
        /// <param name="bitAmount">amount of bits the number is saved</param>
        public XInt(int bitAmount)
        {
            size = bitAmount;
            Bits = new BitArray(size);
        }

        /// <summary>
        /// Sets value/number of this object
        /// </summary>
        /// <param name="number">Value that's going to be placed in here</param>
        public void SetNumber(int number)
        {
            if (CheckOverFlow(number) || CheckUnderFlow(number)) // Checks if number doesn't overflow or underflow our bits
            {
                int MaxNumber = (int)Math.Pow(2, size); // Calculate biggest possible number
                number = number % MaxNumber; // Find modul of number
                if (number < 0) // Check if number is negative
                {
                    number = MaxNumber + number;
                }
                string bitNumber = Convert.ToString(number, 2); // Convert to binary
                int[] bits = bitNumber.Select(x => int.Parse(x.ToString())).ToArray(); // Convert to bit array
                for (int i = 0; i < bits.Count(); i++) // Set up the values
                {
                    Bits[bits.Count() - i - 1] = bits[i] != 1 ? false : true;
                }
            }
            else
            {
                string bitNumber = Convert.ToString(number, 2); // Convert to binary
                int[] bits = bitNumber.Select(x => int.Parse(x.ToString())).ToArray(); // Convert to bit array
                for (int i = 0; i < bits.Count(); i++) // Set up the values
                {
                    Bits[bits.Count() -i-1] = bits[i] != 1 ? false : true;
                }
            }
        }     

        /// <summary>
        /// Checks if number will overflow object
        /// </summary>
        /// <param name="number">value to check</param>
        /// <returns>true/false if object would overflow</returns>
        private bool CheckOverFlow(int number)
        {
            double maxNumber = Math.Pow(2, size);
            if(number >= maxNumber)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if object would underflow
        /// </summary>
        /// <param name="number">number to check</param>
        /// <returns>true/false if object would underflow</returns>
        private bool CheckUnderFlow(int number)
        {
            if (number <= 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Converts current object value to int32
        /// </summary>
        /// <returns>int32 value number</returns>
        public int ConvertToInt()
        {
            int number = 0;
            for(int i = 0; i < size; i++)
            {
                if (Bits[i])
                {
                    number += Convert.ToInt32(Math.Pow(2, i));
                }
            }
            return number;
        }
    }
}
