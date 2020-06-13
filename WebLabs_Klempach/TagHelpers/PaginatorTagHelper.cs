using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace WebLabs_Klempach.TagHelpers
{
    public class PaginatorTagHelper : TagHelper
    {
        IUrlHelperFactory urlHelperFactory;
        public int CurrentPage { get; set; }
        public int TotalPagesNumber { get; set; }
        public string PaginationClass { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public int? CategoryId { get; set; }
        public PaginatorTagHelper(IUrlHelperFactory uhf)
        {
            urlHelperFactory = uhf;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext viewContext { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var urlHelper = urlHelperFactory
                .GetUrlHelper(viewContext);
            output.TagName = "nav";
            var ulTag = new TagBuilder("ul");
            ulTag.AddCssClass("pagination");
            ulTag.AddCssClass(PaginationClass);
            for (int i = 1; i <= TotalPagesNumber; i++)
            {
                var url = urlHelper.Action(new UrlActionContext
                {
                    Action = Action,
                    Controller = Controller,
                    Values = new
                    {
                        pageNumber = i,
                        category = CategoryId.HasValue
                            ? null
                            : CategoryId
                    }
                });
                var item = GetPagerItem(
                    url: url,
                    text: i.ToString(),
                    active: i == CurrentPage
                );
                ulTag.InnerHtml.AppendHtml(item);
            }
            output.Content.AppendHtml(ulTag);
            Console.WriteLine(output.ToString());
        }
        private TagBuilder GetPagerItem(string url, string text, bool active = false, bool disabled = false)
        {
            var liTag = new TagBuilder("li");
            liTag.AddCssClass("page-item");
            liTag.AddCssClass(active ? "active" : "");
            liTag.AddCssClass(disabled ? "disabled" : "");

            var aTag = new TagBuilder("a");
            aTag.AddCssClass("page-link");
            aTag.Attributes.Add("href", url);
            aTag.InnerHtml.Append(text);
            liTag.InnerHtml.AppendHtml(aTag);
            return liTag;
        }
    }
}
