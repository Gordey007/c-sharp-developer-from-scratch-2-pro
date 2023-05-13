using System.Windows;

namespace Homework_Theme_09
{
    public partial class MainWindow : Window
    {
        private readonly Utils utils;

        public MainWindow()
        {
            utils = new Utils();
            InitializeComponent();
        }

        private void BtnSplitSentenceClick(object sender, RoutedEventArgs e)
        {
            listOutput.ItemsSource = utils.SplitSentence(txtInput.Text);
        }

        private void BtnReverseWordsClick(object sender, RoutedEventArgs e)
        {
            Reverse reverseStr = (Reverse)this.Resources["reverseStrDefault"];
            reverseStr.ReverseStr = utils.ReverseWords(txtInput.Text);
        }
    }
}