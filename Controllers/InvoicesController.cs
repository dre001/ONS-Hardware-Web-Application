using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ONS_Hardware_Web_Application.Contracts;
using ONS_Hardware_Web_Application.Data;
//using ONS_Hardware_Web_Application.Data;
using ONS_Hardware_Web_Application.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application.Controllers
{
    [Authorize]
    public class InvoicesController : Controller
    {
        private readonly IInvoiceRepository _repo;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepo; //new
        private readonly UserManager<Employee> _userManager; //new
        public InvoicesController(IInvoiceRepository repo, 
            IMapper mapper,
              UserManager<Employee> userManager, //new
              IProductRepository productRepo) //new
        {
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager; //new
            _productRepo = productRepo; //new
        }
        // GET: InvoiceController
        public ActionResult Index()
        {
            var invoices = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Invoice>, List<InvoiceViewModel>>(invoices);
            return View(model);
        }



        // GET: InvoiceController/Details/5
        public ActionResult Details(int id)
        {

            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var invoice = _repo.FindById(id);
            var model = _mapper.Map<InvoiceViewModel>(invoice);
            return View(model);
        }

        //public ActionResult CreateListEmployeess()  //new
        //{
        //    var employees = _userManager.GetUsersInRoleAsync("Employee").Result;   //new
        //    var model = _mapper.Map<List<EmployeeViewModel>>(employees); //new
        //    return View(model); //new
        //}

        // GET: InvoiceController/Create
        public ActionResult Create()
        {


            var product = _productRepo.FindAll()
               .Select(q => new SelectListItem { Text = q.ProductType, Value = q.Id.ToString() });
            var model = new InvoiceViewModel

            {
                Products = product
            };
            return View(model);
            //return View(); 
        }

        // POST: InvoiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvoiceViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var invoice = _mapper.Map<Invoice>(model);
                invoice.InvoiceDate = DateTime.Now; // To inject you own date picker

                var IsSuccess = _repo.Create(invoice);
                if (!IsSuccess)
                {
                    ModelState.AddModelError("", "Sorry, Something went wrong...");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Sorry, Something went wrong...");
                return View();
            }
        }


        // GET: InvoiceController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var invoice = _repo.FindById(id);
            var model = _mapper.Map<InvoiceViewModel>(invoice);


            var product = _productRepo.FindAll()
              .Select(q => new SelectListItem { Text = q.ProductType, Value = q.Id.ToString() });
             model = new InvoiceViewModel

            {
                Products = product
            };
            return View(model);
           
        }

        // POST: InvoiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InvoiceViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var invoice = _mapper.Map<Invoice>(model);
                var IsSuccess = _repo.Update(invoice);
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



        // GET: InvoiceController/Delete/5
        public ActionResult Delete(int id)
        {
            var invoice = _repo.FindById(id);
            if (invoice == null)
            {
                return NotFound();
            }
            var IsSuccess = _repo.Delete(invoice);
            if (!IsSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: InvoiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, InvoiceViewModel model)
        {
            try
            {
                var invoice = _repo.FindById(id);
                if (invoice == null)
                {
                    return NotFound();
                }
                var IsSuccess = _repo.Delete(invoice);
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
