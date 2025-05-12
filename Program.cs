using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9200
{
    internal class Program
    {
        static int length = 0;
        static int sum = 0;
        static int[] numbers;

        static void merge(int[] numbers, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;

            // Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                L[i] = numbers[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = numbers[m + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged
            // subarray array
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    numbers[k] = L[i];
                    i++;
                }
                else
                {
                    numbers[k] = R[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements of L[] if any
            while (i < n1)
            {
                numbers[k] = L[i];
                i++;
                k++;
            }

            // Copy remaining elements of R[] if any
            while (j < n2)
            {
                numbers[k] = R[j];
                j++;
                k++;
            }
        }

        static void mergeSort(int[] numbers, int l, int r)
        {
            if (l < r)
            {

                // Find the middle point
                int m = l + (r - l) / 2;

                // Sort first and second halves
                mergeSort(numbers, l, m);
                mergeSort(numbers, m + 1, r);

                // Merge the sorted halves
                merge(numbers, l, m, r);
            }
        }


        //return the series
        static int[] GetNumbers()
        {
            return numbers; 
        }

        //return the series in revers order
        static int[] GetRevers()
        {
            int[] revers = new int[length];
            for (int i = 0; i < length; i++)
            {
               revers[i] =  numbers[length - i - 1];
            }
            return revers;
        }

        //ret the max val in numbers
        static int getMax()
        {
            int max = numbers[0];
            foreach (int item in numbers)
            {
                if (item > max) max = item;
            }
            return max;
        }

        //ret the min val in numbers
        static int GetMin()
        {
            int min = numbers[0];
            foreach (int item in numbers)
            {
                if (item > min) min = item;
            }
            return min;
        }
        
        static int[] Sort()
        {
            int[] sorted = new int[length];
            for(int i = 0; i < length;) sorted[i] = numbers[i];
            mergeSort(sorted, 0, length);
            return sorted;
        }

        //return the avg of numbers
        static double GetAvg()
        {
            return (double) sum / (double)length;
        }

        static int Getsize()
        {
            return length;
        }

        static void Main(string[] args)
        {

        }
    }
}
