#pragma checksum "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4cc7089ae3ed3bd344c79b491b5b35b95933874a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Index), @"mvc.1.0.view", @"/Views/Product/Index.cshtml")]
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
#line 1 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\_ViewImports.cshtml"
using HaiSan;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\_ViewImports.cshtml"
using HaiSan.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4cc7089ae3ed3bd344c79b491b5b35b95933874a", @"/Views/Product/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65ac9318954244554f7f38e524e4bfb3e204f6b0", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HaiSan.Ulti.PaginatedList<HaiSan.Models.Pure.Sanpham>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
  
    var cate = ViewData["Category"] as String;
    List<HaiSan.Models.Pure.Loaisp> list = ViewData["Categories"] as List<HaiSan.Models.Pure.Loaisp>;


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"container py-5\">\r\n    <div class=\"row\">\r\n\r\n        <div class=\"col-lg-3\">\r\n            <h1 class=\"h2 pb-4\">Categories</h1>\r\n            <div class=\"list-group mb-2\">\r\n");
#nullable restore
#line 15 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
                 if (cate.ToLower() == "all")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a");
            BeginWriteAttribute("href", " href=\"", 494, "\"", 543, 2);
            WriteAttributeValue("", 501, "/products/all?page=1&limit=", 501, 27, true);
#nullable restore
#line 17 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
WriteAttributeValue("", 528, Model.PageSize, 528, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"list-group-item list-group-item-action list-group-item-success active\">T???t c???</a>\r\n");
#nullable restore
#line 18 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a");
            BeginWriteAttribute("href", " href=\"", 717, "\"", 766, 2);
            WriteAttributeValue("", 724, "/products/all?page=1&limit=", 724, 27, true);
#nullable restore
#line 21 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
WriteAttributeValue("", 751, Model.PageSize, 751, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"list-group-item list-group-item-action list-group-item-success\">T???t c???</a>\r\n");
#nullable restore
#line 22 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 24 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
                 foreach (var e in list)
                {
                    if (e.Maloai == cate)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a");
            BeginWriteAttribute("href", " href=\"", 1025, "\"", 1080, 4);
            WriteAttributeValue("", 1032, "/products/", 1032, 10, true);
#nullable restore
#line 28 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
WriteAttributeValue("", 1042, e.Maloai, 1042, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1051, "?page=1&limit=", 1051, 14, true);
#nullable restore
#line 28 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
WriteAttributeValue("", 1065, Model.PageSize, 1065, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"list-group-item list-group-item-action list-group-item-success active\">");
#nullable restore
#line 28 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
                                                                                                                                                            Write(e.TenLoai);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 29 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a");
            BeginWriteAttribute("href", " href=\"", 1274, "\"", 1329, 4);
            WriteAttributeValue("", 1281, "/products/", 1281, 10, true);
#nullable restore
#line 32 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
WriteAttributeValue("", 1291, e.Maloai, 1291, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1300, "?page=1&limit=", 1300, 14, true);
#nullable restore
#line 32 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
WriteAttributeValue("", 1314, Model.PageSize, 1314, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"list-group-item list-group-item-action list-group-item-success\">");
#nullable restore
#line 32 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
                                                                                                                                                     Write(e.TenLoai);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 33 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n\r\n        <div class=\"col-lg-9\">\r\n            <div class=\"row\">\r\n                <div class=\"col-md-8\">\r\n                </div>\r\n                <div class=\"col-md-4 pb-4\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4cc7089ae3ed3bd344c79b491b5b35b95933874a9648", async() => {
                WriteLiteral("\r\n                        <div class=\"d-flex\">\r\n                            <select name=\"limit\" class=\"form-select text-center\">\r\n");
#nullable restore
#line 46 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
                                  
                                    int[] arr = { 15, 20, 25 };
                                    foreach (var e in arr)
                                    {
                                        if (e == Model.PageSize)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4cc7089ae3ed3bd344c79b491b5b35b95933874a10599", async() => {
#nullable restore
#line 52 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
                                                                   Write(e);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 52 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
                                               WriteLiteral(e);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 53 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4cc7089ae3ed3bd344c79b491b5b35b95933874a13202", async() => {
#nullable restore
#line 56 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
                                                          Write(e);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 56 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
                                               WriteLiteral(e);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 57 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
                                        }
                                    }
                                

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            </select>
                            <div>
                                <input hidden name=""page"" value=""1"" />
                                <input class=""btn btn-success"" value=""??p d???ng"" type=""submit"">
                            </div>
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 43 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
AddHtmlAttributeValue("", 1704, cate, 1704, 5, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"row\">\r\n");
#nullable restore
#line 70 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
                 foreach (var e in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-md-4\">\r\n                        <div class=\"card mb-4 product-wap rounded-0\">\r\n                            <div class=\"card rounded-0\">\r\n                                <img class=\"card-img rounded-0 img-fluid\"");
            BeginWriteAttribute("src", " src=\"", 3295, "\"", 3319, 2);
            WriteAttributeValue("", 3301, "/assets/img/", 3301, 12, true);
#nullable restore
#line 75 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
WriteAttributeValue("", 3313, e.Img, 3313, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                <div class=""card-img-overlay rounded-0 product-overlay d-flex align-items-center justify-content-center"">
                                    <ul class=""list-unstyled"">
                                        <li><a class=""btn btn-success text-white mt-2""");
            BeginWriteAttribute("href", " href=\"", 3612, "\"", 3650, 2);
            WriteAttributeValue("", 3619, "/products/detail?prodId=", 3619, 24, true);
#nullable restore
#line 78 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
WriteAttributeValue("", 3643, e.MaSp, 3643, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"far fa-eye\"></i></a></li>\r\n                                        <li><button class=\"btn btn-success text-white mt-2\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3780, "\"", 3811, 4);
            WriteAttributeValue("", 3790, "addCart(\'", 3790, 9, true);
#nullable restore
#line 79 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
WriteAttributeValue("", 3799, e.MaSp, 3799, 7, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3806, "\',", 3806, 2, true);
            WriteAttributeValue(" ", 3808, "1)", 3809, 3, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-cart-plus\"></i></button></li>\r\n                                    </ul>\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"card-body\">\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 4067, "\"", 4105, 2);
            WriteAttributeValue("", 4074, "/products/detail?prodId=", 4074, 24, true);
#nullable restore
#line 84 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
WriteAttributeValue("", 4098, e.MaSp, 4098, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"h3 text-decoration-none\">");
#nullable restore
#line 84 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
                                                                                                     Write(e.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                                <ul class=""w-100 list-unstyled d-flex justify-content-between mb-0"">
                                    <li class=""pt-2"">
                                        <span class=""product-color-dot color-dot-red float-left rounded-circle ml-1""></span>
                                        <span class=""product-color-dot color-dot-blue float-left rounded-circle ml-1""></span>
                                        <span class=""product-color-dot color-dot-black float-left rounded-circle ml-1""></span>
                                        <span class=""product-color-dot color-dot-light float-left rounded-circle ml-1""></span>
                                        <span class=""product-color-dot color-dot-green float-left rounded-circle ml-1""></span>
                                    </li>
                                </ul>
                                <p class=""text-center mb-0"">");
#nullable restore
#line 94 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
                                                       Write(e.Gia.ToString("0,0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ??</p>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 98 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div div=\"row\">\r\n                <p>Have ");
#nullable restore
#line 102 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
                   Write(Model.TotalPages);

#line default
#line hidden
#nullable disable
            WriteLiteral(" page here!</p>\r\n                <ul class=\"pagination pagination-lg justify-content-end\">\r\n");
#nullable restore
#line 104 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
                     if (Model.HasPreviousPage)
                    {
                        var pre = Model.PageIndex - 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"page-item\">\r\n                            <a class=\"page-link rounded-0 mr-3 shadow-sm border-top-0 border-left-0\"");
            BeginWriteAttribute("href", " href=\"", 5694, "\"", 5748, 6);
            WriteAttributeValue("", 5701, "/products/", 5701, 10, true);
#nullable restore
#line 108 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
WriteAttributeValue("", 5711, cate, 5711, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5716, "?page=", 5716, 6, true);
#nullable restore
#line 108 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
WriteAttributeValue("", 5722, pre, 5722, 4, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5726, "&limit=", 5726, 7, true);
#nullable restore
#line 108 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
WriteAttributeValue("", 5733, Model.PageSize, 5733, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-chevron-left\"></i></a>\r\n                        </li>\r\n");
#nullable restore
#line 110 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <li class=\"page-item disabled\">\r\n                        <a class=\"page-link active rounded-0 mr-3 shadow-sm border-top-0 border-left-0\" href=\"#\" tabindex=\"-1\">");
#nullable restore
#line 113 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
                                                                                                                          Write(Model.PageIndex);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </li>\r\n\r\n");
#nullable restore
#line 116 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
                     if (Model.HasNextPage)
                    {
                        var next = Model.PageIndex + 1;
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"page-item\">\r\n                            <a class=\"page-link rounded-0 mr-3 shadow-sm border-top-0 border-left-0\"");
            BeginWriteAttribute("href", " href=\"", 6377, "\"", 6432, 6);
            WriteAttributeValue("", 6384, "/products/", 6384, 10, true);
#nullable restore
#line 121 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
WriteAttributeValue("", 6394, cate, 6394, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6399, "?page=", 6399, 6, true);
#nullable restore
#line 121 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
WriteAttributeValue("", 6405, next, 6405, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6410, "&limit=", 6410, 7, true);
#nullable restore
#line 121 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
WriteAttributeValue("", 6417, Model.PageSize, 6417, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-chevron-right\"></i></a>\r\n                        </li>\r\n");
#nullable restore
#line 123 "C:\Users\Admin\Documents\HaiSan_Jay\DoAnWeb\HaiSan\HaiSan\Views\Product\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n            </div>\r\n        </div>\r\n\r\n    </div>\r\n</div>\r\n<!-- End Content -->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HaiSan.Ulti.PaginatedList<HaiSan.Models.Pure.Sanpham>> Html { get; private set; }
    }
}
#pragma warning restore 1591
