using Bazzar.Models;
using BazzarBook.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BazzarBook.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public CategoryController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			List<Category> categoriesList = _unitOfWork.Category.GetAll().OrderBy(x => x.DisplayOrder).ToList();
			return View(categoriesList);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Category category)
		{
			if (category.Name == category.DisplayOrder.ToString())
			{
				ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name."); // Will display this error msg under the name field
			}
			if (ModelState.IsValid)
			{
				_unitOfWork.Category.Add(category);
				_unitOfWork.Save();
				TempData["success"] = "Category created successfully.";
				return RedirectToAction("Index", "Category"); // Because we are in the same controlloer it's optional to add Category controller after action
			}
			return View();
		}
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category? foundedCategory = _unitOfWork.Category.Get(category => category.Id == id); // work only with primay key
																								 //Category? category = _dbContext.Categories.FirstOrDefault(category => category.Id == id);
																								 //Category? category = _dbContext.Categories.Where(category => category.Id == id).FirstOrDefault();
			if (foundedCategory == null)
			{
				return NotFound();
			}
			return View(foundedCategory);
		}
		[HttpPost]
		public IActionResult Edit(Category category)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Category.Update(category);
				_unitOfWork.Save();
				TempData["success"] = "Category updated successfully.";
				return RedirectToAction("Index", "Category"); // Because we are in the same controlloer it's optional to add Category controller after action
			}
			return View();
		}

		public IActionResult Delete(int? id)
		{
			if (id == 0 || id == null)
			{
				return NotFound();
			}

			Category? foundedCategory = _unitOfWork.Category.Get(category => category.Id == id);
			if (foundedCategory == null)
			{
				return NotFound();
			}
			return View(foundedCategory);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(int? id)
		{
			Category? category = _unitOfWork.Category.Get(category => category.Id == id);
			if (category == null)
			{
				return NotFound();
			}
			_unitOfWork.Category.Remove(category);
			_unitOfWork.Save();
			TempData["success"] = "Category deleted successfully.";
			return RedirectToAction("Index");
		}

	}
}
