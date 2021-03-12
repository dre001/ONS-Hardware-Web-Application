using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ONS_Hardware_Web_Application.Contracts;
using ONS_Hardware_Web_Application.Data;
using ONS_Hardware_Web_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application.Controllers
{
    [Authorize (Roles = "Administrator")] // Only the admistrator will have access to this information
    public class ParishesController : Controller
    {
        private readonly IParishRepository _repo;
        private readonly IMapper _mapper;

        public ParishesController(IParishRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }
        // GET: ParishesController
        public ActionResult Index()
        {
            var parishes = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Parish>, List<ParishViewModel>>(parishes);
            return View(model);

        }

        // View For list of Parishes



        // GET: ParishesController/Details/5
        public ActionResult Details(int id)
        {

            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var parish = _repo.FindById(id);
            var model = _mapper.Map<ParishViewModel>(parish);
            return View(model);
        }

        // GET: ParishesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParishesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ParishViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var parish = _mapper.Map<Parish>(model);
               

                var IsSuccess = _repo.Create(parish);
                if (!IsSuccess)
                {
                    ModelState.AddModelError("", "Sorry, Something went wrong...");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Sorry, Something went wrong...");
                return View();
            }
        }

        // GET: ParishesController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var parish = _repo.FindById(id);
            var model = _mapper.Map<ParishViewModel>(parish);
            return View(model);
        }

        // POST: ParishesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ParishViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var parish = _mapper.Map<Parish>(model);
                var IsSuccess = _repo.Update(parish);
                if (!IsSuccess)
                {
                    ModelState.AddModelError("", "Sorry, Something went wrong...");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Sorry, Something went wrong...");
                return View(model);
            }
        }

        // GET: ParishesController/Delete/5
        public ActionResult Delete(int id)
        {
            var parish = _repo.FindById(id);
            if (parish == null)
            {
                return NotFound();
            }
            var IsSuccess = _repo.Delete(parish);
            if (!IsSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: ParishesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ParishViewModel model)
        {
            try
            {
                var parish = _repo.FindById(id);
                if (parish == null)
                {
                    return NotFound();
                }
                var IsSuccess = _repo.Delete(parish);
                if (!IsSuccess)
                {
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}
