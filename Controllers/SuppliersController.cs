using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ONS_Hardware_Web_Application.Contracts;
using ONS_Hardware_Web_Application.Data;
using ONS_Hardware_Web_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application.Controllers
{
    [Authorize] // this ensure that a user has to sign in before having access to the information that will be populated
    public class SuppliersController : Controller
    {
        private readonly ISupplierRepository _repo;
        private readonly IParishRepository _parishRepo;
        private readonly IMapper _mapper;
        
        private readonly UserManager<Employee> _userManager;
        public SuppliersController(ISupplierRepository repo, 
            IParishRepository parishRepo, 
            IMapper mapper, 
            UserManager<Employee> userManager)
        {
            _repo = repo;
            _parishRepo = parishRepo;
            _mapper = mapper;
            _userManager = userManager; 
    }

        // GET: SupplierController
        public ActionResult Index()
        {
            var suppliers = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Supplier>, List<SupplierViewModel>>(suppliers);
            return View(model);
           
        }


        ////View for List of parishes
        //public ActionResult ListParishes()
        //{
        //    var parishes = _userManager.GetUsersInRoleAsync("Parish").Result;
        //    var model = _mapper.Map<List<ParishViewModel>>(parishes);
        //    return View(model);
        //}
        // GET: SupplierController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var supplier = _repo.FindById(id);
            var model = _mapper.Map<SupplierViewModel>(supplier);
            return View(model);
        }

        // GET: SupplierController/Create
        public ActionResult Create()
        {
            var parishes = _parishRepo.FindAll()
                .Select(q => new SelectListItem { Text = q.Parishes, Value= q.Id.ToString() });
            var model = new SupplierViewModel
            { 
                Parishes = parishes
            };
            return View(model);
        }

        // POST: SupplierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SupplierViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var supplier = _mapper.Map<Supplier>(model);
                //supplier.D

                var IsSuccess = _repo.Create(supplier);
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

        // GET: SupplierController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var supplier = _repo.FindById(id);
            var model = _mapper.Map<SupplierViewModel>(supplier);
            return View(model);
        }

        // POST: SupplierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SupplierViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var supplier = _mapper.Map<Supplier>(model);
                var IsSuccess = _repo.Update(supplier);
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

        // GET: SupplierController/Delete/5
        public ActionResult Delete(int id)
        {
            var supplier = _repo.FindById(id);
            if (supplier == null)
            {
                return NotFound();
            }
            var IsSuccess = _repo.Delete(supplier);
            if (!IsSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: SupplierController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SupplierViewModel model)
        {
            try
            {
                var supplier = _repo.FindById(id);
                if (supplier == null)
                {
                    return NotFound();
                }
                var IsSuccess = _repo.Delete(supplier);
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
