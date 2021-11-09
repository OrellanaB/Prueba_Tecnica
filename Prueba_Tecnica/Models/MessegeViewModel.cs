using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Models
{
    public class MessegeViewModel
    {
        public string NumberError { get; set; }
        public string ErrorSeverity { get; set; }
        public string ErrorState { get; set; }
        public string ErrorProcedure { get; set; }
        public string ErrorLine { get; set; }
        public string ErrorMessage { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
