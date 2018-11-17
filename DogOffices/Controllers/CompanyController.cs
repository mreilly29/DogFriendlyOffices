using DogOffices.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogOffices.Controllers
{
    public class CompanyController : Controller
    {
        private ICompanyRepository companyRepo;

        public CompanyController(ICompanyRepository companyRepo)
        {
            this.companyRepo = companyRepo;
        }

        public IActionResult Index()
        {
            var model = companyRepo.GetAll();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = companyRepo.GetById(id);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Company company)
        {
            companyRepo.Create(company);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var model = companyRepo.GetById(id);
            return View(model);
        }

        [ActionName("Delete")]
        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            companyRepo.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = companyRepo.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Company company)
        {
            companyRepo.Update(company);
            return RedirectToAction("Index");
        }
    }
}
