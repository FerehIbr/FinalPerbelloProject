#pragma checksum "C:\Users\farahei\Desktop\forfarah\pobena\Views\Order\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "478080768c3e2984c379769329d76c0dfbd1feb4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Create), @"mvc.1.0.view", @"/Views/Order/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"478080768c3e2984c379769329d76c0dfbd1feb4", @"/Views/Order/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7cbf643bf37996a909214e29964000d38761a808", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OrderVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\farahei\Desktop\forfarah\pobena\Views\Order\Create.cshtml"
   ViewData["Title"] = "Create"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("<section class=\"about\">\r\n    <div class=\"about-text\">\r\n        <h1>Account</h1>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 145, "\"", 152, 0);
            EndWriteAttribute();
            WriteLiteral(@">Home </a>
        <i class=""fa-solid fa-angle-right""></i>
        <span>Account</span>
    </div>
</section>
<section class=""checkdetail"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-6"">
                <div class=""billing"">
                    <h3>Billing Details</h3>
                    <hr>
                    ");
#nullable restore
#line 19 "C:\Users\farahei\Desktop\forfarah\pobena\Views\Order\Create.cshtml"
               Write(await Html.PartialAsync("_OrderPartial", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
            </div>
            <div class=""col-lg-6"">
                <div class=""orderdetail"">
                    <h3>Your Order Summary</h3>
                    <hr>
                    <div class=""order-summary-content"">
                   
                        <div class=""order-summary-table table-responsive text-center"">
                            <table class=""table table-bordered"">
                                <thead>
                                    <tr>
                                        <th>Products</th>
                                        <th>SubTotal</th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 37 "C:\Users\farahei\Desktop\forfarah\pobena\Views\Order\Create.cshtml"
                                     foreach (var item in ViewBag.Basket)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td>\r\n                                                <a href=\"product-details.html\">");
#nullable restore
#line 41 "C:\Users\farahei\Desktop\forfarah\pobena\Views\Order\Create.cshtml"
                                                                          Write(item.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("<strong> × ");
#nullable restore
#line 41 "C:\Users\farahei\Desktop\forfarah\pobena\Views\Order\Create.cshtml"
                                                                                                       Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></a>\r\n                                            </td>\r\n                                            <td>$");
#nullable restore
#line 43 "C:\Users\farahei\Desktop\forfarah\pobena\Views\Order\Create.cshtml"
                                             Write(item.Product.Price * item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                        </tr>\r\n");
#nullable restore
#line 45 "C:\Users\farahei\Desktop\forfarah\pobena\Views\Order\Create.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </tbody>\r\n                                <tfoot>\r\n\r\n\r\n                                    <tr>\r\n                                        <td>Grand Total Amount</td>\r\n                                        <td><strong>$");
#nullable restore
#line 52 "C:\Users\farahei\Desktop\forfarah\pobena\Views\Order\Create.cshtml"
                                                 Write(ViewBag.Total);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</strong></td>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
                        
                        <div class=""order-payment-method"">
                            <div class=""single-payment-method show"">
                                <div class=""payment-method-name"">
                                    <div class=""custom-control custom-radio"">
                                        <input type=""radio"" id=""cashon"" name=""paymentmethod"" value=""cash"" class=""custom-control-input"" checked />
                                        <label class=""custom-control-label"" for=""cashon"">Cash On Delivery</label>
                                    </div>
                                </div>
                                <div class=""payment-method-details"" data-method=""cash"">
                                    <p>Pay with cash upon delivery.</p>
                                </div>
   ");
            WriteLiteral(@"                         </div>
                            <div class=""single-payment-method"">
                                <div class=""payment-method-name"">
                                    <div class=""custom-control custom-radio"">
                                        <input type=""radio"" id=""directbank"" name=""paymentmethod"" value=""bank"" class=""custom-control-input"" />
                                        <label class=""custom-control-label"" for=""directbank"">
                                            Direct Bank
                                            Transfer
                                        </label>
                                    </div>
                                </div>
                                <div class=""payment-method-details"" data-method=""bank"">
                                    <p>
                                        Make your payment directly into our bank account. Please use your Order
                                        ID as the paym");
            WriteLiteral(@"ent reference. Your order will not be shipped until the
                                        funds have cleared in our account..
                                    </p>
                                </div>
                            </div>
                            <div class=""single-payment-method"">
                                <div class=""payment-method-name"">
                                    <div class=""custom-control custom-radio"">
                                        <input type=""radio"" id=""checkpayment"" name=""paymentmethod"" value=""check"" class=""custom-control-input"" />
                                        <label class=""custom-control-label"" for=""checkpayment"">
                                            Pay with
                                            Check
                                        </label>
                                    </div>
                                </div>
                                <div class=""payment-method-details"" data-method");
            WriteLiteral(@"=""check"">
                                    <p>
                                        Please send a check to Store Name, Store Street, Store Town, Store State
                                        / County, Store Postcode.
                                    </p>
                                </div>
                            </div>
                            <div class=""single-payment-method"">
                                <div class=""payment-method-name"">
                                    <div class=""custom-control custom-radio"">
                                        <input type=""radio"" id=""paypalpayment"" name=""paymentmethod"" value=""paypal"" class=""custom-control-input"" />
                                        <label class=""custom-control-label"" for=""paypalpayment"">Paypal <img src=""assets/img/paypal-card.jpg"" class=""img-fluid paypal-card"" alt=""Paypal"" /></label>
                                    </div>
                                </div>
                                <d");
            WriteLiteral(@"iv class=""payment-method-details"" data-method=""paypal"">
                                    <p>
                                        Pay via PayPal; you can pay with your credit card if you don’t have a
                                        PayPal account.
                                    </p>
                                </div>
                            </div>
                            <div class=""summary-footer-area"">
                                <div class=""custom-control custom-checkbox mb-20"">
                                    <input type=""checkbox"" class=""custom-control-input"" id=""terms"" required />
                                    <label class=""custom-control-label"" for=""terms"">
                                        I have read and agree to
                                        the website <a href=""index.html"">terms and conditions.</a>
                                    </label>
                                </div>
                            </div>
       ");
            WriteLiteral("                 </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrderVM> Html { get; private set; }
    }
}
#pragma warning restore 1591