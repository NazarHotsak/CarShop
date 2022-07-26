using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using CheapCars.Models;

namespace CheapCars.Infrastructure
{
    [HtmlTargetElement(tag: "div", Attributes = "page-car-model, page-class-img")]
    public class PageSliderTagHelper : TagHelper
    {
        public Car PageCarModel { get; set; }

        public string PageClassImg { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder result = new TagBuilder("div");

            string[] CarImgsOfSlider = FileManager.GetCarImgsOfSlider(PageCarModel.Name, PageCarModel.CarID);

            if (CarImgsOfSlider == null)
            {
                return;
            }

            foreach (var path in CarImgsOfSlider)
            {
                TagBuilder img = new TagBuilder("img");

                img.Attributes["src"] = path;

                img.Attributes["draggable"] = "false";

                img.AddCssClass(PageClassImg);

                result.InnerHtml.AppendHtml(img);
            }

            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
