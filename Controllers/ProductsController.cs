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
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ISupplierRepository _SupplierRepo;
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        public ProductsController(IProductRepository repo, ISupplierRepository SupplierRepo , IMapper mapper, UserManager<IdentityUser> userManager
            )
        {
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
            _SupplierRepo = SupplierRepo;
        }

        // GET: ProductsController
        public ActionResult Index()
        {
            var product = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Product>, List<ProductViewModel>>(product);
            return View(model);

        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {

            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var product = _repo.FindById(id);
            var model = _mapper.Map<ProductViewModel>(product);
            return View(model);
        }

        // GET: ProductsController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}
        public ActionResult Create()
        {
            var suppliers = _SupplierRepo.FindAll()
                .Select(q => new SelectListItem { Text = q.CompanyName, Value = q.Id.ToString() });
            var model = new ProductViewModel
            {
                Suppliers = suppliers
            };
            return View(model);
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var product = _mapper.Map<Product>(model);
                //supplier.D

                var IsSuccess = _repo.Create(product);
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

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var product = _repo.FindById(id);
            var model = _mapper.Map<ProductViewModel>(product);
            return View(model);

        }

        // POST: ProductsController/Edit/5
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
                var product = _mapper.Map<Product>(model);
                var IsSuccess = _repo.Update(product);
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

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {

            var product = _repo.FindById(id);
            if (product == null)
            {
                return NotFound();
            }
            var IsSuccess = _repo.Delete(product);
            if (!IsSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProductViewModel model)
        {
            try
            {
                var product = _repo.FindById(id);
                if (product == null)
                {
                    return NotFound();
                }
                var IsSuccess = _repo.Delete(product);
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
