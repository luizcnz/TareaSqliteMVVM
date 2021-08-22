using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TareaSqliteMVVM.Models;
using Xamarin.Forms;

namespace TareaSqliteMVVM.ViewModels
{
    class ModViewModel : BaseViewModel
    {
        public Command ListaCommand { get; }
        public Command ActCommand { get; }
        public Command EnviarCommand { get; }


        Page Page;

        List<Empleados> listaempleados;
        Empleados listaselected;

        int id;
        string nombre;
        string apellido;
        int edad;
        string direccion;
        string puesto;

        public Empleados ListaSelected
        {
            get => listaselected;
            set { SetProperty(ref listaselected, value); fillEntrys(); }
        }

        public List<Empleados> ListaEmpleados
        {
            get => listaempleados;
            set { SetProperty(ref listaempleados, value); }
        }

        public int ID
        {
            get => id;
            set { SetProperty(ref id, value); }
        }

        public string Nombre
        {
            get => nombre;
            set { SetProperty(ref nombre, value); }
        }

        public string Apellido
        {
            get => apellido;
            set { SetProperty(ref apellido, value); }
        }

        public int Edad
        {
            get => edad;
            set { SetProperty(ref edad, value); }
        }

        public string Direccion
        {
            get => direccion;
            set { SetProperty(ref direccion, value); }
        }
        public string Puesto
        {
            get => puesto;
            set { SetProperty(ref puesto, value); }
        }


        public ModViewModel(Page pag)
        {
            Page = pag;

            //PuestoSelected = new Puestos();

            Cargar();

            EnviarCommand = new Command(OnSaveClicked);
        }

        private async Task Cargar()
        {
            //Cargo = Puestos.ObtenerCargos().OrderBy(c => c.value).ToList();

            SQLiteConnection conexion = new SQLiteConnection(App.EmpleadosDB);
            conexion.CreateTable<Empleados>();
            ListaEmpleados = conexion.Table<Empleados>().ToList();

        }

        private async void fillEntrys()
        {
            Nombre = listaselected.Nombre;
            Apellido = listaselected.Apellido;
            Edad = listaselected.Edad;
            Direccion = listaselected.Direccion;
            Puesto = listaselected.Puesto;

        }

        public async void OnSaveClicked(object obj)
        {

            if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Apellido) || Edad == 0 || string.IsNullOrEmpty(Direccion) || string.IsNullOrEmpty(Puesto))
            {
                await Page.DisplayAlert("Alerta", "Debe llenar todos los campos", "Ok");
            }
            else
            {
                await Page.DisplayAlert("Mensaje", "Los Datos se han capturado", "Ok");

                Int32 resultado = 0;
                

                if (listaselected != null)
                {
                    string x = Convert.ToString(listaselected.idEmpleado);

                    try
                    {
                        SQLiteConnection conexion = new SQLiteConnection(App.EmpleadosDB);
                        var borrarpersonas = conexion.Query<Empleados>($"UPDATE Empleados SET Nombre = '" + Nombre + "', Apellido = '" + Apellido + "', Edad = '" + Edad + "', Direccion = '" + Direccion + "', Puesto = '" + Puesto + "' WHERE idEmpleado= '" + x + "' ");
                        conexion.Close();

                        await Page.DisplayAlert("Aviso", "Modificacion Exitosa" , "Ok");
                    
                        await Page.Navigation.PushAsync(new MainPage());
                    }
                    catch(Exception e)
                    {
                        await Page.DisplayAlert("Aviso", "Error: "+e, "Ok"); 
                    }



                }
                else
                {
                    Page.DisplayAlert("Aviso", "No ha seleccionado ningun elemento para Modificar!", "Ok");


                }

            }

        }

       
    }
}
