using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using XrnCourse.MvvmBasics.Constants;
using XrnCourse.MvvmBasics.Domain.Models;
using XrnCourse.MvvmBasics.Domain.Services;
using XrnCourse.MvvmBasics.Views;

namespace XrnCourse.MvvmBasics.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IClassmateRepository _classmateRepositoy;
        private ISeederService _seederService;
        private INavigation _navigation;

        public MainViewModel(
            IClassmateRepository classmateRepository,
            ISeederService seederService,
            INavigation navigation)
        {
            _navigation = navigation;
            _classmateRepositoy = classmateRepository;
            _seederService = seederService;

            //subscribe to ClassmateSaved message
            MessagingCenter.Subscribe(this, MessageNames.ClassmateSaved,
                (ClassmateViewModel sender, Classmate classmate) => {
                    //refresh classmates listview each time an update occurs
                    RefreshCommand.Execute(null);
                });

        }

        ~MainViewModel()
        {
            //this is completely unnecessary, just showing how to use the Unsubscribe method!
            MessagingCenter.Unsubscribe<ClassmateViewModel, Classmate>(this, MessageNames.ClassmateSaved);
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

        public ICommand RefreshCommand => new Command(
            async () => {
                //create sample data when datastore doesn't exist
                _seederService.EnsureSeeded(); 
                //get unsorted data from file
                Classmates = new ObservableCollection<Classmate>(await _classmateRepositoy.GetAll()); 
            });

        public ICommand SortCommand => new Command(
            async () => {
                //refresh the list and sort data by Name
                var sortedMates = (await _classmateRepositoy.GetAll()).OrderBy(e => e.Name).ToList();
                //reset the collection
                Classmates = new ObservableCollection<Classmate>(sortedMates);
            });

        public ICommand ViewClassmateCommand => new Command<Classmate>(
            async (Classmate classmate) => {
                await _navigation.PushAsync(new ClassmateView(classmate));
            });

    }
}
