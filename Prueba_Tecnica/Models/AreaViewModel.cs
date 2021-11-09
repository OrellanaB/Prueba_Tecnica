using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Models
{
    public class AreaViewModel
    {
        [Display(Name = "Id_Area")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int IdArea { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Name { get; set; }

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Description { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
