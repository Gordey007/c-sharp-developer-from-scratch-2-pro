using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework_Theme_09
{
    internal class Utils
    {
        public Utils() { }

        public List<string> SplitSentence(string sentence)
        {
            return sentence.Split(' ').ToList();
        }

        public string ReverseWords(string sentence)
        {
            return String.Join(" ", sentence.Split(' ').Reverse());
        }
    }
}