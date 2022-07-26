using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using CheapCars.Models.ViewModels;
using System.Collections.Generic;

namespace CheapCars.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory _urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            _urlHelperFactory = helperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PagingInfo PageModel { get; set; }

        public string PageAction { get; set; }

        public string PageClassPreviousPage { get; set; }

        public string PageClassNextPage { get; set; }

        public string PageClassPaging { get; set; }

        public string PageClassActive { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        //public SearchSetting PageSearchSetting { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);

            TagBuilder result = new TagBuilder("div");

            if (PageModel.CurrentPage != 1)
            {
                result.InnerHtml.AppendHtml(GetArrow(urlHelper: urlHelper, styleClass: PageClassPreviousPage, page: PageModel.CurrentPage - 1));
            }

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");

                PageUrlValues["page"] = i;

                tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);

                if (PageModel.CurrentPage == i)
                {
                    tag.AddCssClass(PageClassActive);
                }

                tag.AddCssClass(PageClassPaging);

                tag.InnerHtml.Append(i.ToString());

                result.InnerHtml.AppendHtml(tag);
            }

            if (PageModel.CurrentPage != PageModel.TotalPages && PageModel.TotalItems != 0)
            {
                result.InnerHtml.AppendHtml(GetArrow(urlHelper: urlHelper, styleClass: PageClassNextPage, page: PageModel.CurrentPage + 1));
            }
            
            output.Content.AppendHtml(result.InnerHtml);
        }

        private TagBuilder GetArrow(IUrlHelper urlHelper, string styleClass,  int page)
        {
            TagBuilder arrow = new TagBuilder("a");
            arrow.AddCssClass(styleClass);
            PageUrlValues["page"] = page;
            arrow.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
            arrow.InnerHtml.AppendHtml("<div></div>");
            return arrow;
        }

        //private string Action(IUrlHelper urlHelper, int page)
        //{
        //    return urlHelper.Action(PageAction, new
        //    {
        //        Cut = PageSearchSetting?.Cut,
        //        FullDuty = PageSearchSetting?.FullDuty,
        //        DriveType = PageSearchSetting?.DriveType,
        //        GearboxType = PageSearchSetting?.GearboxType,
        //        BrandType = PageSearchSetting?.BrandType,
        //        page = page
        //    });
        //}
    }
}


