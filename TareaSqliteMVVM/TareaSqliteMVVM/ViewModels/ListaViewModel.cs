using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TareaSqliteMVVM.Models;
using Xamarin.Forms;

namespace TareaSqliteMVVM.ViewModels
{
    class ListaViewModel : BaseViewModel
    {

        public Command BorrarCommand { get; }
        public Command UpdateCommand { get; }

        Page Page;
        List<Empleados> listaempleados;
        Empleados listaselected;
        Empleados _yourSelectedItem;

        public List<Empleados> ListaEmpleados
        {
            get => listaempleados;
            set { SetProperty(ref listaempleados, value); }
        }

        public Empleados ListaSelected
        {
            get => listaselected;
            set { SetProperty(ref listaselected, value);}
        }

        public Empleados YourSelectedItem
        {
            get
            {
                return _yourSelectedItem;
            }

            set
            {
                _yourSelectedItem = value;
                OnPropertyChanged("YourSelectedItem");
                alerta();
            }
        }

        public ListaViewModel(Page pag)
        {
            Page = pag;

            //PuestoSelected = new Puestos();

            BorrarCommand = new Command(DeleteCommand);
            UpdateCommand = new Command(ActCommand);

            SQLiteConnection conexion = new SQLiteConnection(App.EmpleadosDB);
            conexion.CreateTable<Empleados>();
            ListaEmpleados = conexion.Table<Empleados>().ToList();



        }

        private async void DeleteCommand()
        {
            
            if (_yourSelectedItem != null)
            {
                bool answer = await Page.DisplayAlert("Question?", "Seguro desea elminiar el Empleado: "+ _yourSelectedItem.Nombre + " " + _yourSelectedItem.Apellido + "?", "Si", "No");

                if (answer == true)
                {
                    string x = Convert.ToString(_yourSelectedItem.idEmpleado);
                    Page.DisplayAlert("Aviso", "" + _yourSelectedItem.Nombre + " " + _yourSelectedItem.Apellido + " ha sido eliminado de la lista de Empleados", "Ok");

                    SQLiteConnection conexion = new SQLiteConnection(App.EmpleadosDB);
                    var borrarpersonas = conexion.Query<Empleados>($"Delete FROM Empleados WHERE idEmpleado= '" + x + "' ");
                    conexion.Close();

                    await Page.Navigation.PushAsync(new MainPage());
                }
                
            }
            else
            {
                Page.DisplayAlert("Aviso", "No ha seleccionado ningun elemento para borrar!", "Ok");
            }



        }

        public async void alerta()
        {
            await Page.DisplayAlert("Aviso", "Ha seleccionado el empleado: " + _yourSelectedItem.Nombre, "Ok");
        }

        private async void ActCommand()
        {
            await Page.Navigation.PushAsync(new Modificar());

        }

    }
}
