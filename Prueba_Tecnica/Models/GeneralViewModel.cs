using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Models
{
    public class GeneralViewModel
    {
        public MessegeViewModel msg { get; set; }
        public ArrayList arrayListData { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
