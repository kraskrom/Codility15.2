/*
An integer M and a non-empty array A consisting of N non-negative integers are given. All integers in array A are less than or equal to M.

A pair of integers (P, Q), such that 0 ≤ P ≤ Q < N, is called a slice of array A. The slice consists of the elements A[P], A[P + 1], ..., A[Q]. A distinct slice is a slice consisting of only unique numbers. That is, no individual number occurs more than once in the slice.

For example, consider integer M = 6 and array A such that:

    A[0] = 3
    A[1] = 4
    A[2] = 5
    A[3] = 5
    A[4] = 2
There are exactly nine distinct slices: (0, 0), (0, 1), (0, 2), (1, 1), (1, 2), (2, 2), (3, 3), (3, 4) and (4, 4).

The goal is to calculate the number of distinct slices.

Write a function:

class Solution { public int solution(int M, int[] A); }

that, given an integer M and a non-empty array A consisting of N integers, returns the number of distinct slices.

If the number of distinct slices is greater than 1,000,000,000, the function should return 1,000,000,000.

For example, given integer M = 6 and array A such that:

    A[0] = 3
    A[1] = 4
    A[2] = 5
    A[3] = 5
    A[4] = 2
the function should return 9, as explained above.

Write an efficient algorithm for the following assumptions:

N is an integer within the range [1..100,000];
M is an integer within the range [0..100,000];
each element of array A is an integer within the range [0..M].
*/

using System;
using System.Collections.Generic;

namespace Codility15._2
{
    class Solution
    {
        public int solution(int M, int[] A)
        {
            int s = 0;
            int b = 0;
            int l = 0;
            HashSet<int> cat = new HashSet<int>();
            while (b < A.Length)
            {
                while (b + l < A.Length && !cat.Contains(A[b + l]))
                {
                    cat.Add(A[b + l]);
                    s++;
                    if (s > 1000000000)
                        return 1000000000;
                    l++;
                }
                cat.Remove(A[b]);
                b++;
                l--;
                s += l;
                if (s > 1000000000)
                    return 1000000000;
            }
            return s;
        }
    }

    class Program
    {
        static void Main()
        {
            Solution sol = new Solution();
            //int[] A = { 3, 4, 5, 5, 2 };
            int[] A = new int[100000];
            for (int i = 0; i < 100000; i++)
                A[i] = i % 5000;
            int s = sol.solution(5000, A);
            Console.WriteLine("Solution: " + s);
            //Console.WriteLine("Solution: " + string.Join(", ", s));
        }
    }
}
