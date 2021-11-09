using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Models
{
    public class EmpleadoViewModel
    {
        [Display(Name = "Id_Empleado")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int IdEmployee { get; set; }

        [Display(Name = "Nombre Completo")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string FullName { get; set; }

        [Display(Name = "Cedula")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string identification { get; set; }

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Por favor, introduce una dirección de correo electronica válida.")]
        public string Email { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> DateBirth { get; set; }

        [Display(Name = "Fecha de ingreso")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> AdmissionDate { get; set; }

        [Display(Name = "Jefe")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int IdBoss { get; set; }

        [Display(Name = "Area")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int IdArea { get; set; }

        [Display(Name = "Foto")]
        public byte Photo { get; set; }

        public AreaViewModel Area { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
