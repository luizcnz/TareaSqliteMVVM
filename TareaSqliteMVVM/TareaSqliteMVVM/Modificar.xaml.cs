using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareaSqliteMVVM.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaSqliteMVVM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Modificar : ContentPage
    {
        public Modificar()
        {
            InitializeComponent();
            BindingContext = new ModViewModel(this);
        }
    }
}