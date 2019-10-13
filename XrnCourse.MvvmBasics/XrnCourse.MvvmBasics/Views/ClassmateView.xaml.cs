using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XrnCourse.MvvmBasics.ViewModels;

namespace XrnCourse.MvvmBasics.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClassmateView : ContentPage
    {
        public ClassmateView()
        {
            InitializeComponent();
            BindingContext = new ClassmateViewModel();
        }
    }
}