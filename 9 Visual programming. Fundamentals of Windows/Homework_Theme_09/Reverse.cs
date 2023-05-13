using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Homework_Theme_09
{
    internal class Reverse : INotifyPropertyChanged
    {
        private string reverseStr;

        public string ReverseStr
        {
            get { return reverseStr; }
            set
            {
                reverseStr = value;
                OnPropertyChanged("ReverseStr");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}