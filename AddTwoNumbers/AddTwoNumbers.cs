using System;
using System.Threading.Tasks;

namespace AddTwoNumbers
{
    class Program
    {
        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public partial class Solution
        {
            public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
            {
                //Loop through each list prepending each number in the list to a string
                var sum = (ConnectNumber(l1) + ConnectNumber(l2)).ToString();

                //Initialize master node with value at the end of sum
                ListNode SummedNumberListNode = new ListNode(sum[sum.Length-1]);

                if(sum.Length > 1)
                {
                    SummedNumberListNode.next = new ListNode(sum[sum.Length - 2]);
                    var workingNode = SummedNumberListNode;

                    for(int i = sum.Length - 2; i > 0; i--)
                    {
                        var previousNode = workingNode;
                        workingNode.next = new ListNode(sum[i]);

                    }
                }

                return SummedNumberListNode;
            }

            public int ConnectNumber(ListNode numberList)
            {
                string number = "";
                while (numberList.next != null)
                {
                    number = numberList.val.ToString() + number.ToString();
                }
                return int.Parse(number);
            }
        }
    }
}
