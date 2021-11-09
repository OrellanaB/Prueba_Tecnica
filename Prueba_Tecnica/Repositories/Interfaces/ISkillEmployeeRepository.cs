using Prueba_Tecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Repositories.Interfaces
{
    public interface ISkillEmployeeRepository
    {
        GeneralViewModel GetAll();
        GeneralViewModel Create(EmpleadoHabilidadViewModel data);
        GeneralViewModel Update(EmpleadoHabilidadViewModel data);
        GeneralViewModel Delete(int id);
        GeneralViewModel GetById(int id);
    }
}
