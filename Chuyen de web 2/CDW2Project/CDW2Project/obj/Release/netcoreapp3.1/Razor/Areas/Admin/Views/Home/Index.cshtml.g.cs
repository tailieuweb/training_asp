#pragma checksum "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0a908e5ab4d12f2c8ce94d9fb3f7ae20e64db77c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Home/Index.cshtml")]
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
#line 1 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\_ViewImports.cshtml"
using CDW2Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\_ViewImports.cshtml"
using CDW2Project.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\_ViewImports.cshtml"
using CDW2Project.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\_ViewImports.cshtml"
using DatabaseModel.CustomIdentityUser;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\_ViewImports.cshtml"
using ModelDatabase.EF;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\Home\Index.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\Home\Index.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\Home\Index.cshtml"
using X.PagedList.Mvc.Core.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a908e5ab4d12f2c8ce94d9fb3f7ae20e64db77c", @"/Areas/Admin/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee6a49f4c6b6f0325b8cb7ecd2e9b4a9e6b726ca", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IPagedList<DatabaseModel.CustomIdentityUser.UserAccount>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("search-frm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/emty_avatar.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "EditInfor", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/AdminHome/admin-page.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div id=""content"">
    <div class=""container"">
        <!-- Sidebar button -->
        <div class=""row content-bar d-flex align-items-center"">
            <button type=""button""
                    class=""btn btn-info btn-custom""
                    id=""sidebarCollapse"">
                <i class=""fas fa-bars""></i>
            </button>
            <div class=""title-page"">
                <h2>User list</h2>
            </div>
        </div>
        <!-- SEARCH -->
        <div class=""row search"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0a908e5ab4d12f2c8ce94d9fb3f7ae20e64db77c8863", async() => {
                WriteLiteral(@"
                <input type=""text""
                       placeholder=""Search...""
                       name=""search""
                       class=""search-frm-input"" />
                <button type=""submit"" class=""search-frm-btn btn btn-info"">
                    <i class=""fa fa-search""></i>
                </button>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
        <div class=""row"">
            <p class=""num-user"">69<span>&nbsp;uers</span></p>
        </div>
        <!-- TABLE LIST USER -->
        <div class=""row list-users"">
            <div class=""table-responsive"">
                <table class=""table t"">
                    <thead>
                        <tr class=""t-head"">
                            <th scope=""col"">#</th>
                            <th scope=""col"">Image</th>
                            <th scope=""col"">Name</th>
                            <th scope=""col"">Email</th>
                            <th scope=""col"">Action</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 52 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\Home\Index.cshtml"
                         for (int i = 0; i < Model.Count; i++)
                        {
                            int stt = i + 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <!-- Item -->\r\n                            <tr class=\"t-item\">\r\n                                <th scope=\"row\" class=\"align-middle text-center\">");
#nullable restore
#line 57 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\Home\Index.cshtml"
                                                                            Write(stt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                <td class=\"t-item-img align-middle\">\r\n");
#nullable restore
#line 59 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\Home\Index.cshtml"
                                     if (Model[i].Image != null)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0a908e5ab4d12f2c8ce94d9fb3f7ae20e64db77c13335", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2515, "~/User_Image/", 2515, 13, true);
#nullable restore
#line 61 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 2528, Model[i].Id, 2528, 12, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 2540, "/", 2540, 1, true);
#nullable restore
#line 61 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 2541, Model[i].Image, 2541, 15, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 62 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\Home\Index.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0a908e5ab4d12f2c8ce94d9fb3f7ae20e64db77c15601", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 66 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\Home\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </td>\r\n                                <td class=\"t-item-name align-middle\">");
#nullable restore
#line 68 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\Home\Index.cshtml"
                                                                Write(Model[i].FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"t-item-email align-middle\">\r\n                                    ");
#nullable restore
#line 70 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\Home\Index.cshtml"
                               Write(Model[i].Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td class=\"t-item-action align-middle\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0a908e5ab4d12f2c8ce94d9fb3f7ae20e64db77c17918", async() => {
                WriteLiteral("\r\n                                        <i class=\"fas fa-user-edit\"></i>\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 73 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\Home\Index.cshtml"
                                                                                     WriteLiteral(Model[i].Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    <a href=\"#\" id=\"del-user\" class=\"btn-delUser\"");
            BeginWriteAttribute("userId", " userId=\"", 3511, "\"", 3532, 1);
#nullable restore
#line 76 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\Home\Index.cshtml"
WriteAttributeValue("", 3520, Model[i].Id, 3520, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <i class=\"fas fa-user-times\"></i>\r\n                                    </a>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 81 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n        <!-- PAGINATION -->\r\n");
#nullable restore
#line 87 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\Home\Index.cshtml"
         if (Model != null)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 89 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\Home\Index.cshtml"
       Write(Html.PagedListPager((IPagedList)Model, page => Url.Action("Index", new { page = page, search = ViewBag.search }), new X.PagedList.Mvc.Core.Common.PagedListRenderOptions()
            {
                LiElementClasses = new[] { "page-item" },
                PageClasses = new[] { "page-link" },

                UlElementClasses = new[] { "pagination" },
                ContainerDivClasses = new[] { "Page navigation" },
                LinkToFirstPageFormat = "<<",
                LinkToLastPageFormat = ">>",
                MaximumPageNumbersToDisplay = 3,
            }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 99 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Areas\Admin\Views\Home\Index.cshtml"
              
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
</div>
<div class=""outSide-Frame"">
    <div class=""deletedMessage-box"">
        <div class=""title"">Message</div>
        <div class=""message"">Pls try again!</div>
        <div class=""notify__controls"">
            <button class=""btn -yes deletedMessage-btn"">
                <i class=""far fa-check-circle""></i>
            </button>
        </div>
    </div>
</div>
<!-- Notify -->
<div id=""hide-noti"">
    <div class=""modal"">
        <div class=""modal__overlay""></div>
        <div class=""modal__body"" id=""noti-content"">
            <div class=""notify"">
                <div class=""notify__icon"">
                    <lottie-player src=""https://assets6.lottiefiles.com/packages/lf20_Tkwjw8.json""
                                   background=""transparent""
                                   speed=""1""
                                   style=""width: 150px; height: 150px""
                                   class=""notify__icon-lp""
                                   loop
               ");
            WriteLiteral(@"                    autoplay></lottie-player>
                </div>
                <div class=""notify__content"">
                    <h3 class=""-heading"">Are you sure?</h3>
                    <div class=""-text"">You won't be able to revert this!</div>
                </div>
                <div class=""notify__controls"">
                    <button class=""btn -yes btnYes"">
                        <i class=""far fa-check-circle""></i>
                    </button>
                    <button class=""btn -cancel"" id=""cancel-btn"">
                        <i class=""far fa-times-circle""></i>
                    </button>
                </div>
            </div>
        </div>
    </div>
</div>
");
            DefineSection("AdminHome", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0a908e5ab4d12f2c8ce94d9fb3f7ae20e64db77c24875", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IPagedList<DatabaseModel.CustomIdentityUser.UserAccount>> Html { get; private set; }
    }
}
#pragma warning restore 1591
