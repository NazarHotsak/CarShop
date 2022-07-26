using Microsoft.AspNetCore.Mvc;
using CheapCars.Infrastructure;
using CheapCars.Models;
using CheapCars.Models.ViewModels;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

namespace CheapCars.Controllers
{
    public class AdminController : Controller
    {
        private ICarRepository _carRepository;
        private IWebHostEnvironment _webHostEnvironment;

        public AdminController(ICarRepository carRepository, IWebHostEnvironment webHostEnvironment)
        {
            _carRepository = carRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public ViewResult Edit(int idCar)
        {
            return View(new EditModel()
            {
                Car = _carRepository.Cars.FirstOrDefault(car => car.CarID == idCar)
            });
        }

        [HttpPost]
        public IActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                _carRepository.Save(car);
                return RedirectToAction("AdminList", "Catalog");
            }

            return View(new EditModel()
            {
                Car = car,
            });
        }

        public ViewResult Create()
        {
            return View("Edit", new EditModel()
            {
                Car = new Car()
            });
        }

        [HttpGet]
        public IActionResult Delete(string carName, int id)
        {
            _carRepository.Delete(id);

            FileManager.RemoveFolderOfCar(carName, id);

            return RedirectToAction(nameof(CatalogController.AdminList), "Catalog");
        }

        [HttpGet]
        public ViewResult EditSlider(string carName, int id)
        {
            ViewData["id"] = id;
            ViewData["carName"] = carName;
            return View(FileManager.GetCarImgsOfSlider(carName, id));
        }

        [HttpGet]
        public IActionResult RemoveImgOfSlider(string carName, int id, string path)
        {
            FileManager.RemoveImgOfCar(path);

            return RedirectToAction(nameof(EditSlider), new { carName = carName, id = id });
        }

        [HttpGet]
        public ViewResult AddImgsOfSlider(string carName, int id)
        {
            ViewData["id"] = id;
            ViewData["carName"] = carName;
            FileManager.CreateSliderFolderOfCar(carName, id);
            return View(new SliderModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddImgsOfSlider(string carName, int id, List<IFormFile> imgs)
        {
            foreach (var img in imgs)
            {
                if (img != null && img.Length > 0)
                {
                    string path = Path.Combine(_webHostEnvironment.WebRootPath, FileManager.RootImgs, FileManager.GetFolderNameOfCar(carName, id),
                        "slider", img.FileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await img.CopyToAsync(fileStream);
                    }
                }
            }

            return RedirectToAction(nameof(EditSlider), new { carName = carName, id = id });
        }

        [HttpPost]
        public async Task<IActionResult> EditPreviewImg(IFormFile img, string carName, int id)
        {
            if (img != null && img.Length > 0)
            {
                FileManager.CreateFolderOfCar(carName, id);

                string path = Path.Combine(_webHostEnvironment.WebRootPath, FileManager.RootImgs, FileManager.GetFolderNameOfCar(carName, id),
                    img.FileName);

                FileManager.RemovePreviewImgOfCar(carName, id);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await img.CopyToAsync(fileStream);
                }
            }

            return RedirectToAction(nameof(Edit), new { id });
        }
    }
}
