using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using static System.Net.Mime.MediaTypeNames;

namespace Homework_Theme_09
{
    internal class Utils
    {
        private readonly MainWindow mainWindow;


        public Utils(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

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
