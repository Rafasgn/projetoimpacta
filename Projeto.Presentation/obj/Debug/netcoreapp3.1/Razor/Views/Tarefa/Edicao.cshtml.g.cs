#pragma checksum "C:\Users\rafasgn\Desktop\ProjetoGrenciadorTarefas2\Projeto.Presentation\Views\Tarefa\Edicao.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "506550d51ab0a203d82936586f5b518151f0cd7a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tarefa_Edicao), @"mvc.1.0.view", @"/Views/Tarefa/Edicao.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"506550d51ab0a203d82936586f5b518151f0cd7a", @"/Views/Tarefa/Edicao.cshtml")]
    public class Views_Tarefa_Edicao : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Projeto.Presentation.Models.TarefaEdicaoModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\rafasgn\Desktop\ProjetoGrenciadorTarefas2\Projeto.Presentation\Views\Tarefa\Edicao.cshtml"
  
    Layout = "~/Views/Shared/Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h5>Atualização de Tarefa</h5>\r\nPreencha os campos para atualizar a tarefa.\r\n<hr />\r\n\r\n");
#nullable restore
#line 11 "C:\Users\rafasgn\Desktop\ProjetoGrenciadorTarefas2\Projeto.Presentation\Views\Tarefa\Edicao.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\rafasgn\Desktop\ProjetoGrenciadorTarefas2\Projeto.Presentation\Views\Tarefa\Edicao.cshtml"
Write(Html.HiddenFor(model => model.IdTarefa));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-6\">\r\n            <label>Título da Tarefa:</label>\r\n            ");
#nullable restore
#line 18 "C:\Users\rafasgn\Desktop\ProjetoGrenciadorTarefas2\Projeto.Presentation\Views\Tarefa\Edicao.cshtml"
       Write(Html.TextBoxFor(model => model.Titulo,
            new
            {
            @class = "form-control",
            @placeholder = "Digite aqui"
            }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <span class=\"text-danger\">\r\n                ");
#nullable restore
#line 25 "C:\Users\rafasgn\Desktop\ProjetoGrenciadorTarefas2\Projeto.Presentation\Views\Tarefa\Edicao.cshtml"
           Write(Html.ValidationMessageFor(model => model.Titulo));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </span>
            <br />

            <input type=""submit"" value=""Atualizar Tarefa""
                   class=""btn btn-success btn-sm"" />

            <a href=""/tarefa/consulta"" class=""btn btn-secondary btn-sm"">Voltar</a>
        </div>

    </div>
");
#nullable restore
#line 36 "C:\Users\rafasgn\Desktop\ProjetoGrenciadorTarefas2\Projeto.Presentation\Views\Tarefa\Edicao.cshtml"



}

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Projeto.Presentation.Models.TarefaEdicaoModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
