#pragma checksum "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a24b980fd0f664266299976ef775cb5b8d375e96"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BloodTransfusion_Details), @"mvc.1.0.view", @"/Views/BloodTransfusion/Details.cshtml")]
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
#nullable restore
#line 1 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a24b980fd0f664266299976ef775cb5b8d375e96", @"/Views/BloodTransfusion/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e10e67c25c791a112e3e48e175cc51c69f2cfb6b", @"/Views/_ViewImports.cshtml")]
    public class Views_BloodTransfusion_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApp.ViewModels.BloodTransfusion.DetailsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Persons", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "BloodDonate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 3 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
Write(Resources.Views.Shared._Layout.Details);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<div>\r\n    <h4>");
#nullable restore
#line 6 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
   Write(Resources.DTO.App.V1.Overall.BloodTransfusion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 10 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BloodTransfusions.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 13 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
       Write(Html.DisplayFor(model => model.BloodTransfusions.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 16 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BloodTransfusions.BloodGroup!.BloodGroupValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 19 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
       Write(Html.DisplayFor(model => model.BloodTransfusions.BloodGroup!.BloodGroupValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 22 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BloodTransfusions.Donor!));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a24b980fd0f664266299976ef775cb5b8d375e967162", async() => {
                WriteLiteral("\r\n                ");
#nullable restore
#line 26 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
           Write(Html.DisplayFor(model => model.BloodTransfusions.Donor!.FullName));

#line default
#line hidden
#nullable disable
                WriteLiteral(" \r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 25 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
                                                      WriteLiteral(Model.BloodTransfusions.DonorId);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 30 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BloodTransfusions.Doctor!));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 33 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
       Write(Html.DisplayFor(model => model.BloodTransfusions.Doctor!.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 36 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BloodTransfusions.Comments));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 39 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
       Write(Html.DisplayFor(model => model.BloodTransfusions.Comments));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 42 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BloodTransfusions.CreatedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 45 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
       Write(Html.DisplayFor(model => model.BloodTransfusions.CreatedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 48 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BloodTransfusions.CreateAt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 51 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
       Write(Html.DisplayFor(model => model.BloodTransfusions.CreateAt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 54 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BloodTransfusions.UpdateBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 57 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
       Write(Html.DisplayFor(model => model.BloodTransfusions.UpdateBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 60 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BloodTransfusions.UpdatedAt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 63 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
       Write(Html.DisplayFor(model => model.BloodTransfusions.UpdatedAt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n\r\n<h2>");
#nullable restore
#line 68 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
Write(Resources.DTO.App.V1.Overall.BloodToUse);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<table class=\"table\">\r\n    <thead>\r\n    <tr>\r\n        <th>\r\n            ");
#nullable restore
#line 73 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
       Write(Resources.Views.Shared._Layout.Blood);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 76 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TransferableBlood.FirstOrDefault()!.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 79 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TransferableBlood.FirstOrDefault()!.BloodDonate!.Donor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 80 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TransferableBlood.FirstOrDefault()!.BloodDonate!.Donor!.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th></th>\r\n    </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 86 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
     foreach (var item in Model.TransferableBlood)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a24b980fd0f664266299976ef775cb5b8d375e9616315", async() => {
                WriteLiteral(@"
                    <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""red"" class=""bi bi-droplet-fill"" viewBox=""0 0 16 16"">
                        <path fill-rule=""evenodd"" d=""M8 16a6 6 0 0 0 6-6c0-1.655-1.122-2.904-2.432-4.362C10.254 4.176 8.75 2.503 8 0c0 0-6 5.686-6 10a6 6 0 0 0 6 6zM6.646 4.646c-.376.377-1.272 1.489-2.093 3.13l.894.448c.78-1.559 1.616-2.58 1.907-2.87l-.708-.708z""/>
                    </svg>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 90 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
                                                                        WriteLiteral(item!.BloodDonateId);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 97 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
           Write(Html.DisplayFor(modelItem => item!.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 100 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
           Write(Html.DisplayFor(modelItem => item!.BloodDonate!.Donor!.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 103 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a24b980fd0f664266299976ef775cb5b8d375e9620185", async() => {
#nullable restore
#line 107 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\BloodTransfusion\Details.cshtml"
                     Write(Resources.Views.Shared._Layout.BacktoList);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApp.ViewModels.BloodTransfusion.DetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
