using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class AnalysisOfAlgorithms
    {
        ///3-Sum
        ///Given N distinct integers, how many triples can be added to get 0?
        ///This is deeply related to problems in computational geometry.
        public static class ThreeSumm
        {
            /// these are the arrays that get parsed.
            #region Integer Arrays
            public static int[] ints8 = { 30, -40, -20, -10, 40, 0, 10, 5 };
            public static int[] ints19 = { 30, -40, -20, -10, 40, 0, 10, 5, 3, -3, -60, 60, 90, 50, 200, -200, 44, -44, 54 };
            public static int[] ints38 =
                { 30, -40, -20, -10, 40, 0, 10, 5, 3, -3, -60, 60, 90, 50, 200, -200, 44, -44, 54,
                -75, -75, 66, -66, 65, 45, 25, 33, 65, 95, 75, 25, 24, -24, -14, -36, 55, 91, 30}; 
            #endregion
             
            /// <summary>
            /// This is an inefficient, brute force approach.
            /// It runs at ~ (1/6)n^3 -> O(n^3)
            /// </summary>
            /// <param name="ints"></param>
            /// <returns>Number of sumations that add up to 0.</returns>
            public static int Count(int[] ints)
            {
                int N = ints.Length;
                int count = 0;

                for (int i = 0; i < N; i++)
                {
                    for (int i2 = i+1; i2 < N; i2++)
                    {
                        for (int i3 = i2+1; i3 < N; i3++)
                        {
                            int result = ints[i] + ints[i2] + ints[i3];
                            if (result == 0)
                            {
                                count++;
                                Console.WriteLine
                                    ("{0} + {1} + {2} = {3}", ints[i], ints[i2], ints[i3], result);
                            }
                        }
                    }
                }

                return count;
            }


        }

        public class BinarySearch
        {
            public static int[] ints =
                {6, 13, 14, 25, 33, 43, 51, 53, 64, 72, 84, 93, 95, 96, 97};

            /// <summary>
            /// Finds the position of the given target within the given array.
            /// This is an efficient algorithm that runs unly at O(log n).
            /// </summary>
            /// <param name="ints"></param>
            /// <param name="target"></param>
            /// <returns></returns>
            public static int BinarySearch1(int[] ints, int target)
            {
                int lo = 0;
                int hi = ints.Length - 1;
                while (lo <= hi)
                {
                    int mid = lo + ((hi - lo) / 2); //This results in the middle item of the remaining range in the array (between hi and lo).
                    if (target < ints[mid])         hi = mid - 1; //Disregard mid and above.
                    else if (target > ints[mid])    lo = mid + 1; //Disregard mid and under.
                    else                            return mid;    //Target found, return the position.
                }
                return -1;  //The target was not in the array.
            }

            /// <summary>
            /// This was my attempt at solving it but it has bugs.
            /// </summary>
            /// <param name="target"></param>
            /// <param name="ints"></param>
            /// <returns></returns>
            public static int TestBinarySearch(int target, int[] ints)
            {
                int position = ints.Length / 2;
                int low = 0;
                int high = ints.Length;

                while (low + 1 != high)
                {
                    if (ints[position] == target)
                        return position;
                    else
                    {
                        if (ints[position] < target)
                        {
                            low = position + 1;
                        }
                        else
                        {
                            high = position - 1;
                        }
                        position = (ints.Length - 1 - low - (ints.Length - 1 - high)) + low;
                        position = (high - low)/2 + low;
                    }
                }
                return -1;
            }
        }
    }
}
