using Prueba_Tecnica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Repositories.Interfaces
{
    public interface IGeneralRepository
    {
        MessegeViewModel GetErrorInfo(DataTable dt);
    }
}
