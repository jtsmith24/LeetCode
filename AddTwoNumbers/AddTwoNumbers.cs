using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace AddTwoNumbers
{
    class Program
    {
        public static List<int> l1NumberList = new List<int>()
        {
           1
        };
        public static List<int> l2NumberList = new List<int>()
        {
           1
        };

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
                ListNode l1 = InstantiateListNode(l1NumberList);
                ListNode l2 = InstantiateListNode(l2NumberList);

                var addedListNode = AddTwoNumbers(l1, l2);
            }

            public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
            {//Loop through each list prepending each number in the list to a string
                var sum = (ConnectNumber(l1) + ConnectNumber(l2)).ToString();

                //Initialize master node with value at the end of sum
                ListNode head = new ListNode(int.Parse(sum[sum.Length-1].ToString()));

                //Starts at the second to last index of sum string
                if (sum.Length > 1)
                {
                    for (int i = sum.Length - 2; i >= 0; i--)
                    {
                        head = InsertLast(head, int.Parse(sum[i].ToString()));
                    }
                }

                return head;
            }

            public static BigInteger ConnectNumber(ListNode numberList)
            {
                string number = "";
                var nextNumber = numberList;

                while (nextNumber != null)
                {
                    number = nextNumber.val.ToString() + number.ToString();
                    nextNumber = nextNumber.next;
                }
                return BigInteger.Parse(number);
            }

            public static ListNode InstantiateListNode(List<int> numbers)
            {
                ListNode head = null;
                
                //InsertLast
                foreach(var number in numbers)
                {
                    head = InsertLast(head, number);
                }

                return head;
            }

            public static ListNode InsertLast(ListNode list, int number)
            {
                ListNode newNode = new ListNode(number);
                if (list == null)
                {
                    return newNode;
                }
                ListNode lastNode = GetLastNode(list);
                lastNode.next = newNode;
                return list;
            }

            private static ListNode GetLastNode(ListNode head)
            {
                //base case
                if(head.next == null)
                {
                    return head;
                }
                else
                {
                    return GetLastNode(head.next);
                }
            }
        }
    }
}
