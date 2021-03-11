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
    [Authorize]
    public class PurchasesController : Controller
    {
        private readonly IPurchaseRepository _repo;
        private readonly IMapper _mapper;

        public PurchasesController(IPurchaseRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }

        // GET: PurchaseController
        public ActionResult Index()
        {
            var purchase = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Purchase>, List<PurchaseViewModel>>(purchase);
            return View(model);

        }

        // GET: PurchasesController/Details/5
        public ActionResult Details(int id)
        {

            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var purchase = _repo.FindById(id);
            var model = _mapper.Map<PurchaseViewModel>(purchase);
            return View(model);
        }

        // GET: PurchasesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchasesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PurchaseViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var purchase = _mapper.Map<Purchase>(model);
                purchase.PurchaseDate = DateTime.Now; // To inject you own date picker

                var IsSuccess = _repo.Create(purchase);
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
                return View();
            }
        }

        // GET: PurchasesController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var purchase = _repo.FindById(id);
            var model = _mapper.Map<PurchaseViewModel>(purchase);
            return View(model);
            
        }

        // POST: PurchasesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PurchaseViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var purchase = _mapper.Map<Purchase>(model);
                var IsSuccess = _repo.Update(purchase);
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

        // GET: PurchasesController/Delete/5
        public ActionResult Delete(int id)
        {
            var purchase = _repo.FindById(id);
            if (purchase == null)
            {
                return NotFound();
            }
            var IsSuccess = _repo.Delete(purchase);
            if (!IsSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: PurchasesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PurchaseViewModel model)
        {
            try
            {
                var purchase = _repo.FindById(id);
                if (purchase == null)
                {
                    return NotFound();
                }
                var IsSuccess = _repo.Delete(purchase);
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
