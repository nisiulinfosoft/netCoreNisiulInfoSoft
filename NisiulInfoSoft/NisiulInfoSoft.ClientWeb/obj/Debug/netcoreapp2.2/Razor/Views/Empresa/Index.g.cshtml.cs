#pragma checksum "G:\LMAZA\DESARROLLO\VISUAL_STUDIO\NisiulInfoSoft\NisiulInfoSoft.ClientWeb\Views\Empresa\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f77f929689684f514c37c0e334cdb01328720d93"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Empresa_Index), @"mvc.1.0.view", @"/Views/Empresa/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Empresa/Index.cshtml", typeof(AspNetCore.Views_Empresa_Index))]
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
#line 1 "G:\LMAZA\DESARROLLO\VISUAL_STUDIO\NisiulInfoSoft\NisiulInfoSoft.ClientWeb\Views\_ViewImports.cshtml"
using NisiulInfoSoft.ClientWeb;

#line default
#line hidden
#line 2 "G:\LMAZA\DESARROLLO\VISUAL_STUDIO\NisiulInfoSoft\NisiulInfoSoft.ClientWeb\Views\_ViewImports.cshtml"
using NisiulInfoSoft.ClientWeb.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f77f929689684f514c37c0e334cdb01328720d93", @"/Views/Empresa/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8a5fe603913090e9c62b2fdc888e9f5464b0b43", @"/Views/_ViewImports.cshtml")]
    public class Views_Empresa_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<NisiulInfoSoft.DTO.EmpresaDTO>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Editar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "G:\LMAZA\DESARROLLO\VISUAL_STUDIO\NisiulInfoSoft\NisiulInfoSoft.ClientWeb\Views\Empresa\Index.cshtml"
  
    ViewData["Title"] = "Index";
    //Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(143, 43, true);
            WriteLiteral("\r\n<h1>Listado de empresas</h1>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(186, 32, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f77f929689684f514c37c0e334cdb01328720d933993", async() => {
                BeginContext(209, 5, true);
                WriteLiteral("Nuevo");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(218, 153, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                Código\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(372, 39, false);
#line 20 "G:\LMAZA\DESARROLLO\VISUAL_STUDIO\NisiulInfoSoft\NisiulInfoSoft.ClientWeb\Views\Empresa\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Ruc));

#line default
#line hidden
            EndContext();
            BeginContext(411, 249, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                Razón Social\r\n            </th>\r\n            <th>\r\n                Dirección\r\n            </th>\r\n            <th>\r\n                Teléfono\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(661, 42, false);
#line 32 "G:\LMAZA\DESARROLLO\VISUAL_STUDIO\NisiulInfoSoft\NisiulInfoSoft.ClientWeb\Views\Empresa\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Estado));

#line default
#line hidden
            EndContext();
            BeginContext(703, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 38 "G:\LMAZA\DESARROLLO\VISUAL_STUDIO\NisiulInfoSoft\NisiulInfoSoft.ClientWeb\Views\Empresa\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(838, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(899, 40, false);
#line 42 "G:\LMAZA\DESARROLLO\VISUAL_STUDIO\NisiulInfoSoft\NisiulInfoSoft.ClientWeb\Views\Empresa\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.IdEmp));

#line default
#line hidden
            EndContext();
            BeginContext(939, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1007, 38, false);
#line 45 "G:\LMAZA\DESARROLLO\VISUAL_STUDIO\NisiulInfoSoft\NisiulInfoSoft.ClientWeb\Views\Empresa\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Ruc));

#line default
#line hidden
            EndContext();
            BeginContext(1045, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1113, 46, false);
#line 48 "G:\LMAZA\DESARROLLO\VISUAL_STUDIO\NisiulInfoSoft\NisiulInfoSoft.ClientWeb\Views\Empresa\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.RazonSocial));

#line default
#line hidden
            EndContext();
            BeginContext(1159, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1227, 44, false);
#line 51 "G:\LMAZA\DESARROLLO\VISUAL_STUDIO\NisiulInfoSoft\NisiulInfoSoft.ClientWeb\Views\Empresa\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Direccion));

#line default
#line hidden
            EndContext();
            BeginContext(1271, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1339, 43, false);
#line 54 "G:\LMAZA\DESARROLLO\VISUAL_STUDIO\NisiulInfoSoft\NisiulInfoSoft.ClientWeb\Views\Empresa\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Telefono));

#line default
#line hidden
            EndContext();
            BeginContext(1382, 47, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
            EndContext();
            BeginContext(1497, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(1519, 43, false);
#line 58 "G:\LMAZA\DESARROLLO\VISUAL_STUDIO\NisiulInfoSoft\NisiulInfoSoft.ClientWeb\Views\Empresa\Index.cshtml"
                Write(item.Estado == true ? "Activo" : "Inactivo");

#line default
#line hidden
            EndContext();
            BeginContext(1563, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1631, 60, false);
#line 61 "G:\LMAZA\DESARROLLO\VISUAL_STUDIO\NisiulInfoSoft\NisiulInfoSoft.ClientWeb\Views\Empresa\Index.cshtml"
               Write(Html.ActionLink("Editar", "Editar", new { id = item.IdEmp }));

#line default
#line hidden
            EndContext();
            BeginContext(1691, 24, true);
            WriteLiteral(" |\r\n                    ");
            EndContext();
            BeginContext(1716, 62, false);
#line 62 "G:\LMAZA\DESARROLLO\VISUAL_STUDIO\NisiulInfoSoft\NisiulInfoSoft.ClientWeb\Views\Empresa\Index.cshtml"
               Write(Html.ActionLink("Detalle", "Detalle", new { id = item.IdEmp }));

#line default
#line hidden
            EndContext();
            BeginContext(1778, 24, true);
            WriteLiteral(" |\r\n                    ");
            EndContext();
            BeginContext(1803, 64, false);
#line 63 "G:\LMAZA\DESARROLLO\VISUAL_STUDIO\NisiulInfoSoft\NisiulInfoSoft.ClientWeb\Views\Empresa\Index.cshtml"
               Write(Html.ActionLink("Eliminar", "Eliminar", new { id = item.IdEmp }));

#line default
#line hidden
            EndContext();
            BeginContext(1867, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 66 "G:\LMAZA\DESARROLLO\VISUAL_STUDIO\NisiulInfoSoft\NisiulInfoSoft.ClientWeb\Views\Empresa\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1922, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<NisiulInfoSoft.DTO.EmpresaDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
