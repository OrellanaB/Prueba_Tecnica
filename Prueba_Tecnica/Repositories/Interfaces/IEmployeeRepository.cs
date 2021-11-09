using Prueba_Tecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        GeneralViewModel GetAll();
        GeneralViewModel Create(EmpleadoViewModel data);
        GeneralViewModel Update(EmpleadoViewModel data);
        GeneralViewModel Delete(int id);
        GeneralViewModel GetById(int id);

    }
}
