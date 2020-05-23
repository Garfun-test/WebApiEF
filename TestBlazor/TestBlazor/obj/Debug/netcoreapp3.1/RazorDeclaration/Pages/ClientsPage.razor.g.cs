#pragma checksum "C:\Users\dmytr\source\repos\WebApiEF\TestBlazor\TestBlazor\Pages\ClientsPage.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e185b42734e848186afda8151af28ac6b221176e"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace TestBlazor.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\dmytr\source\repos\WebApiEF\TestBlazor\TestBlazor\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dmytr\source\repos\WebApiEF\TestBlazor\TestBlazor\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\dmytr\source\repos\WebApiEF\TestBlazor\TestBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\dmytr\source\repos\WebApiEF\TestBlazor\TestBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\dmytr\source\repos\WebApiEF\TestBlazor\TestBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\dmytr\source\repos\WebApiEF\TestBlazor\TestBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\dmytr\source\repos\WebApiEF\TestBlazor\TestBlazor\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\dmytr\source\repos\WebApiEF\TestBlazor\TestBlazor\_Imports.razor"
using TestBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\dmytr\source\repos\WebApiEF\TestBlazor\TestBlazor\_Imports.razor"
using TestBlazor.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\dmytr\source\repos\WebApiEF\TestBlazor\TestBlazor\_Imports.razor"
using WebApiEF;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\dmytr\source\repos\WebApiEF\TestBlazor\TestBlazor\Pages\ClientsPage.razor"
using WebApiEF.DAL.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dmytr\source\repos\WebApiEF\TestBlazor\TestBlazor\Pages\ClientsPage.razor"
using TestBlazor.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Clients")]
    public partial class ClientsPage : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 75 "C:\Users\dmytr\source\repos\WebApiEF\TestBlazor\TestBlazor\Pages\ClientsPage.razor"
       
    Clients[] clients;

    int idClient;
    string name;
    string telephone;
    string contactPerson;
    string address;

    private enum MODE { None, Add, EditDelete };
    MODE mode = MODE.None;
    Clients client;


    protected override async Task OnInitializedAsync()
    {

        await load();
    }
    protected async Task load()
    {
        clients = await clientsBlazorService.GetClientsAsync();
    }

    protected async Task Insert()
    {
        Clients c = new Clients()
        {

            Name = name,
            Telephone = telephone,
            ContactPerson = contactPerson,
            Address = address
        };
        await clientsBlazorService.InsertClientAsync(c);
        ClearFields();
        await load();
        mode = MODE.None;
    }
    protected void ClearFields()
    {
        name = string.Empty;
        telephone = string.Empty;
        contactPerson = string.Empty;
        address = string.Empty;
    }
    protected void Add()
    {
        ClearFields();
        mode = MODE.Add;
    }
    protected async Task Update()
    {

        Clients c = new Clients()
        {
            IdClient = idClient,
            Name = name,
            Telephone = telephone,
            ContactPerson = contactPerson,
            Address = address
        };

        await clientsBlazorService.UpdateClientAsync(idClient.ToString(), c);
        ClearFields();
        await load();
        mode = MODE.None;
    }

    protected async Task Delete()
    {
        await clientsBlazorService.DeleteClientAsync(idClient.ToString());
        ClearFields();
        await load();
        mode = MODE.None;
    }
    protected async Task Show(string id)
    {
        client = await clientsBlazorService.GetClientByIdAsync(id);
        idClient = client.IdClient;
        name = client.Name;
        telephone = client.Telephone;
        contactPerson = client.ContactPerson;
        address = client.Address;
        mode = MODE.EditDelete;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ClientsBlazorService clientsBlazorService { get; set; }
    }
}
#pragma warning restore 1591
