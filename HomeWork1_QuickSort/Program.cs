using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1_QuickSort
{
    class Program
    {
        static public int[] SortArray(int[] array)
        {
            if (array.Max() == array.Min())
            {
                return array;
            }
            double bearingPoint = (double)(array.Min() + array.Max()) / 2;
            int[] firstPartArray = new int[array.Length];
            int[] secondPartArray = new int[array.Length];
            int counter1 = 0;
            int counter2 = 0;

            //разбиваем массив относительно опорного элемента
            for (int l = 0; l < array.Length; l++)
            {
                if (array[l] < bearingPoint)
                {
                    firstPartArray[counter1] = array[l];
                    counter1++;
                }
            }
            for (int r = array.Length - 1; r >= 0; r--)
            {
                if (array[r] >= bearingPoint)
                {
                    secondPartArray[counter2] = array[r];
                    counter2++;
                }
            }

            //удаляем лишние элементы в новых массивах
            int[] cleanFirstArray = new int[counter1];
            for (int i = 0; i < counter1; i++)
            {
                cleanFirstArray[i] = firstPartArray[i];
                array[i] = cleanFirstArray[i];
            }
            int[] cleanSecondArray = new int[counter2];
            for (int i = 0; i < counter2; i++)
            {
                cleanSecondArray[i] = secondPartArray[i];
                array[i + counter1] = cleanSecondArray[i];
            }

            //вызываем рекурсию каждого из подмассивов
            if (counter1 > 1)
            {
                SortArray(cleanFirstArray);
            }
            if (counter2 > 1)
            {
                SortArray(cleanSecondArray);
            }

            //обновляем элементы общего массива
            for (int i = 0; i < counter1; i++)
            {
                array[i] = cleanFirstArray[i];
            }
            for (int i = 0; i < counter2; i++)
            {
                array[i + counter1] = cleanSecondArray[i];
            }

            return array;
        }



        static public void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0}, ", array[i]);
            }
        }
        static public int[] GenerateArray(int index)
        {
            int[] array = new int[index];
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(0, 100);
            }
            return array;
        }

        static void Main(string[] args)
        {
            int[] array = GenerateArray(15);
            PrintArray(array);
            Console.WriteLine();
            PrintArray(SortArray(array));

        }
    }
}

