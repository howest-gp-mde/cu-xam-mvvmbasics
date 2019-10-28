using Autofac;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XrnCourse.MvvmBasics.Domain.Models;
using XrnCourse.MvvmBasics.Domain.Services;
using XrnCourse.MvvmBasics.IoC;
using XrnCourse.MvvmBasics.ViewModels;

namespace XrnCourse.MvvmBasics.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClassmateView : ContentPage
    {
        public ClassmateView(Classmate classmate)
        {
            InitializeComponent();

            //resolve dependencies from the container
            //todo: using automatic constructor injection instead!
            IClassmateRepository classmateRepository = IocRegistry.Container
                .Resolve<IClassmateRepository>();

            BindingContext = new ClassmateViewModel(classmate, classmateRepository);
        }
    }
}