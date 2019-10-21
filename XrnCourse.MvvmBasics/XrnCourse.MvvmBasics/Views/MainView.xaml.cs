using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XrnCourse.MvvmBasics.ViewModels;

namespace XrnCourse.MvvmBasics.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(this.Navigation);
        }
        protected override void OnAppearing()
        {
            //execut the RefreshCommand which lives on the MainViewModel
            (BindingContext as MainViewModel)?.RefreshCommand?.Execute(null);
            base.OnAppearing();
        }

    }
}