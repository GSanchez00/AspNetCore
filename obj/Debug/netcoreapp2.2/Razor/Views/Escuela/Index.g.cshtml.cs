#pragma checksum "c:\Users\it_gsanchez\Platzi\ASP.NetCore\Views\Escuela\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b1f09631c3abbed67b15e558a1aee08155cae23"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Escuela_Index), @"mvc.1.0.view", @"/Views/Escuela/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Escuela/Index.cshtml", typeof(AspNetCore.Views_Escuela_Index))]
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
#line 1 "c:\Users\it_gsanchez\Platzi\ASP.NetCore\Views\_ViewImports.cshtml"
using ASP.NetCore;

#line default
#line hidden
#line 2 "c:\Users\it_gsanchez\Platzi\ASP.NetCore\Views\_ViewImports.cshtml"
using ASP.NetCore.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b1f09631c3abbed67b15e558a1aee08155cae23", @"/Views/Escuela/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e1b757eea04bebc95332e57cc590c64a582f683", @"/Views/_ViewImports.cshtml")]
    public class Views_Escuela_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Escuela>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(16, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "c:\Users\it_gsanchez\Platzi\ASP.NetCore\Views\Escuela\Index.cshtml"
  
    ViewData["Title"] = "Información Escuela";
    Layout= "Simple"; //Va a buscar en Shared Simple.cshtml

#line default
#line hidden
            BeginContext(134, 32, true);
            WriteLiteral("\r\n<h1>Escuela</h1>\r\n<h2>Nombre: ");
            EndContext();
            BeginContext(167, 12, false);
#line 9 "c:\Users\it_gsanchez\Platzi\ASP.NetCore\Views\Escuela\Index.cshtml"
       Write(Model.Nombre);

#line default
#line hidden
            EndContext();
            BeginContext(179, 28, true);
            WriteLiteral("</h2>\r\n<h3>Tipo de Escuela: ");
            EndContext();
            BeginContext(208, 17, false);
#line 10 "c:\Users\it_gsanchez\Platzi\ASP.NetCore\Views\Escuela\Index.cshtml"
                Write(Model.TipoEscuela);

#line default
#line hidden
            EndContext();
            BeginContext(225, 36, true);
            WriteLiteral("</h3>\r\n<address>\r\n    <p>Dirección: ");
            EndContext();
            BeginContext(262, 15, false);
#line 12 "c:\Users\it_gsanchez\Platzi\ASP.NetCore\Views\Escuela\Index.cshtml"
             Write(Model.Dirección);

#line default
#line hidden
            EndContext();
            BeginContext(277, 19, true);
            WriteLiteral("</p>\r\n    <p>País: ");
            EndContext();
            BeginContext(297, 10, false);
#line 13 "c:\Users\it_gsanchez\Platzi\ASP.NetCore\Views\Escuela\Index.cshtml"
        Write(Model.Pais);

#line default
#line hidden
            EndContext();
            BeginContext(307, 21, true);
            WriteLiteral("</p>\r\n    <p>Ciudad: ");
            EndContext();
            BeginContext(329, 12, false);
#line 14 "c:\Users\it_gsanchez\Platzi\ASP.NetCore\Views\Escuela\Index.cshtml"
          Write(Model.Ciudad);

#line default
#line hidden
            EndContext();
            BeginContext(341, 36, true);
            WriteLiteral("</p>\r\n</address>\r\n<p>Año fundacion: ");
            EndContext();
            BeginContext(378, 19, false);
#line 16 "c:\Users\it_gsanchez\Platzi\ASP.NetCore\Views\Escuela\Index.cshtml"
             Write(Model.AñoDeCreación);

#line default
#line hidden
            EndContext();
            BeginContext(397, 31, true);
            WriteLiteral("</p>\r\n\r\n<!-- <p>Año fundacion: ");
            EndContext();
            BeginContext(429, 20, false);
#line 18 "c:\Users\it_gsanchez\Platzi\ASP.NetCore\Views\Escuela\Index.cshtml"
                  Write(ViewBag.CosaDinamica);

#line default
#line hidden
            EndContext();
            BeginContext(449, 8, true);
            WriteLiteral("</p> -->");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Escuela> Html { get; private set; }
    }
}
#pragma warning restore 1591
