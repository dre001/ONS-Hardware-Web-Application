using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ONS_Hardware_Web_Application.Contracts;
using ONS_Hardware_Web_Application.Data;
//using ONS_Hardware_Web_Application.Data;
using ONS_Hardware_Web_Application.Models;
using System;
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

        public InvoicesController(IInvoiceRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

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

        // GET: InvoiceController/Create
        public ActionResult Create()
        {
            return View();
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
            catch
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
