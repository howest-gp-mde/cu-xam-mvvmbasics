using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XrnCourse.MvvmBasics.Domain.Services;
using XrnCourse.MvvmBasics.ViewModels;

namespace XrnCourse.MvvmBasics.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();

            //todo: move instantiation to IoC container!
            IClassmateRepository classmateRepository = new JsonClassmateRepository();
            ISeederService seederService = new SeedDataStoreService(classmateRepository);

            BindingContext = new MainViewModel(classmateRepository, seederService, this.Navigation);
        }
        protected override void OnAppearing()
        {
            //execut the RefreshCommand which lives on the MainViewModel
            (BindingContext as MainViewModel)?.RefreshCommand?.Execute(null);
            base.OnAppearing();
        }

    }
}