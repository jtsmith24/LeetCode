using System;

namespace LeetCode
{
    public partial class Solution
    {
        static void Main()
        {
            int[] test = { 1, 1,2, 7, 9 };
            int[] indices = TwoSum(test, 9);

            foreach(var value in indices)
            {
                Console.WriteLine(value);
            }
            Console.Read();
        }

        static public int[] TwoSum(int[] nums, int target)
        {
            int[] indices = null;
            int sum = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    sum = nums[i] + nums[j];
                    if (sum == target)
                    {
                        indices = new int[] { i, j };
                    }
                }
            }
            return indices;
        }
    }
}
