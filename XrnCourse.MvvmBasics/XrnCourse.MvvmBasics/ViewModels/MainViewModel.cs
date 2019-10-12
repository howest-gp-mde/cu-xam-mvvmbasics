using System.Collections.ObjectModel;
using System.ComponentModel;
using XrnCourse.MvvmBasics.Domain.Models;
using XrnCourse.MvvmBasics.Domain.Services;

namespace XrnCourse.MvvmBasics.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IClassmateRepository _classmateRepositoy;
        private ISeederService _seederService;

        public MainViewModel()
        {
            //todo: inject these dependencies instead of
            //      instantiating a concrete implementation.
            _classmateRepositoy = new JsonClassmateRepository();
            _seederService = new SeedDataStoreService(_classmateRepositoy);

            //todo: DO NOT call async or long-running operations in the
            //      constructor, move this to a command
            _seederService.EnsureSeeded();
            Classmates = new ObservableCollection<Classmate>(_classmateRepositoy.GetAll().Result);
        }

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
