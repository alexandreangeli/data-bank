#pragma checksum "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2f4a3e7ff2b0f48e59d81b00aad72356e70faf51"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MovimentoBancario_ConfirmarMovimento), @"mvc.1.0.view", @"/Views/MovimentoBancario/ConfirmarMovimento.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/MovimentoBancario/ConfirmarMovimento.cshtml", typeof(AspNetCore.Views_MovimentoBancario_ConfirmarMovimento))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2f4a3e7ff2b0f48e59d81b00aad72356e70faf51", @"/Views/MovimentoBancario/ConfirmarMovimento.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9581cf40c849ef45913251e3e65b4437ad75d811", @"/Views/_ViewImports.cshtml")]
    public class Views_MovimentoBancario_ConfirmarMovimento : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MovimentoBancarioViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "cheque", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MovimentoConfirmado", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SelecionarConta", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark rounded-pill"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(35, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
  
    ViewData["Title"] = "Confirmar Movimento";

#line default
#line hidden
            BeginContext(92, 23, true);
            WriteLiteral("\r\n<div class=\"mov\">\r\n\r\n");
            EndContext();
#line 9 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
     if (Model.MovimentoBancario.Tipo == "saque" || Model.MovimentoBancario.Tipo == "deposito")
    {

#line default
#line hidden
            BeginContext(219, 407, true);
            WriteLiteral(@"        <div class=""filho"">
            <div class=""col-md-6  rounded font offset-3 cor"">
                <h2 class=""font font-weight-bold text-center m-1"">Confirmar</h2>
                <hr />
                <dl>
                    <dt class=""font-weight-bold"">
                        Usuário
                    </dt>
                    <dd class=""font-weight-light"">
                        ");
            EndContext();
            BeginContext(627, 57, false);
#line 20 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
                   Write(Html.DisplayFor(model => model.MovimentoBancario.Usuario));

#line default
#line hidden
            EndContext();
            BeginContext(684, 88, true);
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"\">\r\n                        ");
            EndContext();
            BeginContext(773, 81, false);
#line 23 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
                   Write(Html.DisplayNameFor(model => model.MovimentoBancario.ContaCorrente.NumeroDaConta));

#line default
#line hidden
            EndContext();
            BeginContext(854, 105, true);
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"font-weight-light\">\r\n                        ");
            EndContext();
            BeginContext(960, 77, false);
#line 26 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
                   Write(Html.DisplayFor(model => model.MovimentoBancario.ContaCorrente.NumeroDaConta));

#line default
#line hidden
            EndContext();
            BeginContext(1037, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1039, 83, false);
#line 26 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
                                                                                                  Write(Html.DisplayFor(model => model.MovimentoBancario.ContaCorrente.DigitoVerificadorCC));

#line default
#line hidden
            EndContext();
            BeginContext(1122, 79, true);
            WriteLiteral("\r\n                    </dd>\r\n                    <dt>\r\n                        ");
            EndContext();
            BeginContext(1202, 58, false);
#line 29 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
                   Write(Html.DisplayNameFor(model => model.MovimentoBancario.Tipo));

#line default
#line hidden
            EndContext();
            BeginContext(1260, 81, true);
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"font-weight-light\">\r\n");
            EndContext();
#line 32 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
                         if (Model.MovimentoBancario.Tipo == "saque")
                        {

#line default
#line hidden
            BeginContext(1439, 28, true);
            WriteLiteral("                            ");
            EndContext();
            BeginContext(1469, 7, true);
            WriteLiteral("Saque\r\n");
            EndContext();
#line 35 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(1560, 28, true);
            WriteLiteral("                            ");
            EndContext();
            BeginContext(1590, 10, true);
            WriteLiteral("Depósito\r\n");
            EndContext();
#line 39 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
                        }

#line default
#line hidden
            BeginContext(1627, 77, true);
            WriteLiteral("                    </dd>\r\n                    <dt>\r\n                        ");
            EndContext();
            BeginContext(1705, 59, false);
#line 42 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
                   Write(Html.DisplayNameFor(model => model.MovimentoBancario.Valor));

#line default
#line hidden
            EndContext();
            BeginContext(1764, 105, true);
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"font-weight-light\">\r\n                        ");
            EndContext();
            BeginContext(1870, 55, false);
#line 45 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
                   Write(Html.DisplayFor(model => model.MovimentoBancario.Valor));

#line default
#line hidden
            EndContext();
            BeginContext(1925, 178, true);
            WriteLiteral("\r\n                    </dd>\r\n                    <dt>\r\n                        Cheque ou Dinheiro\r\n                    </dt>\r\n                    <dd class=\"font-weight-light\">\r\n");
            EndContext();
#line 51 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
                         if (Model.MovimentoBancario.Cheque == true)
                        {

#line default
#line hidden
            BeginContext(2200, 28, true);
            WriteLiteral("                            ");
            EndContext();
            BeginContext(2230, 8, true);
            WriteLiteral("Cheque\r\n");
            EndContext();
#line 54 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(2322, 28, true);
            WriteLiteral("                            ");
            EndContext();
            BeginContext(2352, 10, true);
            WriteLiteral("Dinheiro\r\n");
            EndContext();
#line 58 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
                        }

#line default
#line hidden
            BeginContext(2389, 66, true);
            WriteLiteral("                    </dd>\r\n                </dl>\r\n                ");
            EndContext();
            BeginContext(2455, 616, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c8bfb566b9594235ad8bde19e70cec10", async() => {
                BeginContext(2514, 42, true);
                WriteLiteral("\r\n                    <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2556, "\"", 2587, 1);
#line 62 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
WriteAttributeValue("", 2564, Model.ContaCorrente.Id, 2564, 23, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2588, 68, true);
                WriteLiteral(" name=\"ContaCorrenteId\" />\r\n                    <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2656, "\"", 2694, 1);
#line 63 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
WriteAttributeValue("", 2664, Model.MovimentoBancario.Valor, 2664, 30, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2695, 58, true);
                WriteLiteral(" name=\"Valor\" />\r\n                    <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2753, "\"", 2790, 1);
#line 64 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
WriteAttributeValue("", 2761, Model.MovimentoBancario.Tipo, 2761, 29, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2791, 37, true);
                WriteLiteral(" name=\"tipo\" />\r\n                    ");
                EndContext();
                BeginContext(2828, 112, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2953dc67b51442fe92ec16f6b92b2a2c", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 65 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.MovimentoBancario.Cheque);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                BeginWriteTagHelperAttribute();
#line 65 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
                                                                       WriteLiteral(Model.MovimentoBancario.Cheque);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2940, 124, true);
                WriteLiteral("\r\n\r\n                    <input type=\"submit\" value=\"Confirmar\" class=\"btn btn-primary rounded-pill m-2\" />\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3071, 71, true);
            WriteLiteral("\r\n                <div class=\"text-center btns \">\r\n                    ");
            EndContext();
            BeginContext(3142, 132, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7fd229f26f2046ee96bff5fb75ad8935", async() => {
                BeginContext(3208, 62, true);
                WriteLiteral("<i class=\"material-icons float-left font\">arrow_back</i>Voltar");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3274, 64, true);
            WriteLiteral("\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 75 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"

    }

#line default
#line hidden
            BeginContext(3347, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 78 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
     if (Model.MovimentoBancario.Tipo == "transferencia")
    {

#line default
#line hidden
            BeginContext(3415, 316, true);
            WriteLiteral(@"        <div class=""filho"">
            <div class=""col-md-6 rounded font offset-3 cor alert-secondary"">
                <dl>
                    <dt class=""font-weight-bold"">
                        Usuário
                    </dt>
                    <dd class=""font-weight-light"">
                        ");
            EndContext();
            BeginContext(3732, 57, false);
#line 87 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
                   Write(Html.DisplayFor(model => model.MovimentoBancario.Usuario));

#line default
#line hidden
            EndContext();
            BeginContext(3789, 79, true);
            WriteLiteral("\r\n                    </dd>\r\n                    <dt>\r\n                        ");
            EndContext();
            BeginContext(3869, 81, false);
#line 90 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
                   Write(Html.DisplayNameFor(model => model.MovimentoBancario.ContaCorrente.NumeroDaConta));

#line default
#line hidden
            EndContext();
            BeginContext(3950, 105, true);
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"font-weight-light\">\r\n                        ");
            EndContext();
            BeginContext(4056, 77, false);
#line 93 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
                   Write(Html.DisplayFor(model => model.MovimentoBancario.ContaCorrente.NumeroDaConta));

#line default
#line hidden
            EndContext();
            BeginContext(4133, 197, true);
            WriteLiteral("\r\n                    </dd>\r\n                    <dt>\r\n                        Conta Destino\r\n                    </dt>\r\n                    <dd class=\"font-weight-light\">\r\n                        ");
            EndContext();
            BeginContext(4331, 80, false);
#line 99 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
                   Write(Html.DisplayFor(model => model.MovimentoBancario.TransferenciaGet.NumeroDaConta));

#line default
#line hidden
            EndContext();
            BeginContext(4411, 79, true);
            WriteLiteral("\r\n                    </dd>\r\n                    <dt>\r\n                        ");
            EndContext();
            BeginContext(4491, 58, false);
#line 102 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
                   Write(Html.DisplayNameFor(model => model.MovimentoBancario.Tipo));

#line default
#line hidden
            EndContext();
            BeginContext(4549, 197, true);
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"font-weight-light\">\r\n                        Transferência\r\n                    </dd>\r\n                    <dt>\r\n                        ");
            EndContext();
            BeginContext(4747, 59, false);
#line 108 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
                   Write(Html.DisplayNameFor(model => model.MovimentoBancario.Valor));

#line default
#line hidden
            EndContext();
            BeginContext(4806, 105, true);
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"font-weight-light\">\r\n                        ");
            EndContext();
            BeginContext(4912, 55, false);
#line 111 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
                   Write(Html.DisplayFor(model => model.MovimentoBancario.Valor));

#line default
#line hidden
            EndContext();
            BeginContext(4967, 68, true);
            WriteLiteral("\r\n                    </dd>\r\n                </dl>\r\n                ");
            EndContext();
            BeginContext(5035, 608, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc5126ffd0d34d7091bc3e4ec7bac64e", async() => {
                BeginContext(5094, 42, true);
                WriteLiteral("\r\n                    <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 5136, "\"", 5167, 1);
#line 115 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
WriteAttributeValue("", 5144, Model.ContaCorrente.Id, 5144, 23, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5168, 68, true);
                WriteLiteral(" name=\"ContaCorrenteId\" />\r\n                    <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 5236, "\"", 5288, 1);
#line 116 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
WriteAttributeValue("", 5244, Model.MovimentoBancario.TransferenciaGet.Id, 5244, 44, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5289, 75, true);
                WriteLiteral(" name=\"ContaCorrenteDestinoId\" />\r\n                    <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 5364, "\"", 5402, 1);
#line 117 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
WriteAttributeValue("", 5372, Model.MovimentoBancario.Valor, 5372, 30, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5403, 58, true);
                WriteLiteral(" name=\"Valor\" />\r\n                    <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 5461, "\"", 5498, 1);
#line 118 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
WriteAttributeValue("", 5469, Model.MovimentoBancario.Tipo, 5469, 29, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5499, 137, true);
                WriteLiteral(" name=\"tipo\" />\r\n                    <input type=\"submit\" value=\"Confirmar\" class=\"btn btn-primary rounded-pill m-2\" />\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5643, 40, true);
            WriteLiteral("\r\n\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 124 "C:\Users\alean\Desktop\DCLearning\DataBank\DataBank\Banco\Views\MovimentoBancario\ConfirmarMovimento.cshtml"
    }

#line default
#line hidden
            BeginContext(5690, 8, true);
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MovimentoBancarioViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591