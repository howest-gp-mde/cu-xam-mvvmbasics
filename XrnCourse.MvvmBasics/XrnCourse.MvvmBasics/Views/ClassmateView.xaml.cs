using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XrnCourse.MvvmBasics.Domain.Models;
using XrnCourse.MvvmBasics.ViewModels;

namespace XrnCourse.MvvmBasics.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClassmateView : ContentPage
    {
        public ClassmateView(Classmate classmate)
        {
            InitializeComponent();
            BindingContext = new ClassmateViewModel(classmate, this.Navigation);
        }
    }
}