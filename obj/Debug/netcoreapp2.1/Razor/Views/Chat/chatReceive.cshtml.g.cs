#pragma checksum "D:\Study\иги\GameDevelopersForumMVC\GameDevelopersForum\GameDevelopersForum\Views\Chat\chatReceive.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ba0d07b12cc2f5b109054a26a92f0318e5a420c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Chat_chatReceive), @"mvc.1.0.view", @"/Views/Chat/chatReceive.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Chat/chatReceive.cshtml", typeof(AspNetCore.Views_Chat_chatReceive))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba0d07b12cc2f5b109054a26a92f0318e5a420c1", @"/Views/Chat/chatReceive.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9648b62bf951461dc091d5f888431469a7ab23a7", @"/Views/_ViewImports.cshtml")]
    public class Views_Chat_chatReceive : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/signalr/dist/browser/signalr.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/chat.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 332, true);
            WriteLiteral(@"<div class=""container wrap"">
    <div class=""row"">
        <div class=""col-md-7"">
            <div class=""panel panel-success"">
                <div class=""panel-heading"" id=""accordion"">

                    <div class=""panel-body"" style=""background-color:white"">
                        <ul id=""messagesList"" class=""chat"">
");
            EndContext();
#line 9 "D:\Study\иги\GameDevelopersForumMVC\GameDevelopersForum\GameDevelopersForum\Views\Chat\chatReceive.cshtml"
                              
                                int i = 0;
                                foreach (var message in Model)
                                {
                                    string sender = ViewBag.Users[i++];

#line default
#line hidden
            BeginContext(580, 40, true);
            WriteLiteral("                                    <li>");
            EndContext();
            BeginContext(621, 6, false);
#line 14 "D:\Study\иги\GameDevelopersForumMVC\GameDevelopersForum\GameDevelopersForum\Views\Chat\chatReceive.cshtml"
                                   Write(sender);

#line default
#line hidden
            EndContext();
            BeginContext(627, 2, true);
            WriteLiteral(": ");
            EndContext();
            BeginContext(630, 12, false);
#line 14 "D:\Study\иги\GameDevelopersForumMVC\GameDevelopersForum\GameDevelopersForum\Views\Chat\chatReceive.cshtml"
                                            Write(message.Text);

#line default
#line hidden
            EndContext();
            BeginContext(642, 27, true);
            WriteLiteral("<p style=\"color:green\">at: ");
            EndContext();
            BeginContext(670, 12, false);
#line 14 "D:\Study\иги\GameDevelopersForumMVC\GameDevelopersForum\GameDevelopersForum\Views\Chat\chatReceive.cshtml"
                                                                                    Write(message.Time);

#line default
#line hidden
            EndContext();
            BeginContext(682, 12, true);
            WriteLiteral(" </p></li>\r\n");
            EndContext();
#line 15 "D:\Study\иги\GameDevelopersForumMVC\GameDevelopersForum\GameDevelopersForum\Views\Chat\chatReceive.cshtml"
                                }
                            

#line default
#line hidden
            BeginContext(760, 139, true);
            WriteLiteral("                        </ul>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            EndContext();
            BeginContext(899, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c80e8c65974d48cd9b09a9ea9523c392", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(960, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(962, 36, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "39556f2fb0044a62882df15b6c2d38c7", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(998, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591