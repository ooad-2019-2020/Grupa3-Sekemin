#pragma checksum "C:\Users\Republic of Gamers\VisualStudioProjects\source\repos\Grupa3-Sekemin\Implementacija\Sekemin\Views\Student\Jelovnik.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d8a244c1b562295a1ec986f29e1b06863c7edbe5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_Jelovnik), @"mvc.1.0.view", @"/Views/Student/Jelovnik.cshtml")]
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
#line 1 "C:\Users\Republic of Gamers\VisualStudioProjects\source\repos\Grupa3-Sekemin\Implementacija\Sekemin\Views\_ViewImports.cshtml"
using Sekemin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Republic of Gamers\VisualStudioProjects\source\repos\Grupa3-Sekemin\Implementacija\Sekemin\Views\_ViewImports.cshtml"
using Sekemin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8a244c1b562295a1ec986f29e1b06863c7edbe5", @"/Views/Student/Jelovnik.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20e6b21db649294a6855a9d41c5f625c27328fa3", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_Jelovnik : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Sekemin.Models.Student>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Republic of Gamers\VisualStudioProjects\source\repos\Grupa3-Sekemin\Implementacija\Sekemin\Views\Student\Jelovnik.cshtml"
  
    ViewData["Title"] = "Jelovnik";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div style=""width: 100%; background-color: blueviolet"">
    <h6>Preostalo dnevnih obroka</h6>
</div>

<div style=""width: 100%; margin-top: 50px; background-color: blue"">
    <h5 style=""margin-left: 65%"">Odaberite željeni obrok sa sljedeće liste</h5>
</div>

<div style=""width: 100%; margin-top: 150px; background-color: purple"">
    <input type=""text"" id=""odabranaHrana"" name=""hrana"" placeholder=""Odabrana hrana"" style=""position: center; margin-top: 10%; margin-right: 75%; margin-left: 25%"" />
    <div class=""list-group"" style=""margin-left: 60%; max-height: 150px; overflow: auto; margin-bottom: 10%; position: center"">
        <a href=""#"" class=""list-group-item"">Value 1</a>
        <a href=""#"" class=""list-group-item"">Value 2</a>
        <a href=""#"" class=""list-group-item"">Value 3</a>
        <a href=""#"" class=""list-group-item"">Value 1</a>
        <a href=""#"" class=""list-group-item"">Value 2</a>
        <a href=""#"" class=""list-group-item"">Value 3</a>
        <a href=""#"" class=""list-group-item"">Val");
            WriteLiteral(@"ue 1</a>
        <a href=""#"" class=""list-group-item"">Value 2</a>
        <a href=""#"" class=""list-group-item"">Value 3</a>
        <a href=""#"" class=""list-group-item"">Value 1</a>
        <a href=""#"" class=""list-group-item"">Value 2</a>
        <a href=""#"" class=""list-group-item"">Value 3</a>
        <a href=""#"" class=""list-group-item"">Value 1</a>
        <a href=""#"" class=""list-group-item"">Value 2</a>
        <a href=""#"" class=""list-group-item"">Value 3</a>
        <a href=""#"" class=""list-group-item"">Value 1</a>
        <a href=""#"" class=""list-group-item"">Value 2</a>
        <a href=""#"" class=""list-group-item"">Value 3</a>
        <a href=""#"" class=""list-group-item"">Value 1</a>
        <a href=""#"" class=""list-group-item"">Value 2</a>
        <a href=""#"" class=""list-group-item"">Value 3</a>
        <a href=""#"" class=""list-group-item"">Value 1</a>
        <a href=""#"" class=""list-group-item"">Value 2</a>
        <a href=""#"" class=""list-group-item"">Value 3</a>
    </div>
</div>

<div style=""width: 50%;");
            WriteLiteral(@" margin-top: 100px; float: left; background-color: aqua"">
    <button type=""button"" style=""float: right; margin-right: 20px"">Nazad</button>
</div>

<div style=""width: 50%; margin-top: 100px; float: right; background-color: chartreuse"">
    <button type=""button"" style=""float: left; margin-left: 20px"">Plati</button>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Sekemin.Models.Student> Html { get; private set; }
    }
}
#pragma warning restore 1591
