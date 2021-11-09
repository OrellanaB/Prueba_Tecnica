using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Models
{
    public class EmpleadoHabilidadViewModel
    {
        [Display(Name = "Id_Habilidad")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int IdAbility { get; set; }

        [Display(Name = "Empleado")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int IdEmployee { get; set; }

        [Display(Name = "Nombre de Habilidad")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string SkillName { get; set; }

        public EmpleadoViewModel Empleado { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
