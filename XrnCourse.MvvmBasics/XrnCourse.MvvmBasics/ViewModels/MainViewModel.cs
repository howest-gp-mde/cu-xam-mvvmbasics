using System.Collections.ObjectModel;
using System.ComponentModel;
using XrnCourse.MvvmBasics.Domain.Models;

namespace XrnCourse.MvvmBasics.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Classmate> classmates;
        public ObservableCollection<Classmate> Classmates
        {
            get { return classmates; }
            set
            {
                classmates = value;
                RaisePropertyChanged(nameof(Classmates));
            }
        }

        /// <summary>
        /// Raises the PropertyChanged event if it has handlers attached to it
        /// </summary>
        /// <param name="propertyName">name of the prop that was changed</param>
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
