/*
 * diceware word list filter
 * Copyright 2019 Viktor Jasper
 * https://github.com/viktorjasper/hun-diceware-word-list
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;
using System.Linq;

// build: dotnet build
// run:  dotnet run bin/Debug/netcoreapp2.1/filter.dll "../Dictionary/" "../Books in Hungarian/" ../hun-vj.wordlist.asc

namespace filter
{
    class Program
    {
	static int Main(string[] args)
	{
	    if (args.Length != 4 ||
		!Directory.Exists(args[1]) ||
		!Directory.Exists(args[2])) {

		Console.WriteLine("Input folder expected!" +
		    "\n\nUsage: filter " +
		    "[dictionary words folder] [supporting words folder] [output wordlist file]");
		if(args.Count() >= 2) {
			Console.WriteLine("args[1]:" + args[1]);
		}
		if(args.Count() >= 3) {
			Console.WriteLine("args[2]:" + args[2]);
		}
		return -1;
	    }

	    string dictionaryFolder = args[1];
	    string supportingFolder = args[2];
	    string wordlistfile = args[3];

	    HashSet<string> candidateWords = new HashSet<string>();
	    foreach (string file in Directory.GetFiles(dictionaryFolder))
	    {
		string content = File.ReadAllText(file);
		HashSet<string> additionalWords = filterWords(content);
		candidateWords.UnionWith(additionalWords);
	    }

	    HashSet<string> supportingWords = new HashSet<string>();
	    foreach (string file in Directory.GetFiles(supportingFolder))
	    {
		string content = File.ReadAllText(file);
		HashSet<string> additionalWords = filterWords(content);
		supportingWords.UnionWith(additionalWords);
	    }

	    candidateWords.IntersectWith(supportingWords);
	    candidateWords = new HashSet<string>(candidateWords.
		OrderBy(p=>p.Length).Take(7776).ToList());
	    saveWords(candidateWords, wordlistfile);

	    return 0;
	}

	private static char[] worddelimeters = new char[] {
	    '\r', '\n', ' ', '\t', '/', '"', '-', '’', '”', '“', '.', ',', '?', ';', '!', ':', '(', ')', '„', '”', '…', '[', ']', '»', '«'
	    };
	private static Regex valid = new Regex("^[a-z]+$");

	private static HashSet<string> filterWords(string content)
	{
	    HashSet<string> wordlist = new HashSet<string>();

	    string[] words = content.Split(
		worddelimeters,
		StringSplitOptions.RemoveEmptyEntries);

	    foreach(string word in words) {
		if(valid.IsMatch(word) && word.Length > 2 && !wordlist.Contains(word))
		{
		    wordlist.Add(word);
		}
	    }

	    return wordlist;

	}

	private static void saveWords(HashSet<string> wordlist, string wordlistfile)
	{
	    string previousWord = string.Empty;
	    int counter = 0;

	    using (StreamWriter writer = new StreamWriter(
		  File.Open(wordlistfile, FileMode.Create),
		  Encoding.ASCII))
	    {

		    foreach(string word in wordlist.OrderBy(s => s)) {
			previousWord = word;
			PrintDicewareBase6(writer, counter++);
			writer.WriteLine(word);
		    }
	    }
	}

	public static void PrintDicewareBase6(StreamWriter writer, int number)
	{
		int remains = number;
		Stack<byte> digits = new Stack<byte>();
		while(remains > 0)
		{
			byte digit = (byte)(remains % 6);
			digits.Push(digit);
			remains = remains / 6;
		}

		while (digits.Count < 5)
		{
			digits.Push(0);
		}

		while(digits.Count > 0)
		{
			byte digit = digits.Pop();
			writer.Write(digit + 1);
		}
		writer.Write("\t");
	}
    }
}
