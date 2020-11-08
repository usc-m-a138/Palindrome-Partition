// C# program to print all palindromic partitions 
// of a given string. 
using System;
using System.Collections.Generic;

namespace Palindrome_Partition
{
	class Program
	{
		// Returns true if str is palindrome, else false 
		static bool checkPalindrome(String str)
		{
			int len = str.Length;
			len--;
			for (int i = 0; i < len; i++)
			{
				if (str[i] != str[len])
					return false;
				len--;
			}
			return true;
		}

		// Prints the partition list 
		static void printSolution(List<List<String>> partitions)
		{
			foreach (List<String> i in partitions)
			{
				foreach (String j in i)
				{
					Console.Write(j + " ");
				}
				Console.WriteLine();
			}
		}

		// Goes through all indexes and recursively add remaining 
		// partitions if current string is palindrome. 
		static List<List<String>> addStrings(List<List<String>> v, String s, List<String> temp, int index)
		{
			int len = s.Length;
			String str = "";
			List<String> current = new List<String>(temp);

			if (index == 0)
				temp.Clear();

			// Iterate over the string 
			for (int i = index; i < len; ++i)
			{
				str = str + s[i];

				// check whether the substring is 
				// palindromic or not 
				if (checkPalindrome(str))
				{
					// if palindrome add it to temp list 
					temp.Add(str);

					if (i + 1 < len)
					{
						// recurr to get all the palindromic 
						// partitions for the substrings 
						v = addStrings(v, s, temp, i + 1);
					}
					else
					{
						// if end of the string is reached 
						// add temp to v 
						v.Add(temp);
					}

					// temp is reinitialize with the 
					// current i. 
					temp = new List<String>(current);
				}
			}
			return v;
		}

		// Generates all palindromic partitions of 's' and 
		// stores the result in 'v'. 
		static void partition(String s, List<List<
											String>> v)
		{
			// temporary List to store each 
			// palindromic string 
			List<String> temp = new List<String>();

			// calling addString method it adds all 
			// the palindromic partitions to v 
			v = addStrings(v, s, temp, 0);

			// printing the solution 
			printSolution(v);
		}

		static void Main(string[] args)
		{
			Console.WriteLine("Enter string:");
			String s = Console.ReadLine();
			List<List<String>> partitions = new List<List<String>>();
			partition(s, partitions);
		}
	}
}

 

