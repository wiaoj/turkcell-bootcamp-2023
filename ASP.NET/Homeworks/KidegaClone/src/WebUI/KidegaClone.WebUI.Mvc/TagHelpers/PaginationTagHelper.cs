using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using KidegaClone.Application.DataTransferObjects.Pagination;
using Microsoft.AspNetCore.Html;

namespace KidegaClone.WebUI.Mvc.TagHelpers;

[HtmlTargetElement("div", Attributes = "pagination-info")]
public class PaginationTagHelper : TagHelper {
    public String PageAction { get; set; } 
    public PaginationInfo PaginationInfo { get; set; } 

    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext ViewContext { get; set; } 

    private readonly IUrlHelperFactory urlHelperFactory;
    private IUrlHelper urlHelper => this.urlHelperFactory.GetUrlHelper(this.ViewContext);

    public PaginationTagHelper(IUrlHelperFactory urlHelperFactory) {
        this.urlHelperFactory = urlHelperFactory;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output) {
        if(this.PaginationInfo.Pages < 2)
            return;
       
        TagBuilder nav = new("nav");

        TagBuilder pagination = new("ul");
        pagination.AddCssClass("pagination justify-content-center");

        pagination.InnerHtml.AppendHtml(buildPreviousPageButtonTag());
        pagination.InnerHtml.AppendHtml(buildPageItemsContent());
        pagination.InnerHtml.AppendHtml(buildNextPageButtonTag());

        nav.InnerHtml.AppendHtml(pagination);

        output.Content.AppendHtml(nav);
    }

    private IHtmlContentBuilder buildPageItemsContent() {
        void buildAndAppendPageItem(IHtmlContentBuilder contentBuilder, int pageNumber) {
            TagBuilder pageItem = buildPageItemTag();

            if(pageNumber == this.PaginationInfo.Index)
                pageItem.AddCssClass("active");

            TagBuilder pageLink = buildPageLinkTag(CreatePageUrl(pageNumber), new HtmlString(pageNumber.ToString()));

            pageItem.InnerHtml.AppendHtml(pageLink);
            contentBuilder.AppendHtml(pageItem);
        }

        HtmlContentBuilder contentBuilder = new();

        for(Int32 pageNumber = 1; pageNumber <= this.PaginationInfo.Pages; pageNumber++) {
            buildAndAppendPageItem(contentBuilder, pageNumber);
        }

        return contentBuilder;
    }

    private String? CreatePageUrl(Int32 pageIndex) {
        return this.urlHelper.Action(this.PageAction, new { page = pageIndex });
    }


    private TagBuilder buildPageItemTag() {
        TagBuilder li = new("li");
        li.AddCssClass("page-item");
        return li;
    }

    private TagBuilder buildPageLinkTag(String? href, IHtmlContent? innerHtml) {
        TagBuilder a = new("a");
        a.AddCssClass("page-link");
        a.Attributes["href"] = href;

        if(innerHtml is not null)
            a.InnerHtml.AppendHtml(innerHtml);

        return a;
    }

    private TagBuilder buildPreviousPageButtonTag() {
        TagBuilder nextButtonASpan = new("span");
        nextButtonASpan.Attributes["aria-hidden"] = "true";
        nextButtonASpan.InnerHtml.AppendHtml("&laquo;");

        TagBuilder pageLink = buildPageLinkTag(CreatePageUrl(this.PaginationInfo.Index - 1), nextButtonASpan);

        TagBuilder pageItem = buildPageItemTag();
        pageItem.AddCssClass(this.PaginationInfo.HasPrevious ? "" : "disabled");
        pageItem.InnerHtml.AppendHtml(pageLink);

        return pageItem;
    }

    private TagBuilder buildNextPageButtonTag() {
        TagBuilder previousButtonASpan = new("span");
        previousButtonASpan.Attributes["aria-hidden"] = "true";
        previousButtonASpan.InnerHtml.AppendHtml("&raquo;");

        TagBuilder pageLink = buildPageLinkTag(CreatePageUrl(this.PaginationInfo.Index + 1), previousButtonASpan);

        TagBuilder pageItem = buildPageItemTag();
        pageItem.AddCssClass(this.PaginationInfo.HasNext ? "" : "disabled");
        pageItem.InnerHtml.AppendHtml(pageLink);

        return pageItem;
    }
}