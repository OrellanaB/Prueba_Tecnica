using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica
{
    public class LogEvents
    {
        public static EventId RunStoreProcedure = new EventId(1000, "RunStoreProcedure");
        public static EventId AreaController = new EventId(1001, "AreaController");
        public static EventId EmpleadoController = new EventId(1002, "EmpleadoController");
        public static EventId EmpleadoHabilidadController = new EventId(1003, "EmpleadoHabilidadController");
    }
}
