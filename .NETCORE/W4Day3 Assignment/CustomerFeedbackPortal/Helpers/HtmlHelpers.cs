using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq.Expressions;

namespace FeedbackPortal.Helpers
{
    public static class HtmlHelpers
    {
        public static IHtmlContent StyledTextBox(this IHtmlHelper html, string name, string placeholder)
        {
            return html.TextBox(name, null, new { @class = "form-control", placeholder });
        }
    }
}
