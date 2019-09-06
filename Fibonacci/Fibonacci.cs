using System;
using System.Collections.Generic;
using System.Linq;

namespace Fibonacci
{
    public class Fibonacci
    {
        /// <summary>
        /// This will generate the fibonacci sequence of numbers
        /// </summary>
        /// <remarks>
        /// This utilizes a storage-less method.  Meaning data is not first stored in a list or array and then returned.
        /// </remarks>
        /// <returns></returns>
        public IEnumerable<decimal> GenerateSequence()
        {
            decimal current = 0;
            decimal next = 1;
            decimal temp = current + next;

            yield return current;
            yield return next;

            while (temp < Decimal.MaxValue)
            {
                yield return temp;
                current = next;
                next = temp;

                // This will throw an error if the new value is outside the maximum range value for the decimal datatype
                try
                {
                    temp = current + next;
                }

                catch (Exception ex)
                {
                    break;
                }
            }

        }

        /// <summary>
        /// This will generate the fibonacci sequence of numbers for a given size
        /// </summary>
        /// <param name="sequenceSize"></param>
        /// <returns></returns>
        public IEnumerable<decimal> GenerateSequence(uint sequenceSize)
        {
            IEnumerable<decimal> seq = GenerateSequence();
            return seq.Take(Convert.ToInt32(sequenceSize));
        }


        /// <summary>
        /// This will check to see if a number exists within the fibonacci sequence
        /// </summary>
        /// <param name="value"></param>
        /// <returns>
        /// True if value is a number within the fibonacci sequence, otherwise false
        /// </returns>
        public bool Contains(decimal value)
        {
            // Validate parameter
            if (value < 0)
                throw new ArgumentOutOfRangeException(String.Format("Value {0} must be greater than or equal to zero", value));

            IEnumerable<decimal> seq = GenerateSequence();
            return seq.Any(x => x == value);
        }
    }
}
