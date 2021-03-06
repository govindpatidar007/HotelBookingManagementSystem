#pragma checksum "H:\DOTNET Training\LabsASP.NET\MODELS\HBMSMVC\Views\Hotels\HotelsByCity.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f77dbbd34e09331e041527b11e2060e19191e32e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Hotels_HotelsByCity), @"mvc.1.0.view", @"/Views/Hotels/HotelsByCity.cshtml")]
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
#line 1 "H:\DOTNET Training\LabsASP.NET\MODELS\HBMSMVC\Views\_ViewImports.cshtml"
using HBMSMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "H:\DOTNET Training\LabsASP.NET\MODELS\HBMSMVC\Views\_ViewImports.cshtml"
using HBMSMVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "H:\DOTNET Training\LabsASP.NET\MODELS\HBMSMVC\Views\Hotels\HotelsByCity.cshtml"
using MODELS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f77dbbd34e09331e041527b11e2060e19191e32e", @"/Views/Hotels/HotelsByCity.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2f70f1b0e3e7ce12567dd7002ddda39be3a47a12", @"/Views/_ViewImports.cshtml")]
    public class Views_Hotels_HotelsByCity : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MODELS.Models.Hotel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "H:\DOTNET Training\LabsASP.NET\MODELS\HBMSMVC\Views\Hotels\HotelsByCity.cshtml"
  
    ViewData["Title"] = "HotelsByCity";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Search Hotels By City</h1>\r\n\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 32 "H:\DOTNET Training\LabsASP.NET\MODELS\HBMSMVC\Views\Hotels\HotelsByCity.cshtml"
 if (Model != null && Model.Count() > 0)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n");
            WriteLiteral("                <th>\r\n                    ");
#nullable restore
#line 42 "H:\DOTNET Training\LabsASP.NET\MODELS\HBMSMVC\Views\Hotels\HotelsByCity.cshtml"
               Write(Html.DisplayNameFor(model => model.City.CityName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 45 "H:\DOTNET Training\LabsASP.NET\MODELS\HBMSMVC\Views\Hotels\HotelsByCity.cshtml"
               Write(Html.DisplayNameFor(model => model.HotelName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 48 "H:\DOTNET Training\LabsASP.NET\MODELS\HBMSMVC\Views\Hotels\HotelsByCity.cshtml"
               Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 51 "H:\DOTNET Training\LabsASP.NET\MODELS\HBMSMVC\Views\Hotels\HotelsByCity.cshtml"
               Write(Html.DisplayNameFor(model => model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 54 "H:\DOTNET Training\LabsASP.NET\MODELS\HBMSMVC\Views\Hotels\HotelsByCity.cshtml"
               Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 57 "H:\DOTNET Training\LabsASP.NET\MODELS\HBMSMVC\Views\Hotels\HotelsByCity.cshtml"
               Write(Html.DisplayNameFor(model => model.AvgRatePerNight));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 63 "H:\DOTNET Training\LabsASP.NET\MODELS\HBMSMVC\Views\Hotels\HotelsByCity.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n");
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 70 "H:\DOTNET Training\LabsASP.NET\MODELS\HBMSMVC\Views\Hotels\HotelsByCity.cshtml"
                   Write(Html.DisplayFor(modelItem => item.City.CityName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 73 "H:\DOTNET Training\LabsASP.NET\MODELS\HBMSMVC\Views\Hotels\HotelsByCity.cshtml"
                   Write(Html.DisplayFor(modelItem => item.HotelName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 76 "H:\DOTNET Training\LabsASP.NET\MODELS\HBMSMVC\Views\Hotels\HotelsByCity.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 79 "H:\DOTNET Training\LabsASP.NET\MODELS\HBMSMVC\Views\Hotels\HotelsByCity.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 82 "H:\DOTNET Training\LabsASP.NET\MODELS\HBMSMVC\Views\Hotels\HotelsByCity.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 85 "H:\DOTNET Training\LabsASP.NET\MODELS\HBMSMVC\Views\Hotels\HotelsByCity.cshtml"
                   Write(Html.DisplayFor(modelItem => item.AvgRatePerNight));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 88 "H:\DOTNET Training\LabsASP.NET\MODELS\HBMSMVC\Views\Hotels\HotelsByCity.cshtml"
                   Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        ");
#nullable restore
#line 89 "H:\DOTNET Training\LabsASP.NET\MODELS\HBMSMVC\Views\Hotels\HotelsByCity.cshtml"
                   Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        ");
#nullable restore
#line 90 "H:\DOTNET Training\LabsASP.NET\MODELS\HBMSMVC\Views\Hotels\HotelsByCity.cshtml"
                   Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 93 "H:\DOTNET Training\LabsASP.NET\MODELS\HBMSMVC\Views\Hotels\HotelsByCity.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 96 "H:\DOTNET Training\LabsASP.NET\MODELS\HBMSMVC\Views\Hotels\HotelsByCity.cshtml"


}

else if (Model != null && Model.Count() == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <span> No hotels found for this City</span>\r\n");
#nullable restore
#line 103 "H:\DOTNET Training\LabsASP.NET\MODELS\HBMSMVC\Views\Hotels\HotelsByCity.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MODELS.Models.Hotel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
