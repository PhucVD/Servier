using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Servier.Data;
using System.Net;
using Servier.Repository;

namespace Servier.Controllers
{
    public class RegionController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Region
        public ActionResult Index()
        {
            var regions = unitOfWork.RegionRepository.GetAll();
            return View(regions);
        }

        // GET: Region/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Region region = unitOfWork.RegionRepository.GetById(id.Value);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        // GET: Region/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Region/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegionID,RegionName,Note,Rank")] Region region)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.RegionRepository.Insert(region);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Error: " + ex.Message);
            }
            return View(region);
        }

        // GET: Region/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = unitOfWork.RegionRepository.GetById(id.Value);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        // POST: Region/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Region region)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.RegionRepository.Update(region);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Error: " + ex.Message);
            }
            return View(region);
        }

        // GET: Region/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Region region = unitOfWork.RegionRepository.GetById(id.Value);
            if (region == null)
            {
                return HttpNotFound();
            }

            return View(region);
        }

        // POST: Region/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                Region region = unitOfWork.RegionRepository.GetById(id);
                unitOfWork.RegionRepository.Delete(region);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Error: " + ex.Message);
            }

            return RedirectToAction("Delete", new { id = id });
        }
    }
}
