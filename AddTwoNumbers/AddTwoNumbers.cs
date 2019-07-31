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

        public class Solution
        {
            static void Main()
            {
                ListNode oneMaster = new ListNode(2);
                ListNode two = new ListNode(4);
                ListNode three = new ListNode(3);
                oneMaster.next = two;
                two.next = three;

                ListNode twoMaster = new ListNode(5);
                ListNode four = new ListNode(6);
                ListNode five = new ListNode(4);
                twoMaster.next = four; four.next = five;

                var addedListNode = AddTwoNumbers(oneMaster, twoMaster);
            }

            public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
            {
                //Loop through each list prepending each number in the list to a string
                var sum = (ConnectNumber(l1) + ConnectNumber(l2)).ToString();
                var sumLength = sum.Length - 1;

                //Initialize master node with value at the end of sum
                ListNode initialNode = new ListNode(int.Parse(sum[sumLength].ToString()));

                //sum = 123
                if (sum.Length > 1)
                {
                    initialNode.next = new ListNode(int.Parse(sum[sumLength-1].ToString()));
                    ListNode workingNode = initialNode.next;

                    for (int i = sumLength - 2; i >= 0; i--)
                    {
                        var previousNode = workingNode;
                        workingNode = new ListNode(int.Parse(sum[i].ToString()));
                        previousNode.next = workingNode;
                    }
                }

                return initialNode;
            }

            public static int ConnectNumber(ListNode numberList)
            {
                string number = "";
                var nextNumber = numberList;

                while (nextNumber != null)
                {
                    number = nextNumber.val.ToString() + number.ToString();
                    nextNumber = nextNumber.next;
                }
                return int.Parse(number);
            }
        }
    }
}
