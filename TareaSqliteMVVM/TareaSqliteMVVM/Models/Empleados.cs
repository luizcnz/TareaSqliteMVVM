using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TareaSqliteMVVM.Models
{
    public class Empleados
    {
        [PrimaryKey, AutoIncrement]
        public int idEmpleado { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Apellido { get; set; }


        public int Edad { get; set; }

        [MaxLength(100)]
        public string Direccion { get; set; }

        [MaxLength(50)]
        public string Puesto { get; set; }


    }
}
