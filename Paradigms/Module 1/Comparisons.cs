namespace Paradigms.Module_1
{
    public class Comparisons
    {
        private int _sort;

        public Comparisons(SortOrder sort)
        {
            _sort = (int)sort;
        }

        public Comparisons(TypeSort sort)
        {
            _sort = (int)sort;
        }

        /// <summary>
        /// Compares numbers according to sort type.
        /// </summary>
        /// <param name="firstNum">First Number</param>
        /// <param name="secondNum">Second Number</param>
        /// <returns>true - the first number is greater or less, false - conversely</returns>
        /// 
        public bool Compare(int firstNum, int secondNum)
        {
            if (_sort == 0)
            {
                if (firstNum < secondNum)
                {
                    return true;
                }
            }
            else
            {
                if(firstNum > secondNum)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
