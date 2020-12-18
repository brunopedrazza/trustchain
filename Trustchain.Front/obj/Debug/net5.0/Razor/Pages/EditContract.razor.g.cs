#pragma checksum "/Users/Bruno/Code/trustchain/Trustchain.Front/Pages/EditContract.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8807e77c116eaed8d032b6495c51c90222a50559"
// <auto-generated/>
#pragma warning disable 1591
namespace Trustchain.Front.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/Bruno/Code/trustchain/Trustchain.Front/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/Bruno/Code/trustchain/Trustchain.Front/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/Bruno/Code/trustchain/Trustchain.Front/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/Bruno/Code/trustchain/Trustchain.Front/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/Bruno/Code/trustchain/Trustchain.Front/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/Bruno/Code/trustchain/Trustchain.Front/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/Bruno/Code/trustchain/Trustchain.Front/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/Bruno/Code/trustchain/Trustchain.Front/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/Bruno/Code/trustchain/Trustchain.Front/_Imports.razor"
using Trustchain.Front;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/Bruno/Code/trustchain/Trustchain.Front/_Imports.razor"
using Trustchain.Front.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/editcontract/{id}")]
    public partial class EditContract : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Edit Contract</h3>\n");
            __builder.OpenElement(1, "form");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "form-group");
            __builder.AddMarkupContent(4, "<label>Id</label>\n    ");
            __builder.OpenElement(5, "input");
            __builder.AddAttribute(6, "type", "text");
            __builder.AddAttribute(7, "value", 
#nullable restore
#line 7 "/Users/Bruno/Code/trustchain/Trustchain.Front/Pages/EditContract.razor"
                               Contract.Id

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(8, "disabled");
            __builder.AddAttribute(9, "class", "form-control");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\n  ");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "form-group");
            __builder.AddMarkupContent(13, "<label>Owner Representative</label>\n    ");
            __builder.OpenElement(14, "input");
            __builder.AddAttribute(15, "type", "text");
            __builder.AddAttribute(16, "value", 
#nullable restore
#line 11 "/Users/Bruno/Code/trustchain/Trustchain.Front/Pages/EditContract.razor"
                               Contract.Owner

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(17, "disabled");
            __builder.AddAttribute(18, "class", "form-control");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\n  ");
            __builder.OpenElement(20, "div");
            __builder.AddAttribute(21, "class", "form-group");
            __builder.AddMarkupContent(22, "<label>Orner Company</label>\n    ");
            __builder.OpenElement(23, "input");
            __builder.AddAttribute(24, "type", "text");
            __builder.AddAttribute(25, "value", 
#nullable restore
#line 15 "/Users/Bruno/Code/trustchain/Trustchain.Front/Pages/EditContract.razor"
                               Contract.OwnerCompany

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(26, "disabled");
            __builder.AddAttribute(27, "class", "form-control");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\n  ");
            __builder.OpenElement(29, "div");
            __builder.AddAttribute(30, "class", "form-group");
            __builder.AddMarkupContent(31, "<label>Hired Representative</label>\n    ");
            __builder.OpenElement(32, "input");
            __builder.AddAttribute(33, "type", "text");
            __builder.AddAttribute(34, "value", 
#nullable restore
#line 19 "/Users/Bruno/Code/trustchain/Trustchain.Front/Pages/EditContract.razor"
                               Contract.Hired

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(35, "disabled");
            __builder.AddAttribute(36, "class", "form-control");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\n  ");
            __builder.OpenElement(38, "div");
            __builder.AddAttribute(39, "class", "form-group");
            __builder.AddMarkupContent(40, "<label>Hired Company</label>\n    ");
            __builder.OpenElement(41, "input");
            __builder.AddAttribute(42, "type", "text");
            __builder.AddAttribute(43, "value", 
#nullable restore
#line 23 "/Users/Bruno/Code/trustchain/Trustchain.Front/Pages/EditContract.razor"
                               Contract.HiredCompany

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(44, "disabled");
            __builder.AddAttribute(45, "class", "form-control");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(46, "\n  ");
            __builder.OpenElement(47, "div");
            __builder.AddAttribute(48, "class", "form-group");
            __builder.AddMarkupContent(49, "<label>Value</label>\n    ");
            __builder.OpenElement(50, "input");
            __builder.AddAttribute(51, "type", "text");
            __builder.AddAttribute(52, "value", 
#nullable restore
#line 27 "/Users/Bruno/Code/trustchain/Trustchain.Front/Pages/EditContract.razor"
                               Contract.Value

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(53, "disabled");
            __builder.AddAttribute(54, "class", "form-control");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(55, "\n  ");
            __builder.OpenElement(56, "div");
            __builder.AddAttribute(57, "class", "form-group");
            __builder.AddMarkupContent(58, "<label>Conclusion Date</label>\n    ");
            __builder.OpenElement(59, "input");
            __builder.AddAttribute(60, "type", "text");
            __builder.AddAttribute(61, "value", 
#nullable restore
#line 31 "/Users/Bruno/Code/trustchain/Trustchain.Front/Pages/EditContract.razor"
                               Contract.ConclusionDate

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(62, "disabled");
            __builder.AddAttribute(63, "class", "form-control");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(64, "\n  ");
            __builder.OpenElement(65, "div");
            __builder.AddAttribute(66, "class", "form-group");
            __builder.AddMarkupContent(67, "<label>Job Done</label>\n    ");
            __builder.OpenElement(68, "input");
            __builder.AddAttribute(69, "type", "checkbox");
            __builder.AddAttribute(70, "checked", 
#nullable restore
#line 35 "/Users/Bruno/Code/trustchain/Trustchain.Front/Pages/EditContract.razor"
                                     Contract.JobDone

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(71, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 35 "/Users/Bruno/Code/trustchain/Trustchain.Front/Pages/EditContract.razor"
                                                                     Contract.JobDone

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(72, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => Contract.JobDone = __value, Contract.JobDone));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(73, "\n  ");
            __builder.OpenElement(74, "div");
            __builder.AddAttribute(75, "class", "form-group");
            __builder.AddMarkupContent(76, "<label>Job Approved</label>\n    ");
            __builder.OpenElement(77, "input");
            __builder.AddAttribute(78, "type", "checkbox");
            __builder.AddAttribute(79, "checked", 
#nullable restore
#line 39 "/Users/Bruno/Code/trustchain/Trustchain.Front/Pages/EditContract.razor"
                                     Contract.JobApproved

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(80, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 39 "/Users/Bruno/Code/trustchain/Trustchain.Front/Pages/EditContract.razor"
                                                                         Contract.JobApproved

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(81, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => Contract.JobApproved = __value, Contract.JobApproved));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(82, "\n");
            __builder.OpenElement(83, "button");
            __builder.AddAttribute(84, "class", "btn btn-primary");
            __builder.AddAttribute(85, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 42 "/Users/Bruno/Code/trustchain/Trustchain.Front/Pages/EditContract.razor"
                                          SubmitEditContract

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(86, "Edit");
            __builder.CloseElement();
            __builder.AddMarkupContent(87, "\n");
            __builder.OpenElement(88, "button");
            __builder.AddAttribute(89, "class", "btn btn-danger");
            __builder.AddAttribute(90, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 43 "/Users/Bruno/Code/trustchain/Trustchain.Front/Pages/EditContract.razor"
                                         DeleteContract

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(91, "Delete");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
