using Microsoft.VisualBasic;
using System.ComponentModel.Design;
using System.Data;

namespace Assignment_7._2._3_Is_it_an_Anagram
{
    /// <summary>
    /* Given two strings s and t, return true if t is an anagram of s, and false otherwise.

        An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, 
        typically using all the original letters exactly once.

        Example 1:

        Input: s = "anagram", t = "nagaram"

        Output: true

        Example 2:

        Input: s = "rat", t = "car"

        Output: false */
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = "toopy";
            string b = "cooky";

            var x = Solution.isAnagram(a, b) ? "Is anagram." : "Not anagram";
            Console.WriteLine(x);

        }
        public class Solution
        {
            public static bool isAnagram(string a, string b)
            {
                // FIRST step: compare length of strings
                if (a.Length != b.Length) // check if length of both strings is same, if can't possibly be an anagram (e.g. 'car' and 'carr')
                    return false;

                // SECOND step: compare characters
                Dictionary<char, int> stringComparator = new Dictionary<char, int>(); // Create a dictionary containing char as Key and int as Value. Store character as Key and count of character as Value.

                for (int i = 0; i < a.Length; i++) // Loop over all character of String a and put in Dictionary.
                {
                    if (stringComparator.ContainsKey(a[i])) // Check if Dictionary contains current character or not
                    {
                        stringComparator[a[i]] = stringComparator[a[i]] + 1;  // increase count by 1 for that character
                    }
                    else
                    {
                        stringComparator.Add(a[i], 1); // character is placed in map and count is set to 1 as character is encountered first time
                    }

                }

                for (int i = 0; i < b.Length; i++) // Loop over all character of String b
                {
                    if (stringComparator.ContainsKey(b[i])) // Check if Dictionary contains current character or not
                    {
                        stringComparator[b[i]] -= 1;
                    }
                    else
                    {
                        return false;
                    }
                }

                // THIRD step: extract all keys of Dictionary
                var keys = stringComparator.Keys;

                foreach (char key in keys)
                {
                    if (stringComparator[key] != 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
