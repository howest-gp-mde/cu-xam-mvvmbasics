using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XrnCourse.MvvmBasics.Domain.Models;
using XrnCourse.MvvmBasics.Domain.Services;
using XrnCourse.MvvmBasics.ViewModels;

namespace XrnCourse.MvvmBasics.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClassmateView : ContentPage
    {
        public ClassmateView(Classmate classmate)
        {
            InitializeComponent();

            //todo: move instantiation to IoC container!
            IClassmateRepository classmateRepository = new JsonClassmateRepository();
            
            BindingContext = new ClassmateViewModel(classmate, classmateRepository);
        }
    }
}