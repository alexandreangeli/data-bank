#pragma checksum "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\Usuarios\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "56551aea0cc3f5c4a31890cf0cdbaae3ac33cde1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuarios_Login), @"mvc.1.0.view", @"/Views/Usuarios/Login.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Usuarios/Login.cshtml", typeof(AspNetCore.Views_Usuarios_Login))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
#line 4 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\_ViewImports.cshtml"
using System.Linq;

#line default
#line hidden
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\_ViewImports.cshtml"
using BancoDataCoper;

#line default
#line hidden
#line 2 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\_ViewImports.cshtml"
using BancoDataCoper.Models;

#line default
#line hidden
#line 3 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\_ViewImports.cshtml"
using BancoDataCoper.Models.ViewModels;

#line default
#line hidden
#line 5 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\_ViewImports.cshtml"
using System.Data;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56551aea0cc3f5c4a31890cf0cdbaae3ac33cde1", @"/Views/Usuarios/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9581cf40c849ef45913251e3e65b4437ad75d811", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuarios_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Usuarios", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(15, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\Usuarios\Login.cshtml"
  
    ViewData["Title"] = "Login";

#line default
#line hidden
            BeginContext(58, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\Usuarios\Login.cshtml"
 if (!string.IsNullOrEmpty(User.Identity.Name))
{

#line default
#line hidden
            BeginContext(112, 249, true);
            WriteLiteral("    <style>\r\n    </style>\r\n    <div class=\"log\">\r\n        <div class=\" rounde mt-5 filho-login\">\r\n            <br />\r\n            <br />\r\n            <h1>Você já está Logado.</h1>\r\n            <br />\r\n            <br />\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 20 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\Usuarios\Login.cshtml"

}
else
{

#line default
#line hidden
            BeginContext(375, 187, true);
            WriteLiteral("    <style>\r\n    </style>\r\n    <div class=\"log\">\r\n        <div class=\" rounde mt-5 filho-login\">\r\n            <h1 class=\"text-center Texto font-weight-bolder m-3\">Login</h1>\r\n            ");
            EndContext();
            BeginContext(562, 793, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e76f23957244cc2b0f568d5f7ac813a", async() => {
                BeginContext(627, 38, true);
                WriteLiteral("\r\n                <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 665, "\"", 679, 1);
#line 30 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\Usuarios\Login.cshtml"
WriteAttributeValue("", 673, Model, 673, 6, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(680, 668, true);
                WriteLiteral(@" name=""returnUrl"" />
                <div class=""form-group"">
                    <label class=""control-label"">E-Mail</label>
                    <input type=""text"" name=""email"" placeholder=""Email"" class=""form-control"" />
                </div>

                <div class=""form-group"">
                    <label class=""control-label"">Senha</label>
                    <input type=""password"" name=""password"" placeholder=""Senha"" class=""form-control"" />
                </div>
                <div class=""text-center"">

                    <button type=""submit"" class=""btn btn-dark m-2 font-weight-bold "">Logar</button>
                </div>
            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1355, 30, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 47 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\Usuarios\Login.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591
