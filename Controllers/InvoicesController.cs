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
        private readonly ICustomerRepository _customerRepo; //new
        private readonly UserManager<Employee> _userManager; //new
        public InvoicesController(IInvoiceRepository repo, 
            IMapper mapper,
              UserManager<Employee> userManager, //new
              IProductRepository productRepo, //new
              ICustomerRepository customerRepo)   //new
        {
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager; //new
            _productRepo = productRepo; //new
            _customerRepo = customerRepo; //new
        }
        // GET: InvoiceController
        public ActionResult Index()
        {
            var invoices = _repo.FindAll().ToList();
            var products = _productRepo.FindAll()
              .Select(q => new SelectListItem { Text = q.ProductCategory, Value = q.Id.ToString() });
            var customers = _customerRepo.FindAll()
                .Select(q => new SelectListItem { Text = q.FirstName, Value = q.Id.ToString()});
            
            //var customers = _customerRepo.FindAll()
            //   .Select(q => new SelectListItem { Text = q.FirstName , Value = q.Id.ToString() });
           
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


            //    var user = _userManager.FindByIdAsync(id);
            //    var Employee = _mapper.Map<List<EmployeeViewModel>>(user)
            //        .Select(q => new SelectListItem { Text = q.FirstName, Value = q.Id.ToString() });
            //    InvoiceViewModel model = new InvoiceViewModel
            //    {
            //        Employees = Employee  //.Select(q => new SelectListItem { Text = q.Id, Value = q.Id.ToString() })
            //    };
            //return View(model);

            //var employees = _userManager.GetUsersInRoleAsync("Employee")
            //    .Result

            //    (q => new SelectListItem { Text = q.Employee, Value = q.Id.ToString() });
            //var model = _mapper.Map<List<EmployeeViewModel>>(employees); //new

            //        return View(model); //new


            var products = _productRepo.FindAll()
                   .Select(q => new SelectListItem { Text = q.ProductCategory, Value = q.Id.ToString() });
            var customer = _customerRepo.FindAll()
                 .Select(q => new SelectListItem { Text = q.FirstName, Value = q.Id.ToString() });
            var model = new InvoiceViewModel

            {
                Products = products,
                Customers = customer
            };

            return View(model);
             
        }

        // POST: InvoiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvoiceViewModel model)
        {
            //double TotalCost = (double)(model.TotalCost = (model.UnitCost) * (model.Quantity));
            try
            {


                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var invoice = _mapper.Map<Invoice>(model);


                var IsSuccess = _repo.Create(invoice);
                if (!IsSuccess)
                {
                    ModelState.AddModelError("", "Sorry, Something went wrong...");
                    return View(model);
                }

                invoice = _mapper.Map<Invoice>(model);
                invoice.InvoiceDate = DateTime.Now; // To inject your own date picker
                
                var employee = _userManager.GetUserAsync(User).Result;

                double Total = (double)(model.TotalCost = (model.UnitCost) * (model.Quantity));
              
               
                

                var InvoiceModel = new InvoiceViewModel
                {
                    EmployeesId = employee.Id,
                    InvoiceDate =  DateTime.Now,
                    Quantity = model.Quantity,
                    UnitCost = model.UnitCost,
                    TotalCost = model.TotalCost,
                    //  Products = model.Products,
                    CustomerId = model.CustomerId
                };


                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Sorry, Something went wrong...");
                return View();
            }

            //    //    var product = _productRepo.FindAll()
            //    //       .Select(q => new SelectListItem { Text = q.ProductType, Value = q.Id.ToString() });
            //    //   model = new InvoiceViewModel

            //    //    {
            //    //        Products = product
            //    //    };

            //    if (!ModelState.IsValid)
            //    {
            //        return View(model);
            //    }

            //    var invoice = _mapper.Map<Invoice>(model);
            //   // invoice.InvoiceDate = DateTime.Now; // To inject your own date picker

            //    var IsSuccess = _repo.Create(invoice);

            //    if (!IsSuccess)
            //    {
            //        ModelState.AddModelError("", "Sorry, Something went wrong...");
            //        return View(model);
            //    }


            //    //if (DateTime.Compare((DateTime)model.InvoiceDate, DateTime.Now) >= 1)
            //    //{
            //    //    ModelState.AddModelError("", "Sorry, Date of invoice cannot be beyond current date");  // Check this Code
            //    //    return View();
            //    //}


            //    var employee = _userManager.GetUserAsync(User).Result;

            //   // double TotalCost = (double) (model.TotalCost = (model.UnitCost) * (model.Quantity));
            //    // var products =  _productRepo.

            //    var InvoiceModel = new InvoiceViewModel
            //    {
            //        EmployeesId = employee.Id,
            //        InvoiceDate = DateTime.Now,
            //        Quantity = model.Quantity,
            //        UnitCost = model.UnitCost,
            //        TotalCost = model.TotalCost,
            //      //  Products = model.Products,
            //        CustomerId = model.CustomerId
            //    };

            //    var Invoice = _mapper.Map<Invoice>(InvoiceModel);
            //    var isSuccess = _repo.Create(invoice);

            //    if (!isSuccess)
            //    {
            //        ModelState.AddModelError("", "Sorry, Something went wrong...");
            //        return View(model);
            //    }
            //    return RedirectToAction(nameof(Index),"Home");
            //}
            //catch (Exception e)
            //{
            //    ModelState.AddModelError("", "Sorry, Something went wrong updating invoice Record");
            //    return View();
            //}
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


            var products = _productRepo.FindAll()
                  .Select(q => new SelectListItem { Text = q.ProductCategory, Value = q.Id.ToString() });
            var customer = _customerRepo.FindAll()
                 .Select(q => new SelectListItem { Text = q.FirstName, Value = q.Id.ToString() });
                model = new InvoiceViewModel

            {
                Products = products,
                Customers = customer
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
            catch (Exception e)
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
