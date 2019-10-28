using Autofac;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XrnCourse.MvvmBasics.Domain.Services;
using XrnCourse.MvvmBasics.IoC;
using XrnCourse.MvvmBasics.ViewModels;

namespace XrnCourse.MvvmBasics.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();

            //resolve dependencies from the container
            //todo: using automatic constructor injection instead!
            IClassmateRepository classmateRepository = IocRegistry.Container
                .Resolve<IClassmateRepository>();

            ISeederService seederService = IocRegistry.Container
                .Resolve<ISeederService>(TypedParameter.From(classmateRepository));
            
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