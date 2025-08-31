using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FeedbackPortal.TagHelpers
{
    [HtmlTargetElement("star-rating")]
    public class StarRating : TagHelper
    {
        public int Max { get; set; } = 5;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            for (int i = 1; i <= Max; i++)
            {
                output.Content.AppendHtml($"<span style='color: gold; font-size:20px;'>★</span>");
            }
        }
    }
}
