#pragma checksum "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\PostosDeCaixa\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2e3de31c1ba6049591670b513a626e102ecaf24e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PostosDeCaixa_Details), @"mvc.1.0.view", @"/Views/PostosDeCaixa/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/PostosDeCaixa/Details.cshtml", typeof(AspNetCore.Views_PostosDeCaixa_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e3de31c1ba6049591670b513a626e102ecaf24e", @"/Views/PostosDeCaixa/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9581cf40c849ef45913251e3e65b4437ad75d811", @"/Views/_ViewImports.cshtml")]
    public class Views_PostosDeCaixa_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PostoDeCaixa>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark rounded-pill"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary rounded-pill"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\PostosDeCaixa\Details.cshtml"
  
    ViewData["Title"] = "Detalhes do Posto de Caixa";

#line default
#line hidden
            BeginContext(83, 304, true);
            WriteLiteral(@"
<div class=""pai-posto"">
    <div class=""filho"">
        <h4 class=""font font-weight-bold m-1 text-center"">Detalhes do Posto De Caixa</h4>
        <hr />
        <dl class=""col-6 offset-3 cor rounded "">
            <dt>
                Filial
            </dt>
            <dd>
                ");
            EndContext();
            BeginContext(388, 58, false);
#line 15 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\PostosDeCaixa\Details.cshtml"
           Write(Html.DisplayFor(model => model.Filial.PessoaJuridica.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(446, 117, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                Usuário\r\n            </dt>\r\n            <dd>\r\n                ");
            EndContext();
            BeginContext(564, 45, false);
#line 21 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\PostosDeCaixa\Details.cshtml"
           Write(Html.DisplayFor(model => model.Usuario.Email));

#line default
#line hidden
            EndContext();
            BeginContext(609, 115, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                Conta\r\n            </dt>\r\n            <dd>\r\n                ");
            EndContext();
            BeginContext(725, 59, false);
#line 27 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\PostosDeCaixa\Details.cshtml"
           Write(Html.DisplayFor(model => model.ContaCorrente.NumeroDaConta));

#line default
#line hidden
            EndContext();
            BeginContext(784, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(786, 65, false);
#line 27 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\PostosDeCaixa\Details.cshtml"
                                                                        Write(Html.DisplayFor(model => model.ContaCorrente.DigitoVerificadorCC));

#line default
#line hidden
            EndContext();
            BeginContext(851, 55, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                ");
            EndContext();
            BeginContext(907, 49, false);
#line 30 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\PostosDeCaixa\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.CodigoDoPosto));

#line default
#line hidden
            EndContext();
            BeginContext(956, 55, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
            EndContext();
            BeginContext(1012, 45, false);
#line 33 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\PostosDeCaixa\Details.cshtml"
           Write(Html.DisplayFor(model => model.CodigoDoPosto));

#line default
#line hidden
            EndContext();
            BeginContext(1057, 55, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                ");
            EndContext();
            BeginContext(1113, 40, false);
#line 36 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\PostosDeCaixa\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(1153, 55, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
            EndContext();
            BeginContext(1209, 36, false);
#line 39 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\PostosDeCaixa\Details.cshtml"
           Write(Html.DisplayFor(model => model.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(1245, 43, true);
            WriteLiteral("\r\n\r\n            </dd>\r\n            <dd>\r\n\r\n");
            EndContext();
#line 44 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\PostosDeCaixa\Details.cshtml"
                   if (Model.Ativo == false)
                    {

#line default
#line hidden
            BeginContext(1357, 109, true);
            WriteLiteral("                        <label><i class=\"material-icons text-danger float-left\">close</i>Desativada</label>\r\n");
            EndContext();
#line 47 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\PostosDeCaixa\Details.cshtml"

                    }
                    else
                    {

#line default
#line hidden
            BeginContext(1540, 119, true);
            WriteLiteral("                        <label><i class=\"material-icons text-center text-success float-left\">check</i>Ativada</label>\r\n");
            EndContext();
#line 52 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\PostosDeCaixa\Details.cshtml"

                    }
                

#line default
#line hidden
            BeginContext(1703, 88, true);
            WriteLiteral("\r\n            </dd>\r\n        </dl>\r\n        <div class=\"text-center btns\">\r\n            ");
            EndContext();
            BeginContext(1791, 133, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "db6a5332d0a544229c49a44b67b3b234", async() => {
                BeginContext(1847, 73, true);
                WriteLiteral("<i class=\"material-icons float-left font\">arrow_back</i>Voltar Para Lista");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1924, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(1938, 141, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e744b3452e1d457ca4e8d2e35dc8833b", async() => {
                BeginContext(2021, 54, true);
                WriteLiteral("<i class=\"material-icons float-left\">create</i> Editar");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 60 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\PostosDeCaixa\Details.cshtml"
                                   WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2079, 36, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PostoDeCaixa> Html { get; private set; }
    }
}
#pragma warning restore 1591
