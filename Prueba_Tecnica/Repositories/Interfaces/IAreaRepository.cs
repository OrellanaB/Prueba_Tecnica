using Prueba_Tecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Repositories.Interfaces
{
    public interface IAreaRepository
    {
        GeneralViewModel GetAll();
        GeneralViewModel Create(AreaViewModel data);
        GeneralViewModel Update(AreaViewModel data);
        GeneralViewModel Delete(int id);
        GeneralViewModel GetById(int id);

    }
}
