using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Prueba_Tecnica.Models;
using Prueba_Tecnica.Repositories.Interfaces;

namespace Prueba_Tecnica.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IAreaRepository areaRepository;
        private GeneralViewModel gvm;

        public EmployeeController(ILogger logger, IConfiguration configuration, IEmployeeRepository employeeRepository, IAreaRepository areaRepository)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.employeeRepository = employeeRepository;
            this.areaRepository = areaRepository;
        }
        // GET: Employee
        [Authorize]
        public ActionResult Index()
        {
            gvm = employeeRepository.GetAll();
            if (TempData["State"] != null)
            {
                ViewBag.Result = new ResultViewModel { Message = TempData["Message"].ToString(), Detail = TempData["Detail"].ToString(), State = bool.Parse(TempData["State"].ToString()) };
            }
            return View(gvm.arrayListData.Cast<EmpleadoViewModel>().ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        [Authorize]
        public ActionResult Create()
        {
            gvm = employeeRepository.GetAll();
            ViewBag.Employee = gvm.arrayListData.Cast<AreaViewModel>().ToList();

            gvm = areaRepository.GetAll();
            ViewBag.Area = gvm.arrayListData.Cast<AreaViewModel>().ToList();
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpleadoViewModel data)
        {
            try
            {
                gvm = employeeRepository.Create(data);
                if (gvm.msg == null)
                {
                    this.logger.LogInformation("Create ({data})", data);
                    TempData.Add("Message", "Exito");
                    TempData.Add("Detail", "Empleado creado");
                    TempData.Add("State", "true");
                }
                else
                {
                    logger.LogError(LogEvents.EmpleadoController.Id, "Create ({data})" + gvm.msg.ErrorMessage, data);
                    TempData.Add("Message", "Error");
                    TempData.Add("Detail", "El empleado no pudo ser creado.");
                    TempData.Add("State", "false");
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(LogEvents.EmpleadoController.Id, ex, "Create ({data})", data);
                TempData.Add("Message", "Error");
                TempData.Add("Detail", (!bool.Parse(configuration["Debug"]) ? "El empleado no pudo ser creado" : ex.Message));
                TempData.Add("State", "false");
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Employee/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            gvm = employeeRepository.GetById(id);
            EmpleadoViewModel empleado = gvm.arrayListData.Cast<EmpleadoViewModel>().ToList().ElementAt(0);

            gvm = employeeRepository.GetAll();
            ViewBag.Employee = gvm.arrayListData.Cast<EmpleadoViewModel>().ToList().Where(r => r.IdEmployee == empleado.IdEmployee);

            gvm = areaRepository.GetAll();
            ViewBag.Area = gvm.arrayListData.Cast<EmpleadoViewModel>().ToList().Where(r => r.IdArea == empleado.IdArea);
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, EmpleadoViewModel data)
        {
            try
            {
                gvm = employeeRepository.Update(data);
                if (gvm.msg == null)
                {
                    this.logger.LogInformation("Edit ({data})", data);
                    TempData.Add("Message", "Exito");
                    TempData.Add("Detail", "Empleado creado");
                    TempData.Add("State", "true");
                }
                else
                {
                    logger.LogError(LogEvents.EmpleadoController.Id, "Edit ({data})" + gvm.msg.ErrorMessage, data);
                    TempData.Add("Message", "Error");
                    TempData.Add("Detail", (!bool.Parse(configuration["Debug"]) ? "El empleado no pudo ser modificado" : gvm.msg.ErrorMessage));
                    TempData.Add("State", "false");
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(LogEvents.EmpleadoController.Id, ex, "Edit ({data})", data);
                TempData.Add("Message", "Error");
                TempData.Add("Detail", (!bool.Parse(configuration["Debug"]) ? "El empleado no pudo ser modificado" : ex.Message));
                TempData.Add("State", "false");
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Area/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            gvm = employeeRepository.GetById(id);
            EmpleadoViewModel empleado = gvm.arrayListData.Cast<EmpleadoViewModel>().ToList().ElementAt(0);

            gvm = employeeRepository.GetAll();
            ViewBag.Employee = gvm.arrayListData.Cast<EmpleadoViewModel>().ToList().Where(r => r.IdEmployee == empleado.IdEmployee);

            gvm = areaRepository.GetAll();
            ViewBag.Area = gvm.arrayListData.Cast<AreaViewModel>().ToList().Where(r => r.IdArea == empleado.IdArea);
            return View();
        }

        // POST: Area/Delete/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                gvm = areaRepository.Delete(id);
                if (gvm.msg == null)
                {
                    this.logger.LogInformation("Delete ({id})", id);
                    TempData.Add("Message", "Exito");
                    TempData.Add("Detail", "Empleado Eliminado");
                    TempData.Add("State", "true");
                }
                else
                {
                    logger.LogError(LogEvents.EmpleadoController.Id, "Delete ({id})" + gvm.msg.ErrorMessage, id);
                    TempData.Add("Message", "Error");
                    TempData.Add("Detail", (!bool.Parse(configuration["Debug"]) ? "El empleado no pudo ser eliminado" : gvm.msg.ErrorMessage));
                    TempData.Add("State", "false");
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(LogEvents.EmpleadoController.Id, ex, "Delete ({id})", id);
                TempData.Add("Message", "Error");
                TempData.Add("Detail", (!bool.Parse(configuration["Debug"]) ? "El empleado no pudo ser eliminado" : ex.Message));
                TempData.Add("State", "false");
                return RedirectToAction(nameof(Index));
            }
        }
    }
}