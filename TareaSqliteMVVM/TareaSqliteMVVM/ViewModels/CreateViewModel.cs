using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TareaSqliteMVVM.Models;
using Xamarin.Forms;

namespace TareaSqliteMVVM.ViewModels
{
    class CreateViewModel : BaseViewModel
    {
        public Command ListaCommand { get; }
        public Command EnviarCommand { get; }


        Page Page;

        int id;
        string nombre;
        string apellido;
        int edad;
        string direccion;
        string puesto;

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


        public CreateViewModel(Page pag)
        {
            Page = pag;

            //PuestoSelected = new Puestos();

            Cargar();

            EnviarCommand = new Command(OnSaveClicked);
            ListaCommand = new Command(VerListaCommand);
        }

        private async Task Cargar()
        {
            //Cargo = Puestos.ObtenerCargos().OrderBy(c => c.value).ToList();

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
                var empleado = new Empleados
                {
                    Nombre = Nombre,
                    Apellido = Apellido,
                    Edad = Edad,
                    Direccion = Direccion,
                    Puesto = Puesto
                };

                using (SQLiteConnection conexion = new SQLiteConnection(App.EmpleadosDB))
                {
                    conexion.CreateTable<Empleados>();
                    resultado = conexion.Insert(empleado);

                    if (resultado > 0)
                        Page.DisplayAlert("Aviso", "Adicionado", "Ok");
                    else
                        Page.DisplayAlert("Aviso", "Error", "Ok");
                }

            }

        }

        public async void VerListaCommand(object obj)
        {
            await Page.Navigation.PushAsync(new ListaEmpleados());
        }


        public async void UpdateClicked(object obj)
        {

            //if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Apellido) || Edad == 0 || string.IsNullOrEmpty(Direccion) || string.IsNullOrEmpty(Puesto))
            //{
            //    await Page.DisplayAlert("Mensaje", "No deben haber campos vacíos", "Ok");
            //}
            //else
            //{
            //    await Page.DisplayAlert("Mensaje", "Los Datos se han capturado", "Ok");

            //    SQLiteConnection conexion = new SQLiteConnection(App.EmpleadosDB);
            //    var update = conexion.Query<Empleados>($"Update Pagos SET Nombre = '" + Descripcion + "', Monto = '" + Monto + "', Fecha = '" + Fecha + "',Photo_recibo = '" + Photo_recibo + "', foto_ruta = '" + foto_ruta + "' WHERE id_pago = '" + ID + "'");
            //    conexion.Close();

            //    Page.DisplayAlert("Aviso", "Se ha Actualizado Con Exito", "Ok");

            //}

        }
    }
}
