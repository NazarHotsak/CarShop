using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;
using CheapCars.Infrastructure;

namespace CheapCars.Infrastructure
{
    public static class HtmlHelper
    {
        public static HtmlString PreviewImg(this IHtmlHelper html, string? carName, int? id)
        {
            if (carName == null)
            {
                return new HtmlString("Фото відсутнє");
            }

            TagBuilder result = new TagBuilder("img");

            result.Attributes["src"] = FileManager.GetPreviewImgPathOfCar(carName, id);

            var writer = new System.IO.StringWriter();

            result.WriteTo(writer, HtmlEncoder.Default);

            return new HtmlString(writer.ToString());
        }
    }
}
