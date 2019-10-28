using Autofac;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XrnCourse.MvvmBasics.Domain.Models;
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

            //resolve the view model (enabling automatic DI for its ctor)
            //note that we now pass the Classmate parameter to th Resolve method
            var viewModel = IocRegistry.Container
                .Resolve<ClassmateViewModel>(TypedParameter.From(classmate));

            BindingContext = viewModel;
        }
    }
}