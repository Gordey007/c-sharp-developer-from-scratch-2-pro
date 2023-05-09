using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Homework_Theme_09
{
    public partial class MainWindow : Window
    {
        private readonly Utils utils;

        public MainWindow()
        {
            utils = new Utils(this);
            InitializeComponent();
        }

        private void BtnSplitSentenceClick(object sender, RoutedEventArgs e)
        {
            listOutput.ItemsSource = utils.SplitSentence(txtInput.Text);
        }

        private void BtnReverseWordsClick(object sender, RoutedEventArgs e)
        {
            txtOutput.Text = utils.ReverseWords(txtInput.Text);
        }
    }
}
