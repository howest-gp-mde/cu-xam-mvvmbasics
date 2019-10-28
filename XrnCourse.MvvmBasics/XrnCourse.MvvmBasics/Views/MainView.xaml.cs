using Autofac;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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

            //resolve the view model (enabling automatic DI for its ctor)
            //note that we now pass the navigation parameter to the Resolve method
            var viewModel = IocRegistry.Container
                .Resolve<MainViewModel>(TypedParameter.From(this.Navigation));

            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            //execut the RefreshCommand which lives on the MainViewModel
            (BindingContext as MainViewModel)?.RefreshCommand?.Execute(null);
            base.OnAppearing();
        }

    }
}