public class Solution
{
    public ListNode InsertGreatestCommonDivisors(ListNode head)
    {
        ListNode currentNode = head;

        while (currentNode.next != null)
        {
            ListNode nextNode = currentNode.next;
            int currentValue = currentNode.val;
            int nextValue = nextNode.val;

            int greatestCommonDivisor = GetGreatestCommonDivisor(currentValue, nextValue);
            ListNode newNode = new ListNode(greatestCommonDivisor, nextNode);

            currentNode.next = newNode;
            currentNode = nextNode;
        }

        return head;
    }

    public int GetGreatestCommonDivisor(int biggerNum, int smallerNum)
    {
        if (smallerNum > biggerNum)
        {
            (biggerNum, smallerNum) = (smallerNum, biggerNum);
        }

        while (smallerNum != 0)
        {
            int temp = smallerNum;
            smallerNum = biggerNum % smallerNum;
            biggerNum = temp;
        }

        return biggerNum;
    }
}
