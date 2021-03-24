using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class CustomersController : Controller
    {

        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;
        private readonly IParishRepository _parishRepo;

        public CustomersController(ICustomerRepository repo,
            IParishRepository parishRepo,
            IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            _parishRepo = parishRepo;
        }

        // GET: CustomersController
        public ActionResult Index()
        {
            var customers = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Customer>, List<CustomerViewModel>>(customers);
            return View(model);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {

            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var customer = _repo.FindById(id);
            var model = _mapper.Map<CustomerViewModel>(customer);
            return View(model);
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            var parishes = _parishRepo.FindAll()
                .Select(q => new SelectListItem { Text = q.Parishes, Value = q.Id.ToString() });
            var model = new CustomerViewModel
            {
                Parishes = parishes
            };
            return View(model);
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var customer = _mapper.Map<Customer>(model);


                var IsSuccess = _repo.Create(customer);
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

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var customer = _repo.FindById(id);
            var model = _mapper.Map<CustomerViewModel>(customer);

            var parishes = _parishRepo.FindAll()
               .Select(q => new SelectListItem { Text = q.Parishes, Value = q.Id.ToString() });
             model = new CustomerViewModel
            {
                Parishes = parishes
            };
            return View(model);
           
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var customer = _mapper.Map<Customer>(model);
                var IsSuccess = _repo.Update(customer);
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

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = _repo.FindById(id);
            if (customer == null)
            {
                return NotFound();
            }
            var IsSuccess = _repo.Delete(customer);
            if (!IsSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CustomerViewModel model)
        {
            try
            {
                var customer = _repo.FindById(id);
                if (customer == null)
                {
                    return NotFound();
                }
                var IsSuccess = _repo.Delete(customer);
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
