using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Trustchain.Front.Data;
using Trustchain.Front.Services;

namespace Trustchain.Front.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject] private NavigationManager Nav { get; set; }
        [Inject] private AppState App { get; set; }
        private List<Contract> Contracts { get; set; }
        
        protected override void OnInitialized()
        {
            App.OnChange += GetContracts;
        }

        protected override void OnParametersSet()
        {
            GetContracts();
        }

        private void GetContracts()
        {
            Contracts = App.Contracts;
        }

        private void EditContract(string id)
        {
            Nav.NavigateTo($"editcontract/{id}");
        }
    }
}