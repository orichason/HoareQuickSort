using System;
using System.Collections.Generic;

namespace HoareQuickSort
{
    class Program
    {
        static void QuickSort<T>(T[] userList, int start, int end, IComparer<T> comparer)
        {
            int leftIndicator = start - 1;
            int rightIndicator = end;
            T pivot = userList[start];

            if (start + 1 >= end) return;

            while (leftIndicator <= rightIndicator)
            {
                do
                {
                    leftIndicator++;
                }
                while (leftIndicator <= rightIndicator && comparer.Compare(userList[leftIndicator], pivot) < 0);

                do
                {
                    rightIndicator--;
                }
                while (leftIndicator <= rightIndicator && comparer.Compare(userList[rightIndicator], pivot) > 0);

                if(leftIndicator > rightIndicator)
                {
                    break;
                }
                T temp = userList[rightIndicator];
                userList[rightIndicator] = userList[leftIndicator];
                userList[leftIndicator] = temp;
            }


            QuickSort(userList, start, leftIndicator, comparer);
            QuickSort(userList, leftIndicator, userList.Length, comparer);
        }

        static void QuickSort<T>(T[] userList, IComparer<T> comparer)
        {
            QuickSort(userList, 0, userList.Length, comparer);
        }

        class intComparer : IComparer<int>
        {
            public int Compare(int number1, int number2)
            {
                if (number1 > number2)
                {
                    return 1;
                }

                else if (number1 < number2)
                {
                    return -1;
                }

                else
                {
                    return 0;
                }
            }
        }

        static void Main(string[] args)
        {
            Random random = new Random(1);

            int[] numberList = new int[] { 1,1,1,1,1,1,1};

            for (int i = 0; i < numberList.Length; i++)
            {
                Console.Write($"{numberList[i]} , ");
            }

            intComparer comparer = new intComparer();

            QuickSort(numberList, comparer);

            Console.WriteLine();

            for (int i = 0; i < numberList.Length; i++)
            {
                Console.Write($" {numberList[i]} , ");
            }
        }
    }
}
