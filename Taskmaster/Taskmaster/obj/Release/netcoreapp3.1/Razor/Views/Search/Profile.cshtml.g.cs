#pragma checksum "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b947adef22da4cdb7560c83835937d9cf26cc3dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Search_Profile), @"mvc.1.0.view", @"/Views/Search/Profile.cshtml")]
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
#line 1 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\_ViewImports.cshtml"
using Taskmaster;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\_ViewImports.cshtml"
using Taskmaster.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\_ViewImports.cshtml"
using Taskmaster.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\_ViewImports.cshtml"
using Taskmaster.Shared;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b947adef22da4cdb7560c83835937d9cf26cc3dc", @"/Views/Search/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"921db7cc3e9d74d9adfefd5617676642dd45a4d7", @"/Views/_ViewImports.cshtml")]
    public class Views_Search_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Taskmaster.ViewModels.ProfileViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/profile-page.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml"
  
    ViewData["Title"] = "Profile Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b947adef22da4cdb7560c83835937d9cf26cc3dc4587", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<div class=""profile-container"">
    <div class=""row gutters-sm"">
        <div class=""col-md-4 mb-3"">
            <div class=""card"">
                <div class=""card-body"">
                    <div class=""d-flex flex-column align-items-center text-center"">
                        <img");
            BeginWriteAttribute("src", " src=\"", 498, "\"", 543, 1);
#nullable restore
#line 16 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml"
WriteAttributeValue("", 504, Url.Content("~/images/admin/user.png"), 504, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Admin\" class=\"rounded-circle\" width=\"150\">\r\n                        <div class=\"mt-3\">\r\n                            <h4>");
#nullable restore
#line 18 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml"
                           Write(Html.DisplayFor(modelItem => Model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 748, "\"", 774, 2);
            WriteAttributeValue("", 755, "mailto:", 755, 7, true);
#nullable restore
#line 19 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml"
WriteAttributeValue("", 762, Model.Email, 762, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn-outline-primary"" id=""btn-msgme""
                                style=""padding: 7px;"">Message</a>
                        </div>
                    </div>
                </div>
            </div>

            <div class=""card mt-3"">
                <h1 class=""profile-descrip-head"">About Me</h1>
");
#nullable restore
#line 28 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml"
                 if (Model.Description != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p class=\"profile-descrip\">");
#nullable restore
#line 30 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml"
                                      Write(Html.DisplayFor(modelItem => Model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 31 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p class=\"profile-descrip\">Hi there! My name is ");
#nullable restore
#line 34 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml"
                                                           Write(Html.DisplayFor(modelItem => Model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral(" and I am\r\n                    looking\r\n                    forward to working with you, so contact me through my profile</p>\r\n");
#nullable restore
#line 37 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </div>
        </div>

        <div class=""col-md-8"">
            <div class=""card mb-3"">
                <div class=""card-body"">
                    <div class=""row"">
                        <div class=""col-sm-3"">
                            <h6 class=""mb-0"">Full Name</h6>
                        </div>

                        <div class=""col-sm-9 text-secondary"">
                            ");
#nullable restore
#line 50 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml"
                       Write(Html.DisplayFor(modelItem => Model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>

                    <hr>
                    <div class=""row"">
                        <div class=""col-sm-3"">
                            <h6 class=""mb-0"">Email</h6>
                        </div>
                        <div class=""col-sm-9 text-secondary"">
                            ");
#nullable restore
#line 60 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml"
                       Write(Html.DisplayFor(modelItem => Model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>

                    <hr>
                    <div class=""row"">
                        <div class=""col-sm-3"">
                            <h6 class=""mb-0"">Phone</h6>
                        </div>
                        <div class=""col-sm-9 text-secondary"">
                            Not Available
                        </div>
                    </div>

                    <hr>
                    <div class=""row"">
                        <div class=""col-sm-3"">
                            <h6 class=""mb-0"">Mobile</h6>
                        </div>
");
#nullable restore
#line 79 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml"
                         if(Model.Phone != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"col-sm-9 text-secondary\">\r\n                            ");
#nullable restore
#line 82 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml"
                       Write(Html.DisplayFor(modelItem => Model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n");
#nullable restore
#line 84 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"col-sm-9 text-secondary\">\r\n                            Not Available\r\n                        </div>\r\n");
#nullable restore
#line 90 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n\r\n                    <hr>\r\n                    <div class=\"row\">\r\n                        <div class=\"col-sm-3\">\r\n                            <h6 class=\"mb-0\">Postcode</h6>\r\n                        </div>\r\n");
#nullable restore
#line 98 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml"
                         if(Model.Postcode != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"col-sm-9 text-secondary\">\r\n                            ");
#nullable restore
#line 101 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml"
                       Write(Html.DisplayFor(modelItem => Model.Postcode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n");
#nullable restore
#line 103 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"col-sm-9 text-secondary\">\r\n                            Not Available\r\n                        </div>\r\n");
#nullable restore
#line 109 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </div>
                </div>
            </div>

            <div class=""row gutters-sm"">
                <div class=""col-sm-12 mb-3"">
                    <div class=""card h-100"">
                        <h1 class=""profile-descrip-head2"">My Skills</h1>
");
#nullable restore
#line 118 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml"
                         foreach (var catagories in Model.Categories)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"card-body\">\r\n                            <h6 class=\"d-flex align-items-center mb-3\"><i\r\n                                    class=\"material-icons text-info mr-2\">Catagory: </i>");
#nullable restore
#line 122 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml"
                                                                                   Write(Html.DisplayFor(modelItem =>
                                catagories.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n");
#nullable restore
#line 124 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml"
                             foreach (var skills in catagories.Skills)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <small>");
#nullable restore
#line 126 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml"
                              Write(Html.DisplayFor(modelItem => skills.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</small>
                            <div class=""progress mb-3"" style=""height: 5px"">
                                <div class=""progress-bar bg-success"" role=""progressbar"" style=""width: 100%""
                                    aria-valuenow=""100"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                            </div>
");
#nullable restore
#line 131 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n");
#nullable restore
#line 133 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Search\Profile.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Taskmaster.ViewModels.ProfileViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
