using System.IO;
using System.Linq;
using System.Collections.Generic;
using CheapCars.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CheapCars.Infrastructure
{
    public static class FileManager
    {
        private static readonly string Root = "wwwroot";
        private static readonly string Slider = "slider";
        public static readonly string RootImgs = "imagesOfCars";


        public static string GetPreviewImgPathOfCar(string carName, int? id)
        {
            string path = Path.Combine(Root, "imagesOfCars", FileManager.GetFolderNameOfCar(carName, id));

            if (Directory.Exists(path: path) && Directory.GetFiles(path).Length > 0)
            {
                return Directory.GetFiles(path).First().Remove(0, Root.Length);
            }

            return null;
        }

        public static void RemovePreviewImgOfCar(string carName, int? id)
        {
            RemoveImgOfCar(path: GetPreviewImgPathOfCar(carName, id));
        }

        public static void RemoveImgOfCar(string path)
        {
            string fullPath = Root + path;

            if (fullPath != null && File.Exists(path: fullPath))
            {
                File.Delete(fullPath);
            }
        }

        public static string[] GetCarImgsOfSlider(string carName, int? id)
        {
            string pathToSlider = Path.Combine("wwwroot", "imagesOfCars", FileManager.GetFolderNameOfCar(carName, id), Slider);

            if (Directory.Exists(path: pathToSlider))
            {
                string[] paths = Directory.GetFiles(pathToSlider);

                for (int i = 0; i < paths.Length; i++)
                {
                    paths[i] = paths[i].Remove(0, Root.Length);
                }

                return paths;
            }

            return null;
        }

        public static void RemoveFolderOfCar(string carName, int? id)
        {
            string path = Path.Combine(Root, RootImgs, FileManager.GetFolderNameOfCar(carName, id));

            if (Directory.Exists(path))
            {
                Directory.Delete(path, recursive: true);
            }
        }

        public static void CreateSliderFolderOfCar(string carName, int? id)
        {
            CreateFolder(path: Path.Combine(Root, RootImgs, FileManager.GetFolderNameOfCar(carName, id), Slider));
        }

        public static void CreateFolderOfCar(string carName, int? id)
        {
            CreateFolder(path: Path.Combine(Root, RootImgs, FileManager.GetFolderNameOfCar(carName, id)));
        }

        public static void CreateFolder(string path)
        {
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }
        }

        public static string GetFolderNameOfCar(string carName, int? id)
        {
            return $"{carName.Replace(" ","_")}_{id}";
        }
    }
}
