#pragma checksum "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "10259730a8e728f27f47399a5cdddee9d94da998"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LayoutLogin), @"mvc.1.0.view", @"/Views/Shared/_LayoutLogin.cshtml")]
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
#nullable restore
#line 1 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
using Domain.App.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
using System.Threading;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10259730a8e728f27f47399a5cdddee9d94da998", @"/Views/Shared/_LayoutLogin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e10e67c25c791a112e3e48e175cc51c69f2cfb6b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__LayoutLogin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", "~/js/sb-admin-2.min.css", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", "~/js/site.css", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_LanguageSelection", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("bg-gradient-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/site.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/jquery.validate.globalize.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "10259730a8e728f27f47399a5cdddee9d94da9988440", async() => {
                WriteLiteral("\r\n\r\n    <meta charset=\"utf-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">\r\n    <meta name=\"description\"");
                BeginWriteAttribute("content", " content=\"", 435, "\"", 445, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n    <meta name=\"author\"");
                BeginWriteAttribute("content", " content=\"", 472, "\"", 482, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n    <title>Bloody</title>\r\n    \r\n    <link\r\n        href=\"https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i\"\r\n        rel=\"stylesheet\">\r\n    \r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "10259730a8e728f27f47399a5cdddee9d94da9989501", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.Href = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 23 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "10259730a8e728f27f47399a5cdddee9d94da99811539", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.Href = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 24 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "10259730a8e728f27f47399a5cdddee9d94da99814291", async() => {
                WriteLiteral(@"

<div class=""container"">

    <!-- Outer Row -->
    <div class=""row justify-content-center"">

        <div class=""col-xl-10 col-lg-12 col-md-9"">

            <div class=""card o-hidden border-0 shadow-lg my-5"">
                <div class=""card-body p-0"">
                    <!-- Nested Row within Card Body -->
                    
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "10259730a8e728f27f47399a5cdddee9d94da99814924", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    \r\n                    <div class=\"container\">\r\n");
#nullable restore
#line 44 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
                         if (_signInManager.IsSignedIn(User))
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "10259730a8e728f27f47399a5cdddee9d94da99816500", async() => {
#nullable restore
#line 46 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
                                                                                                                     Write(Resources.Views.Shared._Layout.Home);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 47 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </div>\r\n                    \r\n                    <div class=\"container m-auto\">\r\n                        <main role=\"main\" class=\"pb-3\">\r\n                            ");
#nullable restore
#line 52 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
                       Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </main>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n\r\n    </div>\r\n\r\n</div>\r\n\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "10259730a8e728f27f47399a5cdddee9d94da99820277", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
#nullable restore
#line 69 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "10259730a8e728f27f47399a5cdddee9d94da99822174", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
#nullable restore
#line 70 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 72 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
Write(await RenderSectionAsync("Scripts", required: false));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 74 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
      
	var currentCultureCode = Thread.CurrentThread.CurrentCulture.Name.Split('-')[0];

    // map .net datetime format strings to flatpickr/momentjs format
    
    // https://flatpickr.js.org/formatting/
    // d - day of month,2 digits
    // j - day of month, no leading zero
    // m - month, 2 digits
    // n - mont, no leading zero
    // y - 2 digit year, Y - 4 digit year
    
    // https://docs.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo?view=netcore-3.1
    // dd.MM.yyyy or dd/MM/yyyy
    
    var datePattern = Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern;
    datePattern = datePattern
        .Replace("dd", "d")
        .Replace("MM", "m")
        .Replace("yyyy", "Y");

    // LongTimePattern and ShortTimePattern HH:mm for 23:59,  h:mm tt for 11:59 PM
    var timePattern = Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortTimePattern;
    var clock24H = timePattern.Contains("tt") == false;
    timePattern = timePattern
        .Replace("HH", "H")
        .Replace("mm", "i")
        .Replace("ss", "S")
        .Replace("tt", "K");
    var dateTimePattern = timePattern + " " + datePattern;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    // https://github.com/globalizejs/globalize#installation
    $.when(
        $.get(""/js/cldr-core/supplemental/likelySubtags.json"", null, null, ""json""),
        $.get(""/js/cldr-core/supplemental/numberingSystems.json"", null, null, ""json""),
        $.get(""/js/cldr-core/supplemental/timeData.json"", null, null, ""json""),
        $.get(""/js/cldr-core/supplemental/weekData.json"", null, null, ""json""),
        
        $.get(""/js/cldr-numbers-modern/main/");
#nullable restore
#line 114 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
                                       Write(currentCultureCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("/numbers.json\", null, null, \"json\"),\r\n        $.get(\"/js/cldr-numbers-modern/main/");
#nullable restore
#line 115 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
                                       Write(currentCultureCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("/currencies.json\", null, null, \"json\"),\r\n        \r\n        $.get(\"/js/cldr-dates-modern/main/");
#nullable restore
#line 117 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
                                     Write(currentCultureCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("/ca-generic.json\", null, null, \"json\"),\r\n        $.get(\"/js/cldr-dates-modern/main/");
#nullable restore
#line 118 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
                                     Write(currentCultureCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("/ca-gregorian.json\", null, null, \"json\"),\r\n        $.get(\"/js/cldr-dates-modern/main/");
#nullable restore
#line 119 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
                                     Write(currentCultureCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("/dateFields.json\", null, null, \"json\"),\r\n        $.get(\"/js/cldr-dates-modern/main/");
#nullable restore
#line 120 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
                                     Write(currentCultureCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"/timeZoneNames.json"", null, null, ""json"")
    ).then(function () {
        return [].slice.apply(arguments, [0]).map(function (result) {
            Globalize.load(result[0]);
        });
    }).then(function () {
        // Initialise Globalize to the current culture
        Globalize.locale('");
#nullable restore
#line 127 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
                     Write(currentCultureCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n    });\r\n    \r\n    $(function () {\r\n        $(\'[type=\"datetime-local\"]\').each(function (index, value) {\r\n            $(value).attr(\'type\', \'text\');\r\n            $(value).val(value.defaultValue);\r\n\t\t    $(value).flatpickr({\r\n\t\t        locale: \"");
#nullable restore
#line 135 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
                    Write(currentCultureCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n\t\t        enableTime: true,\r\n\t    \t    altFormat: \"");
#nullable restore
#line 137 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
                       Write(dateTimePattern);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
	    	    altInput: true,
	    	    // dateFormat: ""Z"", // iso format (causes -3h during summer)
	    	    // use direct conversion, let backend deal with utc/whatever conversions
	    	    dateFormat: ""Y-m-d H:i:s"",
	    	    disableMobile: true,
	    	    time_24hr: ");
#nullable restore
#line 143 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
                       Write(clock24H.ToString().ToLower());

#line default
#line hidden
#nullable disable
            WriteLiteral(",\r\n\t\t    });\r\n        });\r\n\r\n        $(\'[type=\"time\"]\').each(function (index, value) {\r\n            $(value).attr(\'type\', \'text\');\r\n            $(value).val(value.defaultValue);\r\n\t\t    $(value).flatpickr({\r\n\t    \t    locale: \"");
#nullable restore
#line 151 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
                    Write(currentCultureCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n\t    \t    enableTime: true,\r\n\t    \t    noCalendar: true,\r\n\r\n\t    \t    altFormat: \"");
#nullable restore
#line 155 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
                       Write(timePattern);

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n\t    \t    altInput: true,\r\n\t    \t    dateFormat: \"H:i\", // 24h HH:mm\r\n\t    \t    disableMobile: true,\r\n\r\n\t    \t    time_24hr: ");
#nullable restore
#line 160 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
                       Write(clock24H.ToString().ToLower());

#line default
#line hidden
#nullable disable
            WriteLiteral(",\r\n\t\t    });\r\n        });\r\n\r\n        $(\'[type=\"date\"]\').each(function (index, value) {\r\n\t\t    $(value).attr(\'type\', \'text\');\r\n\t\t    $(value).val(value.defaultValue);\r\n\t\t    $(value).flatpickr({\r\n    \t\t    locale: \"");
#nullable restore
#line 168 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
                    Write(currentCultureCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n\t    \t    altFormat: \"");
#nullable restore
#line 169 "C:\Users\ville\RiderProjects\icd0009-2020s\Homework\WebApp\Views\Shared\_LayoutLogin.cshtml"
                       Write(datePattern);

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n\t    \t    altInput: true,\r\n                disableMobile: true,\r\n\t    \t    dateFormat: \"Y-m-d\", // YYYY-MM-DD\r\n\t\t    });\r\n        });\r\n    });\r\n</script>\r\n\r\n\r\n</html>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<AppUser> _userManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<AppUser> _signInManager { get; private set; }
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
