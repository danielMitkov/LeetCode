public class Solution
{
    public int[] FindArray(int[] pref)
    {
        int[] arr = new int[pref.Length];
        arr[0] = pref[0];

        for(int i = 1;i < arr.Length;++i)
        {
            arr[i] = pref[i] ^ pref[i - 1];
        }
        return arr;
    }
}
