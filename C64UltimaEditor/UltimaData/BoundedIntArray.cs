using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimaData
{
    public static class MyExtensions
    {
        // Helper extension method
        public static IEnumerable AsWeakEnumerable(this IEnumerable source)
        {
            foreach (object o in source)
            {
                yield return o;
            }
        }
    }

    public class BoundedIntArray : IEnumerable<int>
    {
        public BoundedIntArray(int size, int lowerBound, int upperBound)
        {
            m_array = new int[size];
            m_lowerBound = lowerBound;
            m_upperBound = upperBound;
        }

        public int Length
        {
            get { return m_array.Length; }
        }

        public int this[int index]
        {
            get { return m_array[index]; }
            set
            {
                if (value < m_lowerBound || value > m_upperBound)
                {
                    throw new FormatException("Enter an integer between " + m_lowerBound + " and " + m_upperBound + ".");
                }
                else
                {
                    m_array[index] = value;
                }
            }
        }

        private int m_lowerBound;
        private int m_upperBound;
        private int[] m_array;

        public IEnumerator<int> GetEnumerator()
        {
            foreach (int i in this.m_array)
            {
                yield return i;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
       
    }
}
