using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using DiffMatchPatch;

namespace filter
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 2 || 
                !Directory.Exists(args[0]) || 
                !Directory.Exists(args[1])) {

                Console.WriteLine("Input folder expected!" +
                    "\n\nUsage: filter [dictionary words folder] [supporting words folder]");
                return -1;
            }

            string dictionaryFolder = args[0];
            string supportingFolder = args[1];

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
            printCandidateWords(candidateWords);

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
                if(valid.IsMatch(word) && word.Length > 2 && !wordlist.Contains(word)){
                    wordlist.Add(word);
                }
            }

            return wordlist;

        }

        private static void printCandidateWords(HashSet<string> wordlist) {
            string previousWord = string.Empty;

            foreach(string word in wordlist.OrderBy(s => s)) {
                diff_match_patch dmp = new diff_match_patch();
                List<Diff> diff =
                    dmp.diff_main(previousWord, word).
                    Where(d => d.operation != Operation.EQUAL).
                    ToList();
                // Result: [(-1, "Hell"), (1, "G"), (0, "o"), (1, "odbye"), (0, " World.")]

                if(diff.Count == 1 && diff[0].text.Length == 1 ) {
//                    Console.WriteLine(previousWord + ", " + word + ": " + diff[0]);
                //    continue;
                } 

                previousWord = word;
                Console.WriteLine(word);
            }
        }
    }
}
