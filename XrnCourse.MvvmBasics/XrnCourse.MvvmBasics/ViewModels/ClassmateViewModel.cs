using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using XrnCourse.MvvmBasics.Constants;
using XrnCourse.MvvmBasics.Domain.Models;
using XrnCourse.MvvmBasics.Domain.Services;

namespace XrnCourse.MvvmBasics.ViewModels
{
    public class ClassmateViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IClassmateRepository _classmateRepositoy;
        private ISeederService _seederService;
        private INavigation _navigation;
        private Classmate _currentClassmate; // holds classmate being edited

        public ClassmateViewModel(Classmate classmate, INavigation navigation)
        {
            _navigation = navigation;
            _currentClassmate = classmate;

            //todo: inject this dependencies instead of
            //      instantiating a concrete implementation.
            _classmateRepositoy = new JsonClassmateRepository();
            _seederService = new SeedDataStoreService(_classmateRepositoy);

            //todo: DO NOT call async or long-running operations in the
            //      constructor, move this to a command
            _seederService.EnsureSeeded();
            
            //initialize the properties with data from domain model
            this.Name = _currentClassmate.Name;
            this.Phone = _currentClassmate.Phone;
            this.Birthdate = _currentClassmate.Birthdate;
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }
        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                RaisePropertyChanged(nameof(Phone));
            }
        }
        private DateTime birthdate;
        public DateTime Birthdate
        {
            get { return birthdate; }
            set
            {
                birthdate = value;
                RaisePropertyChanged(nameof(Birthdate));
                RaisePropertyChanged(nameof(Age));
            }
        }
        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - birthdate.Year;
                if (birthdate > DateTime.Now.AddYears(-age)) age--; //adjust for leap year
                return age;
            }
        }

        public ICommand SaveCommand => new Command(
            async () =>
            {
                _currentClassmate.Name = Name;
                _currentClassmate.Phone = Phone;
                _currentClassmate.Birthdate = Birthdate;
                await _classmateRepositoy.UpdateClassmate(_currentClassmate);
                //publish message
                MessagingCenter.Send<ClassmateViewModel, Classmate>(this,
                    MessageNames.ClassmateSaved, _currentClassmate);
            });


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
