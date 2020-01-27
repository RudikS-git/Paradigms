namespace Paradigms.Module_1
{
    public class SumRows : Sorts
    {
        /// <summary>
        /// Sorts the matrix according to the established sort order.
        /// </summary>
        /// <param name="array">Matrix numbers</param>
        /// <param name="sortOrder">Sort Order</param>
        /// 
        public override void Sort(int [,] matrix, SortOrder sortOrder)
        {
            int length;
            int[,] arrayClone = (int[,])matrix.Clone();
            int[] sumRows = SumRowsArray(matrix, out length);
            Comparisons comparisons = new Comparisons(sortOrder);

            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (comparisons.Compare(sumRows[i], sumRows[j]))
                    {
                        ArrayHelper.SwapRows(matrix, i, j, length);
                        ArrayHelper.SwapValues(ref sumRows[i], ref sumRows[j]);
                    }
                }
            }
        }

        private int[] SumRowsArray(int[,] array, out int length)
        {
            length = array.GetLength(0);
            int[] tempArray = new int[array.GetLength(0)];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    tempArray[i] += array[i, j];
                }
            }

            return tempArray;
        }
    }
}
