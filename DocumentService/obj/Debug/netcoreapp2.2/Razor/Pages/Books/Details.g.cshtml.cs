#pragma checksum "C:\Users\anima\Documents\GitHub\DocumentService\DocumentService\Pages\Books\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "501a2e0d9b5c69d36a0387d6b2b0fd172caf46d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(DocumentService.Pages.Books.Pages_Books_Details), @"mvc.1.0.razor-page", @"/Pages/Books/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Books/Details.cshtml", typeof(DocumentService.Pages.Books.Pages_Books_Details), null)]
namespace DocumentService.Pages.Books
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\anima\Documents\GitHub\DocumentService\DocumentService\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\anima\Documents\GitHub\DocumentService\DocumentService\Pages\_ViewImports.cshtml"
using DocumentService;

#line default
#line hidden
#line 3 "C:\Users\anima\Documents\GitHub\DocumentService\DocumentService\Pages\_ViewImports.cshtml"
using DocumentService.Data;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"501a2e0d9b5c69d36a0387d6b2b0fd172caf46d1", @"/Pages/Books/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"007add18d0afdffe9e0d901a7f52d380fb964197", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Books_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "../Segments/Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("float-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\anima\Documents\GitHub\DocumentService\DocumentService\Pages\Books\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(99, 179, true);
            WriteLiteral("\r\n<div class=\"row\" style=\"height:100%;\">\r\n    <div class=\"card\" style=\"border-radius:0px;height: 100%;\">\r\n        <div class=\"card-header\" style=\"font-weight:bold;\">\r\n            ");
            EndContext();
            BeginContext(279, 15, false);
#line 10 "C:\Users\anima\Documents\GitHub\DocumentService\DocumentService\Pages\Books\Details.cshtml"
       Write(Model.Book.Name);

#line default
#line hidden
            EndContext();
            BeginContext(294, 170, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"card-body\" style=\"padding:0;width:400px;height: 100%;overflow-y: scroll;\">\r\n            <div class=\" list-group list-group-flush\">\r\n");
            EndContext();
#line 14 "C:\Users\anima\Documents\GitHub\DocumentService\DocumentService\Pages\Books\Details.cshtml"
                 foreach (var item in Model.BookSegments)
                {

#line default
#line hidden
            BeginContext(542, 22, true);
            WriteLiteral("                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 564, "\"", 608, 1);
#line 16 "C:\Users\anima\Documents\GitHub\DocumentService\DocumentService\Pages\Books\Details.cshtml"
WriteAttributeValue("", 571, Html.Raw("#book_segment_" + item.Id), 571, 37, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(609, 48, true);
            WriteLiteral(" class=\"list-group-item list-group-item-action\">");
            EndContext();
            BeginContext(658, 21, false);
#line 16 "C:\Users\anima\Documents\GitHub\DocumentService\DocumentService\Pages\Books\Details.cshtml"
                                                                                                              Write(Html.Raw(item.Header));

#line default
#line hidden
            EndContext();
            BeginContext(679, 6, true);
            WriteLiteral("</a>\r\n");
            EndContext();
#line 17 "C:\Users\anima\Documents\GitHub\DocumentService\DocumentService\Pages\Books\Details.cshtml"
                }

#line default
#line hidden
            BeginContext(704, 139, true);
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n    <div style=\"width: calc(100% - 402px);height: 100%;overflow-y: scroll;padding:10px;\">\r\n");
            EndContext();
#line 22 "C:\Users\anima\Documents\GitHub\DocumentService\DocumentService\Pages\Books\Details.cshtml"
         foreach (var item in Model.BookSegments)
        {

#line default
#line hidden
            BeginContext(905, 81, true);
            WriteLiteral("            <div class=\"card\" style=\"margin-bottom: 15px;\">\r\n                <div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 986, "\"", 1027, 1);
#line 25 "C:\Users\anima\Documents\GitHub\DocumentService\DocumentService\Pages\Books\Details.cshtml"
WriteAttributeValue("", 991, Html.Raw("book_segment_" + item.Id), 991, 36, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1028, 69, true);
            WriteLiteral(" class=\"card-header\" style=\"font-weight:bold;\">\r\n                    ");
            EndContext();
            BeginContext(1098, 37, false);
#line 26 "C:\Users\anima\Documents\GitHub\DocumentService\DocumentService\Pages\Books\Details.cshtml"
               Write(Html.Raw(item.Id + " " + item.Header));

#line default
#line hidden
            EndContext();
            BeginContext(1135, 22, true);
            WriteLiteral("\r\n                    ");
            EndContext();
            BeginContext(1157, 83, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "501a2e0d9b5c69d36a0387d6b2b0fd172caf46d18547", async() => {
                BeginContext(1232, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 27 "C:\Users\anima\Documents\GitHub\DocumentService\DocumentService\Pages\Books\Details.cshtml"
                                                     WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1240, 108, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"card-body\">\r\n                    <p class=\"card-text\">");
            EndContext();
            BeginContext(1349, 22, false);
#line 30 "C:\Users\anima\Documents\GitHub\DocumentService\DocumentService\Pages\Books\Details.cshtml"
                                    Write(Html.Raw(item.Content));

#line default
#line hidden
            EndContext();
            BeginContext(1371, 50, true);
            WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 33 "C:\Users\anima\Documents\GitHub\DocumentService\DocumentService\Pages\Books\Details.cshtml"
        }

#line default
#line hidden
            BeginContext(1432, 27, true);
            WriteLiteral("        <div>\r\n            ");
            EndContext();
            BeginContext(1459, 59, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "501a2e0d9b5c69d36a0387d6b2b0fd172caf46d111800", async() => {
                BeginContext(1510, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 35 "C:\Users\anima\Documents\GitHub\DocumentService\DocumentService\Pages\Books\Details.cshtml"
                                   WriteLiteral(Model.Book.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1518, 16, true);
            WriteLiteral(" |\r\n            ");
            EndContext();
            BeginContext(1534, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "501a2e0d9b5c69d36a0387d6b2b0fd172caf46d114153", async() => {
                BeginContext(1556, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1572, 40, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DocumentService.Pages.Books.DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DocumentService.Pages.Books.DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DocumentService.Pages.Books.DetailsModel>)PageContext?.ViewData;
        public DocumentService.Pages.Books.DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
