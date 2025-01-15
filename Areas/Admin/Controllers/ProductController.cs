using BazzarBook.DataAccess.Repository.IRepository;
using BazzarBook.Models;
using BazzarBook.Models.ViewModels;
using BazzarBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BazzarBook.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = SD.Role_Admin)]
	public class ProductController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
		{
			_unitOfWork = unitOfWork;
			_webHostEnvironment = webHostEnvironment;
		}

		public IActionResult Index()
		{
			List<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();

			return View(productList);
		}
		public IActionResult Upsert(int? id)
		{
			//ViewBag.CategoryList = catgeroyList;
			//ViewData["CategoryList"] = catgeroyList;
			ProductViewModel productViewModel = new ProductViewModel
			{
				catgeroyList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
				{
					Text = u.Name,
					Value = u.Id.ToString()
				}),
				Product = new()
			};
			if (id == null || id == 0)
			{
				// create
				return View(productViewModel);
			}
			else
			{
				// update
				productViewModel.Product = _unitOfWork.Product.Get(p => p.Id == id);
				return View(productViewModel);
			}

		}
		[HttpPost]
		public IActionResult Upsert(ProductViewModel productViewModel, IFormFile? file)
		{
			if (ModelState.IsValid)
			{
				string wwwRootPath = _webHostEnvironment.WebRootPath;
				if (file != null)
				{
					string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
					string productPath = Path.Combine(wwwRootPath, @"images\product");

					if (!string.IsNullOrEmpty(productViewModel.Product.ImageUrl))
					{
						// Delete the old image
						var oldImagePath = Path.Combine(wwwRootPath, productViewModel.Product.ImageUrl.TrimStart('\\'));

						if (System.IO.File.Exists(oldImagePath))
						{
							System.IO.File.Delete(oldImagePath);
						}
					}


					using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
					{
						file.CopyTo(fileStream);
					}

					productViewModel.Product.ImageUrl = @"\images\product\" + fileName;
				}

				if (productViewModel.Product.Id == 0)
				{
					_unitOfWork.Product.Add(productViewModel.Product);
				}
				else
				{
					_unitOfWork.Product.Update(productViewModel.Product);
				}
				_unitOfWork.Save();
				TempData["success"] = "Product created successfully.";
				return RedirectToAction("Index", "Product");
			}
			else
			{
				productViewModel.catgeroyList = _unitOfWork.Category.GetAll(includeProperties: "Category").Select(u => new SelectListItem
				{
					Text = u.Name,
					Value = u.Id.ToString()
				});
				return View(productViewModel);
			}
		}

		#region API CALLS
		[HttpGet]
		public IActionResult GetAll()
		{
			List<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
			return Json(new { data = productList });
		}
		[HttpDelete]
		public IActionResult Delete(int? id)
		{
			var productToBeDeleted = _unitOfWork.Product.Get(product => product.Id == id);
			if (productToBeDeleted == null)
			{
				return Json(new { success = false, message = "Eroor while deleting" });
			}

			var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, productToBeDeleted.ImageUrl.TrimStart('\\'));

			if (System.IO.File.Exists(oldImagePath))
			{
				System.IO.File.Delete(oldImagePath);
			}
			_unitOfWork.Product.Remove(productToBeDeleted);
			_unitOfWork.Save();

			return Json(new { success = true, message = "Product deleted successfully" });
		}
		#endregion

	}
}
