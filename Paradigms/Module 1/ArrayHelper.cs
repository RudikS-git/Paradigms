using System;
using System.Collections.Generic;
using System.Text;

namespace Paradigms.Module_1
{
    class ArrayHelper
    {
        static public void SwapRows(int[,] array, int indexFirst, int indexSecond, int length)
        {
            int[] rowFirst = GetRow(array, indexFirst, length);
            int[] rowSecond = GetRow(array, indexSecond, length);

            int[] temp = (int[])rowFirst.Clone();
            SetRow(array, rowSecond, indexFirst, length);
            SetRow(array, temp, indexSecond, length);
        }

        static public void SwapValues(ref int valueFirst, ref int valueSecond)
        {
            int temp = valueFirst;
            valueFirst = valueSecond;
            valueSecond = temp;
        }

        static public int[] GetRow(int[,] array, int index, int length)
        {
            int[] row = new int[length];

            for (int i = 0; i < length; i++)
            {
                row[i] = array[index, i];
            }

            return row;
        }

        static public void SetRow(int[,] array, int[] row, int index, int length)
        {
            for (int i = 0; i < length; i++)
            {
                array[index, i] = row[i];
            }
        }

        static public void Contrary(int[,] array, int length)
        {
            for (int i = 0; i < length; i++)
            {
                SwapRows(array, i, length - i - 1, length);
            }
        }

        static public bool ArraysEqual(int[,] arrayFirst, int[,] arraySecond, int length)
        {
            if (arrayFirst.Length != arraySecond.Length) return false;

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (arrayFirst[i, j] != arraySecond[i, j]) return false;
                }
            }

            return true;
        }
    }
}
