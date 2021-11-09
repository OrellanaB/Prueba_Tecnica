using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Models
{
    public class ResultViewModel
    {
        public bool State { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
