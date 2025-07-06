﻿using Bazzar.DataAccess.Data;
using Bazzar.DataAccess.Repository;
using Bazzar.DataAccess.Repository.IRepository;
using Bazzar.Models;
using Bazzar.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BazzarBook.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = SD.Role_Admin)]
	public class CategoryController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public CategoryController(IUnitOfWork unitOfWork)
		{
            _unitOfWork = unitOfWork;
        }
		public IActionResult Index()
		{
			List<Category> objCategoryList = _unitOfWork.CategoryRepository.GetAll().ToList();
            return View(objCategoryList);
		}
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Category obj)
		{
			if (ModelState.IsValid)
			{
                _unitOfWork.CategoryRepository.Add(obj);
                _unitOfWork.Save();
				TempData["success"] = "Category created successfully";
				return RedirectToAction("Index", "Category");
			}
			return View();
		}
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
				return NotFound();
			Category categoryFromDb = _unitOfWork.CategoryRepository.Get(u => u.Id == id);
			if (categoryFromDb == null)
				return NotFound();

			return View(categoryFromDb);
		}

		[HttpPost]
		public IActionResult Edit(Category obj)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.CategoryRepository.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully";
				return RedirectToAction("Index", "Category");

			}
			return View();
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
				return NotFound();
			Category categoryFromDb = _unitOfWork.CategoryRepository.Get(u => u.Id == id);
            if (categoryFromDb == null)
				return NotFound();

			return View(categoryFromDb);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			Category obj = _unitOfWork.CategoryRepository.Get(u => u.Id == id);
			if (obj == null)
				return NotFound();
			_unitOfWork.CategoryRepository.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
			return RedirectToAction("Index", "Category");
		}
	}
}
