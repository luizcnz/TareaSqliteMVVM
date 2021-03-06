using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareaSqliteMVVM.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaSqliteMVVM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new CreateViewModel(this);
        }
    }
}
