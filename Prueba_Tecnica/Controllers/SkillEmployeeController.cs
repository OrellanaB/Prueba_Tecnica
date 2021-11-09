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
    public class SkillEmployeeController : Controller
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;
        private readonly IEmployeeRepository employeeRepository;
        private readonly ISkillEmployeeRepository skillEmployeeRepository;
        private GeneralViewModel gvm;

        public SkillEmployeeController(ILogger logger, IConfiguration configuration, IEmployeeRepository employeeRepository, ISkillEmployeeRepository skillEmployeeRepository)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.employeeRepository = employeeRepository;
            this.skillEmployeeRepository = skillEmployeeRepository;
        }
        // GET: Employee
        [Authorize]
        public ActionResult Index()
        {
            gvm = skillEmployeeRepository.GetAll();
            if (TempData["State"] != null)
            {
                ViewBag.Result = new ResultViewModel { Message = TempData["Message"].ToString(), Detail = TempData["Detail"].ToString(), State = bool.Parse(TempData["State"].ToString()) };
            }
            return View(gvm.arrayListData.Cast<EmpleadoHabilidadViewModel>().ToList());
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
            gvm = skillEmployeeRepository.GetAll();
            ViewBag.SkillEmployee = gvm.arrayListData.Cast<EmpleadoHabilidadViewModel>().ToList();

            gvm = employeeRepository.GetAll();
            ViewBag.empleado = gvm.arrayListData.Cast<EmpleadoViewModel>().ToList();
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpleadoHabilidadViewModel data)
        {
            try
            {
                gvm = skillEmployeeRepository.Create(data);
                if (gvm.msg == null)
                {
                    this.logger.LogInformation("Create ({data})", data);
                    TempData.Add("Message", "Exito");
                    TempData.Add("Detail", "Habilidad de empleado creada");
                    TempData.Add("State", "true");
                }
                else
                {
                    logger.LogError(LogEvents.EmpleadoHabilidadController.Id, "Create ({data})" + gvm.msg.ErrorMessage, data);
                    TempData.Add("Message", "Error");
                    TempData.Add("Detail", "La habilidad de empleado no pudo ser creado.");
                    TempData.Add("State", "false");
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(LogEvents.EmpleadoHabilidadController.Id, ex, "Create ({data})", data);
                TempData.Add("Message", "Error");
                TempData.Add("Detail", (!bool.Parse(configuration["Debug"]) ? "La habilidad de empleado no pudo ser creado." : ex.Message));
                TempData.Add("State", "false");
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Employee/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            gvm = skillEmployeeRepository.GetById(id);
            EmpleadoHabilidadViewModel skill = gvm.arrayListData.Cast<EmpleadoHabilidadViewModel>().ToList().ElementAt(0);

            gvm = employeeRepository.GetAll();
            ViewBag.Employee = gvm.arrayListData.Cast<EmpleadoHabilidadViewModel>().ToList().Where(r => r.IdEmployee == skill.IdEmployee);

            gvm = skillEmployeeRepository.GetAll();
            ViewBag.Skill = gvm.arrayListData.Cast<EmpleadoHabilidadViewModel>().ToList().Where(r => r.IdAbility == skill.IdAbility);
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, EmpleadoHabilidadViewModel data)
        {
            try
            {
                gvm = skillEmployeeRepository.Update(data);
                if (gvm.msg == null)
                {
                    this.logger.LogInformation("Edit ({data})", data);
                    TempData.Add("Message", "Exito");
                    TempData.Add("Detail", "La habilidad de empleado modificada");
                    TempData.Add("State", "true");
                }
                else
                {
                    logger.LogError(LogEvents.EmpleadoHabilidadController.Id, "Edit ({data})" + gvm.msg.ErrorMessage, data);
                    TempData.Add("Message", "Error");
                    TempData.Add("Detail", (!bool.Parse(configuration["Debug"]) ? "La habilidad de empleado no pudo ser modificado" : gvm.msg.ErrorMessage));
                    TempData.Add("State", "false");
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(LogEvents.EmpleadoHabilidadController.Id, ex, "Edit ({data})", data);
                TempData.Add("Message", "Error");
                TempData.Add("Detail", (!bool.Parse(configuration["Debug"]) ? "La habilidad de empleado no pudo ser modificado" : ex.Message));
                TempData.Add("State", "false");
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Area/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            gvm = skillEmployeeRepository.GetById(id);
            EmpleadoHabilidadViewModel skill = gvm.arrayListData.Cast<EmpleadoHabilidadViewModel>().ToList().ElementAt(0);

            gvm = employeeRepository.GetAll();
            ViewBag.Employee = gvm.arrayListData.Cast<EmpleadoHabilidadViewModel>().ToList().Where(r => r.IdEmployee == skill.IdEmployee);

            gvm = skillEmployeeRepository.GetAll();
            ViewBag.Skill = gvm.arrayListData.Cast<EmpleadoHabilidadViewModel>().ToList().Where(r => r.IdAbility == skill.IdAbility);
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
                gvm = skillEmployeeRepository.Delete(id);
                if (gvm.msg == null)
                {
                    this.logger.LogInformation("Delete ({id})", id);
                    TempData.Add("Message", "Exito");
                    TempData.Add("Detail", "La habilidad de empleado eliminada");
                    TempData.Add("State", "true");
                }
                else
                {
                    logger.LogError(LogEvents.EmpleadoHabilidadController.Id, "Delete ({id})" + gvm.msg.ErrorMessage, id);
                    TempData.Add("Message", "Error");
                    TempData.Add("Detail", (!bool.Parse(configuration["Debug"]) ? "La habilidad de empleado no pudo ser eliminado" : gvm.msg.ErrorMessage));
                    TempData.Add("State", "false");
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(LogEvents.EmpleadoHabilidadController.Id, ex, "Delete ({id})", id);
                TempData.Add("Message", "Error");
                TempData.Add("Detail", (!bool.Parse(configuration["Debug"]) ? "La habilidad de empleado no pudo ser eliminado" : ex.Message));
                TempData.Add("State", "false");
                return RedirectToAction(nameof(Index));
            }
        }
    }
}