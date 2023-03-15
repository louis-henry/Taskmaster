#pragma checksum "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Admin\AnalyticTaskCurrent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eaaa89a3d348d45c39b056d7d35546841e6666bf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_AnalyticTaskCurrent), @"mvc.1.0.view", @"/Views/Admin/AnalyticTaskCurrent.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaaa89a3d348d45c39b056d7d35546841e6666bf", @"/Views/Admin/AnalyticTaskCurrent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"921db7cc3e9d74d9adfefd5617676642dd45a4d7", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_AnalyticTaskCurrent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Taskmaster.ViewModels.AnalyticsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/chart-load/Chart.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Admin\AnalyticTaskCurrent.cshtml"
  
    ViewData["Title"] = "Current Tasks";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<section class=""wrapper"">
    <h3>Current Task Analytics</h3>
    <div class=""tab-pane"" id=""chartjs"">
        <div class=""row mt"">
            <!-- By Catagory Graph (Current/12 Months) -->
            <div class=""col-lg-4"" style=""min-width: 410px;"">
                <div class=""content-panel"" style=""min-height: 650px; min-width: 400px;"">
                    <h4>By Price</h4>
                    <div class=""panel-body text-center"">
                        <canvas id=""doughnut1"" height=""375"" width=""400""></canvas>
                    </div>
                    <input id=""pie0-100"" type=""hidden"" value=""500"">
");
#nullable restore
#line 20 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Admin\AnalyticTaskCurrent.cshtml"
                     foreach (var task in Model.TasksPerPaymentRange)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h4");
            BeginWriteAttribute("style", " style=\"", 899, "\"", 925, 2);
            WriteAttributeValue("", 907, "color:", 907, 6, true);
#nullable restore
#line 22 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Admin\AnalyticTaskCurrent.cshtml"
WriteAttributeValue(" ", 913, task.color, 914, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 22 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Admin\AnalyticTaskCurrent.cshtml"
                                                  Write(task.title);

#line default
#line hidden
#nullable disable
            WriteLiteral(" = ");
#nullable restore
#line 22 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Admin\AnalyticTaskCurrent.cshtml"
                                                                Write(task.value);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</h4>\r\n");
#nullable restore
#line 23 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Admin\AnalyticTaskCurrent.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
            </div>
            <!-- By Type Graph (Current/12 Months) -->
            <div class=""col-lg-4"" style=""min-width: 410px;"">
                <div class=""content-panel"" style=""min-height: 650px; min-width: 400px;"">
                    <h4>By Type</h4>
                    <div class=""panel-body text-center"">
                        <canvas id=""doughnut2"" height=""375"" width=""400""></canvas>
                    </div>
");
#nullable restore
#line 33 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Admin\AnalyticTaskCurrent.cshtml"
                     foreach (var task in Model.TaskPerType)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h4");
            BeginWriteAttribute("style", " style=\"", 1554, "\"", 1580, 2);
            WriteAttributeValue("", 1562, "color:", 1562, 6, true);
#nullable restore
#line 35 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Admin\AnalyticTaskCurrent.cshtml"
WriteAttributeValue(" ", 1568, task.color, 1569, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 35 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Admin\AnalyticTaskCurrent.cshtml"
                                                  Write(task.title);

#line default
#line hidden
#nullable disable
            WriteLiteral(" = ");
#nullable restore
#line 35 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Admin\AnalyticTaskCurrent.cshtml"
                                                                Write(task.value);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</h4>\r\n");
#nullable restore
#line 36 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Admin\AnalyticTaskCurrent.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
            </div>
            <!-- By Amount Graph (Current/12 Months) -->
            <div class=""col-lg-4"" style=""min-width: 410px;"">
                <div class=""content-panel"" style=""min-height: 650px; min-width: 400px;"">
                    <h4>By Travel</h4>
                    <div class=""panel-body text-center"">
                        <canvas id=""doughnut3"" height=""375"" width=""400""></canvas>
                    </div>
");
#nullable restore
#line 46 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Admin\AnalyticTaskCurrent.cshtml"
                     foreach (var task in Model.TasksPerPresence)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h4");
            BeginWriteAttribute("style", " style=\"", 2218, "\"", 2244, 2);
            WriteAttributeValue("", 2226, "color:", 2226, 6, true);
#nullable restore
#line 48 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Admin\AnalyticTaskCurrent.cshtml"
WriteAttributeValue(" ", 2232, task.color, 2233, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 48 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Admin\AnalyticTaskCurrent.cshtml"
                                                  Write(task.title);

#line default
#line hidden
#nullable disable
            WriteLiteral(" = ");
#nullable restore
#line 48 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Admin\AnalyticTaskCurrent.cshtml"
                                                                Write(task.value);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</h4>\r\n");
#nullable restore
#line 49 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Admin\AnalyticTaskCurrent.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <!--For the Graphs -->\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eaaa89a3d348d45c39b056d7d35546841e6666bf10900", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <script>\r\n        var Script = function () {\r\n            var doughnutCatagory = ");
#nullable restore
#line 58 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Admin\AnalyticTaskCurrent.cshtml"
                              Write(Html.Raw(Model.TasksPerPaymentRangeJson));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n            var doughnutType = ");
#nullable restore
#line 59 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Admin\AnalyticTaskCurrent.cshtml"
                          Write(Html.Raw(Model.TaskPerTypeJson));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n            var doughnutAmount = ");
#nullable restore
#line 60 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Admin\AnalyticTaskCurrent.cshtml"
                            Write(Html.Raw(Model.TasksPerPresenceJson));

#line default
#line hidden
#nullable disable
            WriteLiteral(@";

            new Chart(document.getElementById(""doughnut1"").getContext(""2d"")).Doughnut(doughnutCatagory);
            new Chart(document.getElementById(""doughnut2"").getContext(""2d"")).Doughnut(doughnutType);
            new Chart(document.getElementById(""doughnut3"").getContext(""2d"")).Doughnut(doughnutAmount);
        }();
    </script>
</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Taskmaster.ViewModels.AnalyticsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
