#pragma checksum "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\Employee\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0711fcf4f709d44718ac526a0e03ac33e8f1314f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employee_Index), @"mvc.1.0.view", @"/Views/Employee/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Employee/Index.cshtml", typeof(AspNetCore.Views_Employee_Index))]
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
#line 1 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\_ViewImports.cshtml"
using Prueba_Tecnica;

#line default
#line hidden
#line 2 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\_ViewImports.cshtml"
using Prueba_Tecnica.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0711fcf4f709d44718ac526a0e03ac33e8f1314f", @"/Views/Employee/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11b3cc217861209fc898015771d0d1acdafce558", @"/Views/_ViewImports.cshtml")]
    public class Views_Employee_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Prueba_Tecnica.Models.EmpleadoViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(61, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\Employee\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(104, 29, true);
            WriteLiteral("\r\n<h2>Index</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(133, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5c181eeab564725ad09ecb5568be187", async() => {
                BeginContext(156, 10, true);
                WriteLiteral("Create New");
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
            BeginContext(170, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(263, 46, false);
#line 16 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\Employee\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IdEmployee));

#line default
#line hidden
            EndContext();
            BeginContext(309, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(365, 44, false);
#line 19 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\Employee\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FullName));

#line default
#line hidden
            EndContext();
            BeginContext(409, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(465, 50, false);
#line 22 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\Employee\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.identification));

#line default
#line hidden
            EndContext();
            BeginContext(515, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(571, 41, false);
#line 25 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\Employee\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(612, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(668, 45, false);
#line 28 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\Employee\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DateBirth));

#line default
#line hidden
            EndContext();
            BeginContext(713, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(769, 49, false);
#line 31 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\Employee\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.AdmissionDate));

#line default
#line hidden
            EndContext();
            BeginContext(818, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(874, 42, false);
#line 34 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\Employee\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IdBoss));

#line default
#line hidden
            EndContext();
            BeginContext(916, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(972, 42, false);
#line 37 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\Employee\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IdArea));

#line default
#line hidden
            EndContext();
            BeginContext(1014, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1070, 41, false);
#line 40 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\Employee\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Photo));

#line default
#line hidden
            EndContext();
            BeginContext(1111, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 46 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\Employee\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(1229, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1278, 45, false);
#line 49 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\Employee\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IdEmployee));

#line default
#line hidden
            EndContext();
            BeginContext(1323, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1379, 43, false);
#line 52 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\Employee\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FullName));

#line default
#line hidden
            EndContext();
            BeginContext(1422, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1478, 49, false);
#line 55 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\Employee\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.identification));

#line default
#line hidden
            EndContext();
            BeginContext(1527, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1583, 40, false);
#line 58 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\Employee\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
            EndContext();
            BeginContext(1623, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1679, 44, false);
#line 61 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\Employee\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.DateBirth));

#line default
#line hidden
            EndContext();
            BeginContext(1723, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1779, 48, false);
#line 64 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\Employee\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.AdmissionDate));

#line default
#line hidden
            EndContext();
            BeginContext(1827, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1883, 41, false);
#line 67 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\Employee\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IdBoss));

#line default
#line hidden
            EndContext();
            BeginContext(1924, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1980, 41, false);
#line 70 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\Employee\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IdArea));

#line default
#line hidden
            EndContext();
            BeginContext(2021, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2077, 40, false);
#line 73 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\Employee\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Photo));

#line default
#line hidden
            EndContext();
            BeginContext(2117, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2173, 65, false);
#line 76 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\Employee\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(2238, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(2259, 71, false);
#line 77 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\Employee\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(2330, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(2351, 69, false);
#line 78 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\Employee\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(2420, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 81 "C:\Users\byron\Desktop\Prueba_Tecnica\Prueba_Tecnica\Views\Employee\Index.cshtml"
}

#line default
#line hidden
            BeginContext(2459, 24, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Prueba_Tecnica.Models.EmpleadoViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591