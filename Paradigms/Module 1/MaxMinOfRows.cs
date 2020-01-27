using System;

namespace Paradigms.Module_1
{
    public class MaxMinOfRows: Sorts
    {
        TypeSort _sortType;

        public MaxMinOfRows(TypeSort sortType)
        {
            _sortType = sortType;
        }

        /// <summary>
        /// Sorts the matrix according to the established sort order.
        /// </summary>
        /// <param name="array">Matrix numbers</param>
        /// <param name="sortOrder">Sort Order</param>
        /// 
        public override void Sort(int[,] array, SortOrder sortOrder)
        {
            int length;
            int[] elementRows = GetElementRowsArray(array, out length);
            Comparisons comparisons = new Comparisons(sortOrder);

            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (comparisons.Compare(elementRows[i], elementRows[j]))
                    {
                        ArrayHelper.SwapRows(array, i, j, length);
                        ArrayHelper.SwapValues(ref elementRows[i], ref elementRows[j]);
                    }
                }
            }

        }

        private int[] GetElementRowsArray(int[,] array, out int length)
        {
            length = array.GetLength(0);
            int[] tempArray = new int[length];
            Comparisons comparisons = new Comparisons(_sortType);

            for (int i = 0; i < length; i++)
            {
                int max = array[i, 0];
                for (int j = 1; j < length; j++)
                {
                    if (comparisons.Compare(array[i, j], max))
                    {
                        max = array[i, j];
                    }
                }
                tempArray[i] = max;
            }
            return tempArray;
        }
    }
}
