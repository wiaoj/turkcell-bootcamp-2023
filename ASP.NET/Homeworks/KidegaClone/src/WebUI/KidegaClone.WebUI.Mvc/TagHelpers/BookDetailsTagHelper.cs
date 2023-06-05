using KidegaClone.Application.DataTransferObjects.Responses;
using KidegaClone.Application.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KidegaClone.WebUI.Mvc.TagHelpers;
[HtmlTargetElement("book-details")]
public class BookDetailsTagHelper : TagHelper {
    public IEnumerable<BookDetailGenre>? Genres { get; set; }
    public String Barcode { get; set; }
    public String? CoverType { get; set; }
    public String? Size { get; set; }
    public Int32? PageCount { get; set; }
    public String? PaperType { get; set; }
    public DateTime? PublicationDate { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output) {
        output.Attributes.SetAttribute("class", "book-details");

        void addIfNotNullContent(String label, String? content) {
            if(content.IsNotNullOrWhiteSpace()) {
                TagBuilder tag = new("p");
                tag.InnerHtml.Append($"{label}: {content}");

                output.Content.AppendHtml(tag);
            }
        }

        void addIfNotNullDateTimeContent(String label, DateTime? content) {
            if(content.HasValue) {
                TagBuilder tag = new("p");
                tag.InnerHtml.Append($"{label}: {content.Value.ToMonthYearString()}");

                output.Content.AppendHtml(tag);
            }
        }


        if(this.Genres is not null && this.Genres.Count().IsGreaterThanZero()) {
            TagBuilder genresSection = new("div");

            foreach(BookDetailGenre genre in Genres) {
                TagBuilder genreName = new("p");
                genreName.InnerHtml.Append(genre.Name);
                genresSection.InnerHtml.AppendHtml(genreName);
            }
            output.Content.AppendHtml(genresSection);
        }

        addIfNotNullContent("Barcode", this.Barcode);
        addIfNotNullContent("Kapak Türü", this.CoverType);
        addIfNotNullContent("Boyut", this.Size);
        addIfNotNullContent("Sayfa Sayısı", this.PageCount.ToString());
        addIfNotNullContent("Kağıt Türü", this.PaperType);
        addIfNotNullDateTimeContent("Basım Tarihi", this.PublicationDate);
    }
}