#pragma checksum "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Shared\_UserLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c942b64af2af0bb98f4dd8f2911bcce4fbc50d4d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__UserLayout), @"mvc.1.0.view", @"/Views/Shared/_UserLayout.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c942b64af2af0bb98f4dd8f2911bcce4fbc50d4d", @"/Views/Shared/_UserLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"921db7cc3e9d74d9adfefd5617676642dd45a4d7", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__UserLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/user-admin.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/font-awesome/css/all.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("layout"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c942b64af2af0bb98f4dd8f2911bcce4fbc50d4d5687", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <title>");
#nullable restore
#line 7 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Shared\_UserLayout.cshtml"
      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - Taskmaster</title>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c942b64af2af0bb98f4dd8f2911bcce4fbc50d4d6349", async() => {
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
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c942b64af2af0bb98f4dd8f2911bcce4fbc50d4d7527", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c942b64af2af0bb98f4dd8f2911bcce4fbc50d4d8705", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c942b64af2af0bb98f4dd8f2911bcce4fbc50d4d10587", async() => {
                WriteLiteral("\r\n\r\n    <div class=\"sidenav\">\r\n        <!--logo start-->\r\n        <a");
                BeginWriteAttribute("href", " href=\"", 512, "\"", 547, 1);
#nullable restore
#line 16 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Shared\_UserLayout.cshtml"
WriteAttributeValue("", 519, Url.Action("Index", "Home"), 519, 28, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"logo\"><img");
                BeginWriteAttribute("src", " src=\"", 566, "\"", 616, 1);
#nullable restore
#line 16 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Shared\_UserLayout.cshtml"
WriteAttributeValue("", 572, Url.Content("~/images/taskmaster-logo.png"), 572, 44, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" width=\"80\" height=\"40\"></a>\r\n        <!--logo end-->\r\n        <ul>\r\n            <li class=\"button\">\r\n                <input class=\"left-nav-btn\" type=\"button\" value=\"Taskmaster\"");
                BeginWriteAttribute("onclick", " onclick=\"", 795, "\"", 849, 3);
                WriteAttributeValue("", 805, "location.href=\'", 805, 15, true);
#nullable restore
#line 20 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Shared\_UserLayout.cshtml"
WriteAttributeValue("", 820, Url.Action("Index", "Home"), 820, 28, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 848, "\'", 848, 1, true);
                EndWriteAttribute();
                WriteLiteral(" />\r\n            </li>\r\n            <li class=\"button\">\r\n                <input class=\"left-nav-btn\" type=\"button\" value=\"My skills\" class=\"btn-layout\"");
                BeginWriteAttribute("onclick", " onclick=\"", 1001, "\"", 1056, 3);
                WriteAttributeValue("", 1011, "location.href=\'", 1011, 15, true);
#nullable restore
#line 23 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Shared\_UserLayout.cshtml"
WriteAttributeValue("", 1026, Url.Action("Skills", "User"), 1026, 29, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1055, "\'", 1055, 1, true);
                EndWriteAttribute();
                WriteLiteral(" />\r\n            </li>\r\n            <li class=\"button\">\r\n                <input class=\"left-nav-btn\" type=\"button\" value=\"My profile\" class=\"btn-layout\"");
                BeginWriteAttribute("onclick", " onclick=\"", 1209, "\"", 1268, 3);
                WriteAttributeValue("", 1219, "location.href=\'", 1219, 15, true);
#nullable restore
#line 26 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Shared\_UserLayout.cshtml"
WriteAttributeValue("", 1234, Url.Action("Profile", "Account"), 1234, 33, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1267, "\'", 1267, 1, true);
                EndWriteAttribute();
                WriteLiteral(" />\r\n            </li>\r\n            <li class=\"button\">\r\n                <input class=\"left-nav-btn\" type=\"button\" value=\"Password settings\" class=\"btn-layout\"");
                BeginWriteAttribute("onclick", " onclick=\"", 1428, "\"", 1493, 3);
                WriteAttributeValue("", 1438, "location.href=\'", 1438, 15, true);
#nullable restore
#line 29 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Shared\_UserLayout.cshtml"
WriteAttributeValue("", 1453, Url.Action("ChangePassword", "Secure"), 1453, 39, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1492, "\'", 1492, 1, true);
                EndWriteAttribute();
                WriteLiteral(" />\r\n            </li>\r\n            <li class=\"button\">\r\n                <input class=\"left-nav-btn\" type=\"button\" value=\"Deactivate\" class=\"btn-layout\"");
                BeginWriteAttribute("onclick", " onclick=\"", 1646, "\"", 1705, 3);
                WriteAttributeValue("", 1656, "location.href=\'", 1656, 15, true);
#nullable restore
#line 32 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Shared\_UserLayout.cshtml"
WriteAttributeValue("", 1671, Url.Action("Deactivate", "User"), 1671, 33, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1704, "\'", 1704, 1, true);
                EndWriteAttribute();
                WriteLiteral(" />\r\n            </li>\r\n            <li class=\"button\">\r\n                <input class=\"left-nav-btn\" type=\"button\" value=\"Logout\" class=\"btn-layout\"");
                BeginWriteAttribute("onclick", " onclick=\"", 1854, "\"", 1911, 3);
                WriteAttributeValue("", 1864, "location.href=\'", 1864, 15, true);
#nullable restore
#line 35 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Shared\_UserLayout.cshtml"
WriteAttributeValue("", 1879, Url.Action("Logout", "Secure"), 1879, 31, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1910, "\'", 1910, 1, true);
                EndWriteAttribute();
                WriteLiteral(" />\r\n            </li>\r\n        </ul>\r\n    </div>\r\n    <section id=\"main-content\">\r\n        ");
#nullable restore
#line 40 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Shared\_UserLayout.cshtml"
   Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    </section>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
