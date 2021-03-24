using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class EmployeesController : Controller
    {
        //private readonly Employee _repo;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;
        public EmployeesController(IMapper mapper,
            UserManager<Employee> userManager)
        {
           // _repo = repo;
            _mapper = mapper;
            _userManager = userManager;

        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            var employees = _userManager.GetUsersInRoleAsync("Employee").Result;
            var model = _mapper.Map<List<EmployeeViewModel>>(employees);
            return View(model);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(string id)
        {
            //if (!_userManager.GetUsersInRoleAsync(id).IsFaulted)
            //{
            //    return NotFound();                                             //What NOT!!to do for the Employee<<
            //}
            //var employees = _userManager.GetUsersInRoleAsync(id);
            //var model = _mapper.Map<List<EmployeeViewModel>>(employees);
            //return View(model);
            var employee = _mapper.Map<EmployeeViewModel>(_userManager.FindByIdAsync(id).Result);
            
             return View(employee);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel model)
        {
            //try
            //{
                //    if (!ModelState.IsValid)
                //    {
                //        return View(model);
                //    }

                //    var employee = _mapper.Map<Employee>(model);


                //    var IsSuccess = _userManager.CreateAsync(employee);
                //    if (!IsSuccess)
                //    {
                //        ModelState.AddModelError("", "Sorry, Something went wrong...");
                //        return View(model);
                //    }

                //    return RedirectToAction(nameof(Index));
                //}
                //catch
                //{
                //    ModelState.AddModelError("", "Sorry, Something went wrong...");
                //    return View();
                //}
                try
                {
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(string id)
        {
            var employee = _mapper.Map<EmployeeViewModel>(_userManager.FindByIdAsync(id).Result);
          
           // var employee = _mapper.Map<EmployeeViewModel>(_userManager.FindByIdAsync(id).Result);
            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeViewModel model, string id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View (model);
                }
                var employee = _mapper.Map<Employee>(model);
                var IsSuccess = _userManager.UpdateAsync(employee).Result;

                //var employee = _mapper.Map<EmployeeViewModel>(_userManager.FindByIdAsync(id).Result);
                // var employee = _mapper.Map<EmployeeViewModel>(model);
                //var IsSuccess = _mapper.Map<EmployeeViewModel>(_userManager.Update (employee));
               //var IsSuccess = _mapper.Map<EmployeeViewModel>(_userManager.UpdateAsync(employee).Result);
                //if (!IsSuccess)
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
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
