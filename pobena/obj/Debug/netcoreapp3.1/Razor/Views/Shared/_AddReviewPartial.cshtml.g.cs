#pragma checksum "C:\Users\farahei\Desktop\FinalPerbelloProject\pobena\Views\Shared\_AddReviewPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "131bae3a944dca17b02d5fbb37180802659f9631"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__AddReviewPartial), @"mvc.1.0.view", @"/Views/Shared/_AddReviewPartial.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 2 "C:\Users\farahei\Desktop\FinalPerbelloProject\pobena\Views\_ViewImports.cshtml"
using pobena.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\farahei\Desktop\FinalPerbelloProject\pobena\Views\_ViewImports.cshtml"
using pobena.ViewModels.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\farahei\Desktop\FinalPerbelloProject\pobena\Views\_ViewImports.cshtml"
using pobena.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\farahei\Desktop\FinalPerbelloProject\pobena\Views\_ViewImports.cshtml"
using pobena.ViewModels.Basket;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\farahei\Desktop\FinalPerbelloProject\pobena\Views\_ViewImports.cshtml"
using pobena.ViewModels.Home;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\farahei\Desktop\FinalPerbelloProject\pobena\Views\_ViewImports.cshtml"
using pobena.ViewModels.Blog;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\farahei\Desktop\FinalPerbelloProject\pobena\Views\_ViewImports.cshtml"
using pobena.ViewModels.Shop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\farahei\Desktop\FinalPerbelloProject\pobena\Views\_ViewImports.cshtml"
using pobena.ViewModels.Order;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\farahei\Desktop\FinalPerbelloProject\pobena\Views\_ViewImports.cshtml"
using pobena.ViewModels.Contact;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"131bae3a944dca17b02d5fbb37180802659f9631", @"/Views/Shared/_AddReviewPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b94d712f200f137f77745818bd32c2b7e72680b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__AddReviewPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BlogVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<ol>\r\n");
#nullable restore
#line 3 "C:\Users\farahei\Desktop\FinalPerbelloProject\pobena\Views\Shared\_AddReviewPartial.cshtml"
     foreach (Review review in Model.Reviews)
    {

        if (!review.IsDeleted)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <li class=""comment-single media"">
                <div class=""comment-author-thumb me-3 me-sm-4"">
                    <img src=""assets/images/testimonial/testimonial-1.jpg"" alt=""Comment Author"">
                </div>
                <div class=""comment-content flex-grow-1"">
                    <div class=""comment-meta d-flex justify-content-between align-items-top"">
                        <div class=""comment-title"">
                            <h6>");
#nullable restore
#line 15 "C:\Users\farahei\Desktop\FinalPerbelloProject\pobena\Views\Shared\_AddReviewPartial.cshtml"
                           Write(review.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                            <span><span class=\"comment-date\">");
#nullable restore
#line 16 "C:\Users\farahei\Desktop\FinalPerbelloProject\pobena\Views\Shared\_AddReviewPartial.cshtml"
                                                        Write(review.CreatedAt?.ToString("MMMM dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> at <span class=\"comment-time\">");
#nullable restore
#line 16 "C:\Users\farahei\Desktop\FinalPerbelloProject\pobena\Views\Shared\_AddReviewPartial.cshtml"
                                                                                                                                    Write(review.CreatedAt?.ToString("hh:mm tt"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></span>\r\n                        </div>\r\n                        <div class=\"comment-reply\">\r\n                            <a href=\"#\"><span>Reply</span></a>\r\n");
#nullable restore
#line 20 "C:\Users\farahei\Desktop\FinalPerbelloProject\pobena\Views\Shared\_AddReviewPartial.cshtml"
                             if (User.Identity.Name == review.Name)
                            {
                                
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n                    <p>");
#nullable restore
#line 26 "C:\Users\farahei\Desktop\FinalPerbelloProject\pobena\Views\Shared\_AddReviewPartial.cshtml"
                  Write(review.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n            </li>\r\n            <div style=\"opacity:1;visibility: visible;\" class=\"EditComment\">\r\n\r\n            </div>\r\n");
#nullable restore
#line 32 "C:\Users\farahei\Desktop\FinalPerbelloProject\pobena\Views\Shared\_AddReviewPartial.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</ol>

<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js""></script>
<script>

    $(document).on(""click"", "".deleteComment"", function (e) {
        e.preventDefault();
        var id = $(this).attr(""data-id"");
        var bid = $(this).attr(""data-bid"");
        fetch(""Delete"" + ""?id="" + id).then(res => {
            return res.text();
        }).then(data => {
            $("".comments"").html(data);
            $(""#MessageMain"").val("""");

            fetch(""CommentCount"" + ""?id="" + bid).then(response => {
                return response.text()
            }).then(data => {
                $("".CommentCount"").html(data);
            })
        })
    })

    $(document).on(""click"", "".changeComment"", function (e) {
        e.preventDefault();
        var id = $(this).attr(""data-id"");
        fetch(""EditComment"" + ""?id="" + id).then(res => {
            return res.text()
        }).then(data => {
            $(this).parents(""li"").next().html(data)
        })");
            WriteLiteral("\n    })\r\n</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlogVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
