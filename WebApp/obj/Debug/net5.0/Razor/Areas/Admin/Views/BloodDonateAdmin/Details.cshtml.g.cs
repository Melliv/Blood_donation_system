#pragma checksum "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\BloodDonateAdmin\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b2f25edc1850b7496ecf97fa46082b93baecb289"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_BloodDonateAdmin_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/BloodDonateAdmin/Details.cshtml")]
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
#line 1 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b2f25edc1850b7496ecf97fa46082b93baecb289", @"/Areas/Admin/Views/BloodDonateAdmin/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e10e67c25c791a112e3e48e175cc51c69f2cfb6b", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_BloodDonateAdmin_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApp.ViewModels.BloodDonate.DetailsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>BloodDonate</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 10 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\BloodDonateAdmin\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BloodDonate.Donor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 13 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\BloodDonateAdmin\Details.cshtml"
       Write(Html.DisplayFor(model => model.BloodDonate.Donor!.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 16 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\BloodDonateAdmin\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BloodDonate.Doctor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 19 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\BloodDonateAdmin\Details.cshtml"
       Write(Html.DisplayFor(model => model.BloodDonate.Doctor!.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 22 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\BloodDonateAdmin\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BloodDonate.BloodTest));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 25 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\BloodDonateAdmin\Details.cshtml"
       Write(Html.DisplayFor(model => model.BloodDonate.BloodTest!.OverviewData));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 28 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\BloodDonateAdmin\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BloodDonate.BloodGroup));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 31 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\BloodDonateAdmin\Details.cshtml"
       Write(Html.DisplayFor(model => model.BloodDonate.BloodGroup!.BloodGroupValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 34 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\BloodDonateAdmin\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BloodDonate.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 37 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\BloodDonateAdmin\Details.cshtml"
       Write(Html.DisplayFor(model => model.BloodDonate.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 40 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\BloodDonateAdmin\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BloodDonate.Available));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 43 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\BloodDonateAdmin\Details.cshtml"
       Write(Html.DisplayFor(model => model.BloodDonate.Available));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 46 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\BloodDonateAdmin\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BloodDonate.ExpireDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 49 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\BloodDonateAdmin\Details.cshtml"
       Write(Html.DisplayFor(model => model.BloodDonate.ExpireDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 52 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\BloodDonateAdmin\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BloodDonate.CreatedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 55 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\BloodDonateAdmin\Details.cshtml"
       Write(Html.DisplayFor(model => model.BloodDonate.CreatedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 58 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\BloodDonateAdmin\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BloodDonate.CreateAt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 61 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\BloodDonateAdmin\Details.cshtml"
       Write(Html.DisplayFor(model => model.BloodDonate.CreateAt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 64 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\BloodDonateAdmin\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BloodDonate.UpdateBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 67 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\BloodDonateAdmin\Details.cshtml"
       Write(Html.DisplayFor(model => model.BloodDonate.UpdateBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 70 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\BloodDonateAdmin\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BloodDonate.UpdatedAt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 73 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\BloodDonateAdmin\Details.cshtml"
       Write(Html.DisplayFor(model => model.BloodDonate.UpdatedAt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b2f25edc1850b7496ecf97fa46082b93baecb28912035", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 78 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Areas\Admin\Views\BloodDonateAdmin\Details.cshtml"
                           WriteLiteral(Model.BloodDonate.Id);

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
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b2f25edc1850b7496ecf97fa46082b93baecb28914219", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApp.ViewModels.BloodDonate.DetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
