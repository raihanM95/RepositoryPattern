using Application;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class ProductsController : Controller
    {
        private IRepositoryWrapper _repoWrapper;
        public ProductsController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        // GET: ProductsController
        public IActionResult Index()
        {
            var products = _repoWrapper.Product.FindAll();
            return View(products);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            Product product = _repoWrapper.Product.FindByCondition(i => i.Id == id).FirstOrDefault();
            return View(product);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                _repoWrapper.Product.Create(product);
                _repoWrapper.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = _repoWrapper.Product.FindByCondition(i => i.Id == id).FirstOrDefault();
            return View(product);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                _repoWrapper.Product.Update(product);
                _repoWrapper.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                Product product = _repoWrapper.Product.FindByCondition(i => i.Id == id).FirstOrDefault();
                _repoWrapper.Product.Delete(product);
                _repoWrapper.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
