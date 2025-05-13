using System;
using System.Collections.Generic;
using System.Globalization;
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
        

        static void Merge(int[] numbers, int l, int m, int r)
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

        static void MergeSort(int[] numbers, int l, int r)
        {
            if (l < r)
            {

                // Find the middle point
                int m = l + (r - l) / 2;

                // Sort first and second halves
                MergeSort(numbers, l, m);
                MergeSort(numbers, m + 1, r);

                // Merge the sorted halves
                Merge(numbers, l, m, r);
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
                if (item < min) min = item;
            }
            return min;
        }
        
        static int[] Sort()
        {
            int[] sorted = new int[length];
            for(int i = 0; i < length;) sorted[i] = numbers[i];
            MergeSort(sorted, 0, length);
            return sorted;
        }

        //return the avg of numbers
        static double GetAvg()
        {
            return (double) sum / (double)length;
        }

        //ret size of nums
        static int GetSize()
        {
            return length;
        }

        // ret the sum 
        static double GetSum()
        {
            return sum;
        }
        

        // print arrays
        static void Printer(int[] arr)
        {
            for (int i = 0;i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        //over writ func for print intagers
        static void Printer(int num)
        {
            Console.WriteLine(num);
        }

        //over writ func for print dubel
        static void Printer(double num)
        {
            Console.WriteLine(num);
        }

        //ret if all numbers is valid
        static bool Initialize(List<string> series)
        {
            int len = series.Count;
            if (len < 3) return false;
            int[] nums = new int[len];
            
            for(int i = 0; i< len;i++)
            {
                int temp;
                if ((!int.TryParse(series[i], out temp))||temp < 0)
                {
                    sum = 0;
                    Console.WriteLine("false");

                    return false;
                }
                sum += temp;
                nums[i] = temp;
            }
            numbers = nums;
            length = len;
            Console.WriteLine("true");
            return true;
        }

        //Display Menu
        static void DisplayMenu()
        {
            Console.WriteLine("press 0 for: insert a new seriea" +
                "press 1 for: Display the series in the order it was entered.\n" +
                "press 2 for: Display the series in the reversed order \n" +
                "press 3 for: Display the series in sorted order\n" +
                "press 4 for: Display the Max value of the series.\n" +
                "press 5 for: Display the Min value of the series.\n" +
                "press 6 for: Display the Average of the series.\n" +
                "press 7 for: Display the Number of elements in the series.\n" +
                "press 8 for: Display the Sum of the series.\n" +
                "press 9 for: Exit.");
        }

        static void Start()
        {
            int select = 5;
            do
            {
                DisplayMenu();
                if (!int.TryParse(Console.ReadLine(), out select) || select > 9 || select < 0)
                {
                    Console.WriteLine("not valid choise try agein");
                }
                else
                {
                    switch (select)
                    {
                        case 0:Init(new string[1]);Start(); break;                            
                        case 1:Printer(GetNumbers());break;    
                        case 2:Printer(GetRevers());break;   
                        case 3:Printer(Sort());break;    
                        case 4:Printer(getMax());break;   
                        case 5: Printer(GetMin());break;    
                        case 6: Printer(GetAvg());break;     
                        case 7: Printer(GetSize());break;
                        case 8:Printer(GetSum());break; 
                    }
                } 
            }while (select != 9) ;
        }
        static void Init(string[] args)
        {
            List<string> initNums = new List<string>();
            do
            {
                if (args.Length < 3)
                {
                    Console.WriteLine("enter at least three positive numbers for exit prees -1");
                    string num = Console.ReadLine();
                    do
                    {
                        initNums.Add(num);
                        num = Console.ReadLine();
                    }
                    while (num != "-1");

                }
                else
                {
                    initNums = new List<string>(args);
                    Console.WriteLine("start init with the args");
                }
            } while (!Initialize(initNums));
        }
        static void Main(string[] args)
        {
            Init(args);
            Start();
        }
    }
}
