using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimaData
{
    public class BoundedInt
    {
        public BoundedInt(int lowerBound, int upperBound)
        {
            m_value = lowerBound;
            m_lowerBound = lowerBound;
            m_upperBound = upperBound;
        }

        public int Value
        {
            get { return m_value; }
            set
            {
                if (value < m_lowerBound || value > m_upperBound)
                {
                    throw new FormatException("Assigned value must be between " + m_lowerBound + " and " + m_upperBound + ".");
                }
                else
                {
                    m_value = value;
                }
            }
        }

        public static implicit operator int(BoundedInt value)
        {
            return value.Value;
        }

        private int m_value;
        private int m_lowerBound;
        private int m_upperBound;
    }
}
