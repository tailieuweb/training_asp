#pragma checksum "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ffede0d176992da44df47cc8f8ff6b6dd404e5cc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\_ViewImports.cshtml"
using CDW2Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\_ViewImports.cshtml"
using CDW2Project.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffede0d176992da44df47cc8f8ff6b6dd404e5cc", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14d9eac1b0908c07afe0ed72a7a27fb4196cad9c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TypeAndArticleList>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "WatchArticle", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Home/Home.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!-- Banner -->\r\n<div class=\"banner\">\r\n    <!-- Banner Left-->\r\n");
#nullable restore
#line 9 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
     if (Model.articles.Any())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""banner__left"">
            <!-- Banner Left Box-->
            <div class=""banner__left__box"">
                <!-- Banner Left Box Img-->
                <div class=""banner__left__box__img"">
                    <a href=""#"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ffede0d176992da44df47cc8f8ff6b6dd404e5cc5394", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 503, "~/Article_Image/", 503, 16, true);
#nullable restore
#line 17 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 519, Model.articles[0].AriticleId, 519, 29, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 548, "/", 548, 1, true);
#nullable restore
#line 17 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 549, Model.articles[0].Avatar, 549, 25, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </a>\r\n                </div>\r\n                <!-- Banner Left Box Link-->\r\n                <div class=\"banner__left__box__link\">\r\n                    <a href=\"#\">\r\n");
#nullable restore
#line 23 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
                         if (Model.articles[0].ArticleType != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div style=\"display:flex;align-items:center;\">\r\n                                ");
#nullable restore
#line 26 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
                           Write(Html.Raw(Model.articles[0].ArticleType.image));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                <h4 style=\"margin: 0; margin-left: 8px;\">");
#nullable restore
#line 27 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
                                                                    Write(Model.articles[0].ArticleType.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                            </div>\r\n");
#nullable restore
#line 29 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </a>\r\n                </div>\r\n                <!-- Banner Left Box Title-->\r\n                <div class=\"banner__left__box__title\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ffede0d176992da44df47cc8f8ff6b6dd404e5cc9014", async() => {
                WriteLiteral("\r\n                        <h2>");
#nullable restore
#line 35 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
                       Write(Model.articles[0].Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 34 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
                                                                          WriteLiteral(Model.articles[0].AriticleId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
                <!-- Banner Left Box Content-->
                <div class=""banner__left__box__content"">
                    <p></p>
                </div>
                <!-- Banner Left Box Read-->
                <div class=""banner__left__box__read"">
                    <div class=""banner__left__box__read__more"">
                        <a href=""#"">
                            <h4>Published</h4>
                        </a>
                    </div>
                    <div class=""banner__left__box__read__cham"">
                        <span>.</span>
                    </div>
                    <div class=""banner__left__box__read__minute"">
                        <span>");
#nullable restore
#line 53 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
                         Write(DateTime.Parse(@Model.articles[0].Date.ToString()).ToString("dddd, dd MMMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                    </div>
                </div>
                <!-- Banner Left Box Like -->
                <div class=""banner__left__box__like"">
                    <span class=""thumb thumbs-up""><i class=""fas fa-sign-language""></i></span>
                    <p>");
#nullable restore
#line 59 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
                  Write(Model.articles[0].Like);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
            </div><!-- Banner Left Box-->
        </div><!-- Banner Left-->
        <!-- Banner Middle-->
        <div class=""banner__middle"">
            <!-- Banner Middle Box -->
            <div class=""banner__middle__box"">
                <!-- Banner Middle Box Item-->
");
#nullable restore
#line 68 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
                 for (int i = 1; i < Model.articles.Count; i++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""banner__middle__box__item"">
                        <!-- Banner Middle Box Item Left-->
                        <div class=""banner__middle__box__item__left"">
                            <!-- Banner Middle Box Item Left Link-->
                            <div class=""banner__middle__box__item__left__link"">
");
#nullable restore
#line 75 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
                                 if (Model.articles[i].ArticleType != null)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div style=\"display:flex;align-items:center;\">\r\n                                        ");
#nullable restore
#line 78 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
                                   Write(Html.Raw(Model.articles[i].ArticleType.image));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        <h4 style=\"margin: 0; margin-left: 8px;\">");
#nullable restore
#line 79 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
                                                                            Write(Model.articles[i].ArticleType.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                    </div>\r\n");
#nullable restore
#line 81 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                            <!-- Banner Middle Box Item Left Title-->\r\n                            <div class=\"banner__middle__box__item__left__title\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ffede0d176992da44df47cc8f8ff6b6dd404e5cc15918", async() => {
                WriteLiteral("\r\n                                    <h2>");
#nullable restore
#line 86 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
                                   Write(Model.articles[i].Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 85 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
                                                                                      WriteLiteral(Model.articles[i].AriticleId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </div>
                            <!-- Banner Middle Box Item Left Day-->
                            <div class=""banner__middle__box__item__left__day"">
                                <div class=""banner__middle__box__item__left__day__month"">
                                    <h4>Published</h4>
                                </div>
                                <div class=""banner__middle__box__item__left__day__cham"">
                                    <span>.</span>
                                </div>
                                <div class=""banner__middle__box__item__left__day__minute"">
                                    <span>");
#nullable restore
#line 98 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
                                     Write(DateTime.Parse(@Model.articles[i].Date.ToString()).ToString("dddd, dd MMMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                </div>
                            </div>
                            <!-- Banner Middle Box Item Left Like -->
                            <div class=""banner__middle__box__item__left__like"">
                                <span class=""thumb thumbs-up""><i class=""fas fa-sign-language""></i></span>
                                <p>");
#nullable restore
#line 104 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
                              Write(Model.articles[i].Like);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            </div>
                        </div><!-- Banner Middle Box Item Left -->
                        <!-- Banner Middle Box Item Right -->
                        <div class=""banner__middle__box__item__right"">
                            <a href=""#"">
");
#nullable restore
#line 110 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
                                 if (Model.articles[i].Avatar != null)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ffede0d176992da44df47cc8f8ff6b6dd404e5cc20994", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 5934, "~/Article_Image/", 5934, 16, true);
#nullable restore
#line 112 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 5950, Model.articles[i].AriticleId, 5950, 29, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 5979, "/", 5979, 1, true);
#nullable restore
#line 112 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 5980, Model.articles[i].Avatar, 5980, 25, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 113 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </a>\r\n                        </div><!-- Banner Middle Box Item Right-->\r\n                    </div><!-- Banner Middle Box Item-->\r\n");
#nullable restore
#line 117 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div><!-- Banner Middle Box-->\r\n        </div><!-- Banner Middle-->\r\n");
#nullable restore
#line 120 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <!-- Banner Right-->
    <div class=""banner__right"">
        <!-- Banner Right Box -->
        <div class=""banner__right__box"">
            <p>New Member</p>
            <div class=""banner__right__box__all scrollbar"" id=""style-1"">
            </div>
            <span id=""btn_Show_User"" class=""buttonMore"">See More</span>
        </div><!-- Banner Right Box-->
    </div><!-- Banner Right-->
</div><!-- Banner -->
<!-- New -->
<div class=""new"">
    <!-- New Left -->
    <div class=""new__left"">
        <!-- New Left Box -->
        <div class=""new__left__box"">
        </div><!-- New Left Box -->
    </div><!-- New Left -->
    <!-- New Right -->
    <div class=""new__right"">
        <div class=""formSearch"">
            <span class=""searchName"">
                Tìm kiếm <i class=""fas fa-search""></i> :
            </span>
            <div class=""boxSearching"">
                <input type=""text"" name=""searchData"" id=""searchData"" class=""boxSearching__form"" placeholder=""Search"" />
        ");
            WriteLiteral("    </div>\r\n        </div>\r\n        <div class=\"new__right__box\">\r\n");
#nullable restore
#line 151 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
             if (Model.articleTypes.Any())
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 153 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
                 foreach (var item in Model.articleTypes)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"new__right__box__item\"");
            BeginWriteAttribute("articleType", " articleType=\"", 7601, "\"", 7634, 1);
#nullable restore
#line 155 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
WriteAttributeValue("", 7615, item.ArticleTypeId, 7615, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <span>\r\n                            ");
#nullable restore
#line 157 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
                       Write(Html.Raw(item.image));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <h4>");
#nullable restore
#line 158 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
                           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                        </span>\r\n                    </div>\r\n");
#nullable restore
#line 161 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 161 "D:\Trainning_asp.net\Chuyen de web 2\CDW2Project\CDW2Project\Views\Home\Index.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""new__right__box__item programing_active"" articleType=""other"">
                <span>
                    <i class=""devicon-slack-plain colored""></i>
                    <h4>Other</h4>
                </span>
            </div>
        </div>
    </div><!-- New Right -->
</div><!-- New -->
");
            DefineSection("Home_View", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ffede0d176992da44df47cc8f8ff6b6dd404e5cc27462", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TypeAndArticleList> Html { get; private set; }
    }
}
#pragma warning restore 1591
