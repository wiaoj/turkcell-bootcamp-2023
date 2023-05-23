using CourseApp.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CourseApp.Mvc.TagBuilders;
[HtmlTargetElement("div", Attributes = "page-model")]
public class PageLinkBuilder : TagHelper {
    public String PageAction { get; set; } //Href
    public PagingInfo PageModel { get; set; } //Sayfa bilgileri

    private readonly IUrlHelperFactory urlHelperFactory; //actionu oluşturacak

    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext ViewContext { get; set; } // ilgili view'da bulunan ve erişilebilecek değerler

    public PageLinkBuilder(IUrlHelperFactory factory) {
        this.urlHelperFactory = factory;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output) {
        /*
        <div>
          <ul class="pagination pagination-lg">
            <li class="page-item active" aria-current="page">
              <span class="page-link">1</span>
            </li>
            <li class="page-item"><a class="page-link" href="#">2</a></li>
            <li class="page-item"><a class="page-link" href="#">3</a></li>
          </ul>
        </div>
        */

        IUrlHelper urlHelper = this.urlHelperFactory.GetUrlHelper(this.ViewContext);
        //TagBuilder div = new("div");

        TagBuilder ul = new("ul");
        ul.AddCssClass("pagination pagination-lg");

        for(Int32 i = 1; i <= this.PageModel.TotalPage; i++) {
            TagBuilder li = new("li");
            li.AddCssClass("page-item");

            if(i == this.PageModel.CurrentPage)
                li.AddCssClass("active");

            TagBuilder a = new("a");
            a.AddCssClass("page-link");
            a.Attributes["href"] = urlHelper.Action(this.PageAction, new { pageNo = i });
            a.InnerHtml.Append(i.ToString());

            li.InnerHtml.AppendHtml(a);
            ul.InnerHtml.AppendHtml(li);
        }

        //div.InnerHtml.AppendHtml(ul);

        output.Content.AppendHtml(ul);
    }
}