#pragma checksum "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Secure\AccessDenied.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "569212f02c6c3c4502d7b76d83662ceb38c3b14d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Secure_AccessDenied), @"mvc.1.0.view", @"/Views/Secure/AccessDenied.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"569212f02c6c3c4502d7b76d83662ceb38c3b14d", @"/Views/Secure/AccessDenied.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"921db7cc3e9d74d9adfefd5617676642dd45a4d7", @"/Views/_ViewImports.cshtml")]
    public class Views_Secure_AccessDenied : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Taskmaster.ViewModels.MessageViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Secure\AccessDenied.cshtml"
  
    ViewData["Title"] = "Access Denied";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Access Denied</h1>\r\n\r\n<p>");
#nullable restore
#line 10 "D:\Open Learning\CPT311\ProgramingProjectG2\Taskmaster\Taskmaster\Views\Secure\AccessDenied.cshtml"
Write(Model.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Taskmaster.ViewModels.MessageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
