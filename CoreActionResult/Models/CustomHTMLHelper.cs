using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text;

namespace CoreActionResult.Models
{
    public static class CustomHTMLHelper
    {
        public static IHtmlContent Image(this IHtmlHelper htmlHelper, string src, string alt, object? htmlAttributes = null)
        {
            var imgTag = new TagBuilder("img");
            imgTag.Attributes.Add("src", src);
            imgTag.Attributes.Add("alt", alt);
            if (htmlAttributes != null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                imgTag.MergeAttributes(attributes);
            }
            return imgTag;
        }
        public static IHtmlContent Image(string src, string alt, object? htmlAttributes = null)
        {
            // Creates a new <img> tag using the TagBuilder class, which helps in generating well-formed HTML tags.
            var imgTag = new TagBuilder("img");
            // Adds the 'src' attribute to the <img> tag, setting it to the value passed by the 'src' parameter.
            imgTag.Attributes.Add("src", src);
            // Adds the 'alt' attribute to the <img> tag, setting it to the value passed by the 'alt' parameter.
            imgTag.Attributes.Add("alt", alt);
            // Checks if the 'htmlAttributes' parameter is not null.
            // This parameter contains additional HTML attributes such as class, style, etc.
            if (htmlAttributes != null)
            {
                // Converts the anonymous object 'htmlAttributes' into a dictionary of key-value pairs.
                // These key-value pairs represent HTML attributes and their values (e.g., class, style, id).
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                // Merges the additional HTML attributes (if any) into the <img> tag.
                // If the <img> tag already has attributes, they are preserved and not overwritten.
                imgTag.MergeAttributes(attributes);
            }
            // Returns the constructed <img> tag as an IHtmlContent object, 
            // which can be rendered directly in Razor views to display the image.
            return imgTag;
        }
    }
    //Form Control with Validation
    public static class FormControlHelpers
    {
        public static IHtmlContent CustomeInputWithValidation(this IHtmlHelper htmlHelper, string modelPropertyName, string labelText)
        {
            var fullHtml = $@"<div class='form-group'>
                <label for='{modelPropertyName}'>{labelText}</label?
                <input type='text' class='form-control' id='{modelPropertyName}' name='{modelPropertyName}'
                asp-for='{modelPropertyName}'/>
                <span asp-validation-for='{modelPropertyName}' class='text-danger'></span>
                </div>";
            return new HtmlString(fullHtml);
        }
    }
    // Breadcrumb Helper
    public static class BreadcrumbHelpers
    {
        public static IHtmlContent Breadcrumbs(this IHtmlHelper htmlHelper, List<(string Url, string Name)> paths)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<nav aria-label = 'breadcrumb'>");
            stringBuilder.Append("<ol class='breadcrumb'>");
            foreach (var path in paths)
            {
                stringBuilder.AppendFormat("<li class='breadcrumb-item'><a href='{0}'>{1}</a></lid>", path.Url, path.Name);
            }
            stringBuilder.Append("</ol></nav>");
            return new HtmlString(stringBuilder.ToString());

        }
    }
    // SEO Meta Tag Helper
    public static class SeoHelper
    {
        public static IHtmlContent MetaDescrption(this IHtmlHelper htmlHelper, string content)
        {
            return new HtmlString($"<meta name='description' content='{content}'>");
        }
    }
    // Theming Helper
    public static class ThemeHelpers
    {
        public static IHtmlContent RenderThemeCss(this IHtmlHelper htmlHelper, string currentTheme)
        {
            var cssLink = $"/css/themes/{currentTheme}.css";
            return new HtmlString($"<link rel='stylesheet' href='{cssLink}'>");
        }
    }
    // Pagination Constrols
    public static class PaginationHelpers
    {
        public static HtmlString CreatePagination(this IHtmlHelper htmlHelper, int currentPage, int totalPages)
        {
            StringBuilder result = new StringBuilder();
            result.Append("<nav><ul class='pagination'>");
            for (int i = 1; i <= totalPages; i++)
            {
                if (i == currentPage)
                {
                    result.Append($"<li class='page-item active'><span class='page-link'>{i}</span></li>");
                }
                else
                {
                    result.Append($"<li class='page-item'><a class='page-link' href='?page={i}'>{i}</a></li>");
                }
            }
            result.Append("</ul></nav>");
            return new HtmlString(result.ToString());
        }
    }

}
    
   