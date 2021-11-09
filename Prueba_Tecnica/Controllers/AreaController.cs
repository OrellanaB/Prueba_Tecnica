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
    public class AreaController : Controller
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;
        private readonly IAreaRepository areaRepository;
        private GeneralViewModel gvm;

        public AreaController(ILogger logger, IConfiguration configuration, IAreaRepository areaRepository)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.areaRepository = areaRepository;
        }

        // GET: Area
        [Authorize]
        public ActionResult Index()
        {
            gvm = areaRepository.GetAll();
            if (TempData["State"] != null)
            {
                ViewBag.Result = new ResultViewModel { Message = TempData["Message"].ToString(), Detail = TempData["Detail"].ToString(), State = bool.Parse(TempData["State"].ToString()) };
            }
            return View(gvm.arrayListData.Cast<AreaViewModel>().ToList());
        }

        // GET: Area/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Area/Create
        [Authorize]
        public ActionResult Create()
        {
            gvm = areaRepository.GetAll();
            ViewBag.Area = gvm.arrayListData.Cast<AreaViewModel>().ToList();
            return View();
        }

        // POST: Area/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AreaViewModel data)
        {
            try
            {
                gvm = areaRepository.Create(data);
                if (gvm.msg == null)
                {
                    this.logger.LogInformation("Create ({data})", data);
                    TempData.Add("Message", "Exito");
                    TempData.Add("Detail", "Area creada");
                    TempData.Add("State", "true");
                }
                else
                {
                    logger.LogError(LogEvents.AreaController.Id, "Create ({data})" + gvm.msg.ErrorMessage, data);
                    TempData.Add("Message", "Error");
                    TempData.Add("Detail", "La area no pudo ser creada.");
                    TempData.Add("State", "false");
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                logger.LogError(LogEvents.AreaController.Id, ex, "Create ({data})", data);
                TempData.Add("Message", "Error");
                TempData.Add("Detail", (!bool.Parse(configuration["Debug"]) ? "La area no pudo ser creada" : ex.Message));
                TempData.Add("State", "false");
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Area/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            gvm = areaRepository.GetById(id);
            AreaViewModel area = gvm.arrayListData.Cast<AreaViewModel>().ToList().ElementAt(0);

            gvm = areaRepository.GetAll();
            ViewBag.Area = gvm.arrayListData.Cast<AreaViewModel>().ToList().Where(r => r.IdArea == area.IdArea); 
            return View();
        }

        // POST: Area/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, AreaViewModel data)
        {
            try
            {
                gvm = areaRepository.Update(data);
                if (gvm.msg == null)
                {
                    this.logger.LogInformation("Create ({data})", data);
                    TempData.Add("Message", "Exito");
                    TempData.Add("Detail", "Area creada");
                    TempData.Add("State", "true");
                }
                else
                {
                    logger.LogError(LogEvents.AreaController.Id, "Edit ({data})" + gvm.msg.ErrorMessage, data);
                    TempData.Add("Message", "Error");
                    TempData.Add("Detail", (!bool.Parse(configuration["Debug"]) ? "La area no pudo ser modificada": gvm.msg.ErrorMessage));
                    TempData.Add("State", "false");
                }

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                logger.LogError(LogEvents.AreaController.Id,ex, "Edit ({data})", data);
                TempData.Add("Message", "Error");
                TempData.Add("Detail", (!bool.Parse(configuration["Debug"]) ? "La area no pudo ser modificada" : ex.Message));
                TempData.Add("State", "false");
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Area/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            gvm = areaRepository.GetById(id);
            AreaViewModel area = gvm.arrayListData.Cast<AreaViewModel>().ToList().ElementAt(0);

            gvm = areaRepository.GetAll();
            ViewBag.Area = gvm.arrayListData.Cast<AreaViewModel>().ToList().Where(r => r.IdArea == area.IdArea);
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
                    TempData.Add("Detail", "Area Eliminada");
                    TempData.Add("State", "true");
                }
                else
                {
                    logger.LogError(LogEvents.AreaController.Id, "Delete ({id})" + gvm.msg.ErrorMessage, id);
                    TempData.Add("Message", "Error");
                    TempData.Add("Detail", (!bool.Parse(configuration["Debug"]) ? "La area no pudo ser eliminada" : gvm.msg.ErrorMessage));
                    TempData.Add("State", "false");
                }

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                logger.LogError(LogEvents.AreaController.Id, ex, "Delete ({id})", id);
                TempData.Add("Message", "Error");
                TempData.Add("Detail", (!bool.Parse(configuration["Debug"]) ? "La area no pudo ser eliminado" : ex.Message));
                TempData.Add("State", "false");
                return RedirectToAction(nameof(Index));
            }
        }
    }
}