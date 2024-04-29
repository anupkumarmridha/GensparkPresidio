using System;
using System.Text;

namespace LeetcodeAsyncAwait
{
    public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }
    public class TreeNode
     {
       public int val;
       public TreeNode left;
       public TreeNode right;
       public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
       {
            this.val = val;
            this.left = left;
            this.right = right;
       }

     }
    internal class Program
    {
        async Task<int> MinDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.left == null && root.right == null)
            {
                return 1;
            }
            int min_depth = int.MaxValue;
            if (root.left != null)
            {
                min_depth = Math.Min(await MinDepth(root.left), min_depth);
            }
            if (root.right != null)
            {
                min_depth = Math.Min(await MinDepth(root.right), min_depth);
            }
            return min_depth + 1;   
        }

        /// <summary>
        /// Given an integer columnNumber, return its corresponding column title as it appears in an Excel sheet.
        /// </summary>
        /// <param name="columnNumber"></param>
        /// <returns></returns>
        async Task<string> convertToTitle(int columnNumber)
        {
            StringBuilder sb = new StringBuilder();
            while (columnNumber > 0)
            {
                columnNumber--;
                sb.Append((char)('A' + columnNumber % 26));
                columnNumber /= 26;
            }
            char[] arr = sb.ToString().ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        /// <summary>
        /// Given head, the head of a linked list, determine if the linked list has a cycle in it.
        ///There is a cycle in a linked list if there is some node in the list that can be reached
        ///again by continuously following the next pointer.Internally, pos is used to denote the 
        ///index of the node that tail's next pointer is connected to. Note that pos is not passed
        ///as a parameter.
        ///Return true if there is a cycle in the linked list.Otherwise, return false.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        async Task<bool> HasCycle(ListNode head)
        {
            if (head == null)
            {
                return false;
            }
            ListNode slow = head;
            ListNode fast = head.next;
            while (slow != fast)
            {
                if (fast == null || fast.next == null)
                {
                    return false;
                }
                slow = slow.next;
                fast = fast.next.next;
            }
            return true;
        }


        static async Task Main(string[] args)
        {
            //building tree
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);
            Program p = new Program();

            var minDepthTask = p.MinDepth(root);
            //Console.WriteLine(await p.MinDepth(root));


            var convertToTitleTask = p.convertToTitle(701);

            //creating a cycle in the linked list
            ListNode head = new ListNode(3);
            head.next = new ListNode(2);
            head.next.next = new ListNode(0);
            head.next.next.next = new ListNode(-4);
            head.next.next.next.next = head.next;

            var hasCycleTask = p.HasCycle(head);

            var allTasks= new List<Task> { minDepthTask, convertToTitleTask, hasCycleTask};

            while (allTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(allTasks);
                if (finishedTask == minDepthTask)
                {
                    Console.WriteLine($"Min Depth Task Done, \n Result = {minDepthTask.Result}");
                }
                else if (finishedTask == convertToTitleTask)
                {
                    Console.WriteLine($"Convert to Title Task done. \n Result = {convertToTitleTask.Result}");
                }
                else if (finishedTask == hasCycleTask)
                {
                    Console.WriteLine($"Cycle detection task done. \n Result = {hasCycleTask.Result} ");
                }
                allTasks.Remove(finishedTask);
            }
            //Console.WriteLine(await p.HasCycle(head));

        }
    }
}
