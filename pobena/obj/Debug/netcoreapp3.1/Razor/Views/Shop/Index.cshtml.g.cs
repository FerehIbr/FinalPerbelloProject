#pragma checksum "C:\Users\farahei\Desktop\forfarah\pobena\Views\Shop\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b7121b500277b80fb2fd81442cd04ecd4c7218f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shop_Index), @"mvc.1.0.view", @"/Views/Shop/Index.cshtml")]
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
#line 2 "C:\Users\farahei\Desktop\forfarah\pobena\Views\_ViewImports.cshtml"
using pobena.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\farahei\Desktop\forfarah\pobena\Views\_ViewImports.cshtml"
using pobena.ViewModels.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\farahei\Desktop\forfarah\pobena\Views\_ViewImports.cshtml"
using pobena.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\farahei\Desktop\forfarah\pobena\Views\_ViewImports.cshtml"
using pobena.ViewModels.Basket;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\farahei\Desktop\forfarah\pobena\Views\_ViewImports.cshtml"
using pobena.ViewModels.Home;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\farahei\Desktop\forfarah\pobena\Views\_ViewImports.cshtml"
using pobena.ViewModels.Blog;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\farahei\Desktop\forfarah\pobena\Views\_ViewImports.cshtml"
using pobena.ViewModels.Shop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\farahei\Desktop\forfarah\pobena\Views\_ViewImports.cshtml"
using pobena.ViewModels.Order;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\farahei\Desktop\forfarah\pobena\Views\_ViewImports.cshtml"
using pobena.ViewModels.Contact;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b7121b500277b80fb2fd81442cd04ecd4c7218f", @"/Views/Shop/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b94d712f200f137f77745818bd32c2b7e72680b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shop_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShopVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "3", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "4", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "5", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "6", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "7", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "shop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "filter", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("shopFilter category"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("shopFilter brand"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("shopFilter color"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""breadcrumb-section bgc-offset mb-full"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-12 col-sm-12 col-md-12"">
                <nav class=""breadcrumb"">
                    <a class=""breadcrumb-item"" href=""index.html"">Home</a>
                    <span class=""breadcrumb-item active"">Shop</span>
                </nav>
            </div>
        </div>
    </div> 
</div>
<div id=""content"" class=""main-content-wrapper"">

    <div class=""products-wrapper"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-12 col-sm-12 col-md-12 col-lg-9 order-1 order-md-1 order-lg-2"">
                    <main id=""primary"" class=""site-main"">
                        <div class=""shop-wrapper"">
                            <div class=""row"">
                                <div class=""col-12 col-sm-12 col-md-12"">
                                    <h1>Shop</h1>
                                    <div class=""shop-toolbar"">");
            WriteLiteral(@"
                                        <div class=""toolbar-inner"">
                                            <div class=""product-view-mode"">
                                                <ul role=""tablist"" class=""nav shop-item-filter-list"">
                                                    <li role=""presentation"" class=""active""><a href=""#grid"" aria-controls=""grid"" role=""tab"" data-bs-toggle=""tab"" class=""active show"" aria-selected=""true""><i class=""ion-md-grid""></i></a></li>
                                                    <li role=""presentation""><a href=""#list"" aria-controls=""list"" role=""tab"" data-bs-toggle=""tab""><i class=""ion-md-list""></i></a></li>
                                                </ul>
                                            </div>
                                            <div class=""toolbar-amount"">
                                                <span>Showing 10 to 18 of 27</span>
                                            </div>
                                 ");
            WriteLiteral(@"       </div>
                                        <div class=""product-select-box"">
                                            <div class=""product-sort"">
                                                <p>Sort By:</p>
                                                <select class=""selectfilter sortby"" name=""sortby"">
                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b7121b500277b80fb2fd81442cd04ecd4c7218f10699", async() => {
                WriteLiteral("Relevance");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b7121b500277b80fb2fd81442cd04ecd4c7218f11914", async() => {
                WriteLiteral("Name (A - Z)");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b7121b500277b80fb2fd81442cd04ecd4c7218f13443", async() => {
                WriteLiteral("Name (Z - A)");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b7121b500277b80fb2fd81442cd04ecd4c7218f14661", async() => {
                WriteLiteral("Price (Low > High)");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b7121b500277b80fb2fd81442cd04ecd4c7218f15885", async() => {
                WriteLiteral("Rating (Lowest)");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b7121b500277b80fb2fd81442cd04ecd4c7218f17106", async() => {
                WriteLiteral("Model (A - Z)");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b7121b500277b80fb2fd81442cd04ecd4c7218f18325", async() => {
                WriteLiteral("Model (Z - A)");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div> 
                            <div class=""row"">
                                <div class=""col-12 col-sm-12 col-md-12"">
                                    <div class=""shop-products-wrapper"">
                                        <div class=""tab-content"">
                                            <div id=""grid"" class=""tab-pane anime-tab active show"" role=""tabpanel"">
                                                <div class=""row shop-products2"">
                                                    ");
#nullable restore
#line 60 "C:\Users\farahei\Desktop\forfarah\pobena\Views\Shop\Index.cshtml"
                                               Write(await Html.PartialAsync("_ShopProductListPartial2", Model.Products));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                                </div>
                                            </div>
                                            <div id=""list"" class=""tab-pane anime-tab"" role=""tabpanel"">
                                                <div class=""row"">
                                                    <div class=""col-12 col-sm-12 col-md-12 shop-products"">
                                                        ");
#nullable restore
#line 67 "C:\Users\farahei\Desktop\forfarah\pobena\Views\Shop\Index.cshtml"
                                                   Write(await Html.PartialAsync("_ShopProductListPartial",Model.Products));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                       


                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div> 
                                    <div class=""pagination-area"">
                                        <div class=""row align-items-center"">
                                            <div class=""col-12 order-2 col-sm-12 col-md-6 order-md-1 col-lg-6"">
                                                <div class=""page-amount d-flex justify-content-center justify-content-md-start"">
                                                    <p>Showing 10 to 18 of 27 (3 Pages)</p>
                                                </div>
                                            </div>
                                            <div class=""col-12 order-1 col-sm-12 col-md-6 order-md-2 col-lg-6"">");
            WriteLiteral(@"
                                                <ul class=""pagination"">
                                                    <li class=""page-item""><a href=""#"" class=""page-link""><i class=""fa fa-angle-left""></i> <span>Previous</span></a></li>
                                                    <li class=""page-item""><a href=""#"" class=""page-link"">1</a></li>
                                                    <li class=""page-item active""><span class=""page-link"">2</span></li>
                                                    <li class=""page-item""><a href=""#"" class=""page-link"">3</a></li>
                                                    <li class=""page-item""><a href=""#"" class=""page-link""><span>Next</span> <i class=""fa fa-angle-right""></i></a></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div> 
                                </div>
                      ");
            WriteLiteral(@"      </div> 
                        </div> 
                    </main> 
                </div>
                <div class=""col-12 col-sm-12 col-md-12 col-lg-3 order-2 order-md-2 order-lg-1"">
                    <aside id=""secondary"" class=""widget-area"">
                        <div class=""sidebar-widget list-widget"">
                            <h2 class=""widgettitle"">Categories</h2>
                            <div class=""list-widget-wrapper"">
                                <div class=""list-group"">
");
#nullable restore
#line 105 "C:\Users\farahei\Desktop\forfarah\pobena\Views\Shop\Index.cshtml"
                                     foreach (Category item in ViewBag.Categories)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b7121b500277b80fb2fd81442cd04ecd4c7218f24391", async() => {
#nullable restore
#line 107 "C:\Users\farahei\Desktop\forfarah\pobena\Views\Shop\Index.cshtml"
                                                                                                                               Write(item.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 107 "C:\Users\farahei\Desktop\forfarah\pobena\Views\Shop\Index.cshtml"
                                                                                         Write(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-id", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 108 "C:\Users\farahei\Desktop\forfarah\pobena\Views\Shop\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </div>
                            </div>
                        </div> 
                        <div class=""sidebar-widget list-widget"">
                            <h2 class=""widgettitle"">Brands</h2>
                            <div class=""list-widget-wrapper"">
                                <div class=""list-group"">
");
#nullable restore
#line 117 "C:\Users\farahei\Desktop\forfarah\pobena\Views\Shop\Index.cshtml"
                                     foreach (Brand item in ViewBag.Brands)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b7121b500277b80fb2fd81442cd04ecd4c7218f27577", async() => {
#nullable restore
#line 119 "C:\Users\farahei\Desktop\forfarah\pobena\Views\Shop\Index.cshtml"
                                                                                                                            Write(item.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 119 "C:\Users\farahei\Desktop\forfarah\pobena\Views\Shop\Index.cshtml"
                                                                                         Write(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-id", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 120 "C:\Users\farahei\Desktop\forfarah\pobena\Views\Shop\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </div>
                            </div>
                        </div> 
                        <div class=""sidebar-widget list-widget"">
                            <h2 class=""widgettitle"">Price</h2>
                            <div class=""list-widget-wrapper"">
                                <div class=""list-group"">
                                    <a href=""#"" data-id=""1"" class=""shopFilter price"">$43.00 - $45.00 (10)</a>
                                    <a href=""#"" data-id=""2"" class=""shopFilter price"">$54.00 - $58.00 (4)</a>
                                    <a href=""#"" data-id=""3"" class=""shopFilter price"">$62.00 - $70.00 (5)</a>
                                    <a href=""#"" data-id=""4"" class=""shopFilter price"">$78.00 - $83.00 (10)</a>
                                    <a href=""#"" data-id=""5"" class=""shopFilter price"">$85.00 - $89.00 (13)</a>
                                </div>
                            </div>
                        </div>
   ");
            WriteLiteral("                     <div class=\"sidebar-widget color-widget\">\r\n                            <h2 class=\"widgettitle\">Color</h2>\r\n                            <div class=\"color-widget-wrapper\">\r\n                                <ul class=\"color-options\">\r\n");
#nullable restore
#line 140 "C:\Users\farahei\Desktop\forfarah\pobena\Views\Shop\Index.cshtml"
                                     foreach (Color item in ViewBag.Colors)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li>\r\n                                            <span");
            BeginWriteAttribute("class", " class=\"", 9460, "\"", 9478, 1);
#nullable restore
#line 143 "C:\Users\farahei\Desktop\forfarah\pobena\Views\Shop\Index.cshtml"
WriteAttributeValue("", 9468, item.Name, 9468, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></span>\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b7121b500277b80fb2fd81442cd04ecd4c7218f32213", async() => {
#nullable restore
#line 144 "C:\Users\farahei\Desktop\forfarah\pobena\Views\Shop\Index.cshtml"
                                                                                                                                Write(item.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 144 "C:\Users\farahei\Desktop\forfarah\pobena\Views\Shop\Index.cshtml"
                                                                                             Write(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-id", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </li>\r\n");
#nullable restore
#line 146 "C:\Users\farahei\Desktop\forfarah\pobena\Views\Shop\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </ul>\r\n                            </div>\r\n                        </div>\r\n                     \r\n                    </aside> \r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShopVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
