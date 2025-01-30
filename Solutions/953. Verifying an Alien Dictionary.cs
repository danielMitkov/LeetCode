public class Solution
{
    public bool IsAlienSorted(string[] words, string order)
    {
        var alphabet = new Dictionary<char, int>();

        for (int i = 0; i < order.Length; ++i)
        {
            alphabet.Add(order[i], i);
        }

        for (int i = 0; i < words.Length - 1; ++i)
        {
            string current = words[i];
            string next = words[i + 1];
            int shorter = current.Length < next.Length ? current.Length : next.Length;

            for (int j = 0; j <= shorter; ++j)
            {
                if (j == current.Length) break;
                if (j == next.Length) return false;

                char a = current[j];
                char b = next[j];

                if (a == b) continue;
                if (alphabet[a] < alphabet[b]) break;
                return false;
            }
        }

        return true;
    }
}

//keep checking current chars until they are not equal -> one is before the other
//hashtable for the alien alphabet key = char value = order number
//compare whichever number is smaller wins the lexical order
//empty char is the smallest character 