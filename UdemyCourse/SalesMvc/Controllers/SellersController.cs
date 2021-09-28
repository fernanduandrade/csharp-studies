using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SalesMvc.Models;
using SalesMvc.Models.ViewModels;
using SalesMvc.Services.Exceptions;
using SalesMvc.Services;
using System.Diagnostics;

namespace SalesMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;
        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }
        public IActionResult Index() => View(_sellerService.FindAll());
        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel {Departments = departments};
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
           if(!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var viewModel = new SellerFormViewModel {Seller = seller, Departments = departments};
                return View(viewModel);
            }
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id not provided"});
            }

            var obj = _sellerService.FinById(id.Value);
            if(obj == null)
                return RedirectToAction(nameof(Error), new {message = "Id not found"});
            
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken
        ]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult Details(int? id)
        {
            if(id == null)
                return RedirectToAction(nameof(Error), new {message = "Id not provided"});

            var obj = _sellerService.FinById(id.Value);

            if(obj == null)
                return RedirectToAction(nameof(Error), new {message = "Id not found"});
        
            return View(obj);
        }

        public IActionResult Edit(int? id) 
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id not provided"});
            }

            var obj = _sellerService.FinById(id.Value);
            if(obj ==null) 
                return RedirectToAction(nameof(Error), new {message = "Id not found"});

            List<Department> departments = _departmentService.FindAll();

            SellerFormViewModel viewModel = new SellerFormViewModel {Seller = obj, Departments = departments};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if(!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var viewModel = new SellerFormViewModel {Seller = seller, Departments = departments};
                return View(viewModel);
            }
            if(id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new {message = "Id doesn't match"});
            }

            try 
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch(NotFoundException error)
            {
                return RedirectToAction(nameof(Error), new {message = error.Message});
            }
            catch(DbConcurrencyException error)
            {
                return RedirectToAction(nameof(Error), new {message = error.Message});
            }
            
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }

    }
}