#pragma checksum "D:\Study\иги\GameDevelopersForumMVC\GameDevelopersForum\GameDevelopersForum\Views\Chat\Chat.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d1c99acea58fcb33eca942bbf8b08f6f400dc7b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Chat_Chat), @"mvc.1.0.view", @"/Views/Chat/Chat.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Chat/Chat.cshtml", typeof(AspNetCore.Views_Chat_Chat))]
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
#line 1 "D:\Study\иги\GameDevelopersForumMVC\GameDevelopersForum\GameDevelopersForum\Views\_ViewImports.cshtml"
using GameDevelopersForum;

#line default
#line hidden
#line 2 "D:\Study\иги\GameDevelopersForumMVC\GameDevelopersForum\GameDevelopersForum\Views\_ViewImports.cshtml"
using GameDevelopersForum.Models;

#line default
#line hidden
#line 3 "D:\Study\иги\GameDevelopersForumMVC\GameDevelopersForum\GameDevelopersForum\Views\_ViewImports.cshtml"
using GameDevelopersForum.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d1c99acea58fcb33eca942bbf8b08f6f400dc7b", @"/Views/Chat/Chat.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9648b62bf951461dc091d5f888431469a7ab23a7", @"/Views/_ViewImports.cshtml")]
    public class Views_Chat_Chat : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Message>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(22, 55, true);
            WriteLiteral("<div style=\"width: 50%; margin: auto auto auto auto\">\r\n");
            EndContext();
#line 4 "D:\Study\иги\GameDevelopersForumMVC\GameDevelopersForum\GameDevelopersForum\Views\Chat\Chat.cshtml"
      await Html.RenderPartialAsync("chatReceive", Model);

#line default
#line hidden
            BeginContext(195, 19, true);
            WriteLiteral("    <div>\r\n        ");
            EndContext();
            BeginContext(215, 35, false);
#line 6 "D:\Study\иги\GameDevelopersForumMVC\GameDevelopersForum\GameDevelopersForum\Views\Chat\Chat.cshtml"
   Write(await Html.PartialAsync("chatSend"));

#line default
#line hidden
            EndContext();
            BeginContext(250, 20, true);
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Message>> Html { get; private set; }
    }
}
#pragma warning restore 1591