#pragma checksum "C:\Users\user\Desktop\FinalPobenaProject\pobena\Views\Account\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5801d7cb6274b942dbaf532a4af21dad21f5eecc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Register), @"mvc.1.0.view", @"/Views/Account/Register.cshtml")]
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
#line 2 "C:\Users\user\Desktop\FinalPobenaProject\pobena\Views\_ViewImports.cshtml"
using pobena.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\user\Desktop\FinalPobenaProject\pobena\Views\_ViewImports.cshtml"
using pobena.ViewModels.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\user\Desktop\FinalPobenaProject\pobena\Views\_ViewImports.cshtml"
using pobena.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\user\Desktop\FinalPobenaProject\pobena\Views\_ViewImports.cshtml"
using pobena.ViewModels.Basket;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\user\Desktop\FinalPobenaProject\pobena\Views\_ViewImports.cshtml"
using pobena.ViewModels.Home;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\user\Desktop\FinalPobenaProject\pobena\Views\_ViewImports.cshtml"
using pobena.ViewModels.Blog;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5801d7cb6274b942dbaf532a4af21dad21f5eecc", @"/Views/Account/Register.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"529dfbb47be17281f3dea62402bd0c26a28e3dfc", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Register : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RegisterVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\user\Desktop\FinalPobenaProject\pobena\Views\Account\Register.cshtml"
  
    ViewData["Title"] = "Register";
    
  

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""breadcrumb-section bgc-offset mb-full"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-12 col-sm-12 col-md-12"">
                <nav class=""breadcrumb"">
                    <a class=""breadcrumb-item"" href=""index.html"">Home</a>
                    <span class=""breadcrumb-item active"">Register</span>
                </nav>
            </div>
        </div>
    </div>
</div>

<div id=""content"" class=""main-content-wrapper"">

    <div class=""login-wrapper"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-12 col-sm-12 col-md-12 col-lg-12"">
                    <main id=""primary"" class=""site-main"">
                        <div class=""user-login"">
                            <div class=""row"">
                                <div class=""col-12 col-sm-12 col-md-12"">
                                    <div class=""section-title"">
                                        <h2>Create an Account</h2>
       ");
            WriteLiteral(@"                             </div>
                                </div>
                            </div>

                            <div class=""row"">
                                <div class=""col-12 col-sm-12 col-md-12 col-lg-12 col-xl-8 offset-xl-2"">
                                    <div class=""registration-form login-form"">
                                        ");
#nullable restore
#line 39 "C:\Users\user\Desktop\FinalPobenaProject\pobena\Views\Account\Register.cshtml"
                                   Write(await Html.PartialAsync("_RegisterIndexPartial", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    </div>
                                </div>
                            </div>
                        </div>
                    </main>
                </div>
            </div>
        </div>
    </div>

</div>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RegisterVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
