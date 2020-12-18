using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Trustchain.Front.Data;
using Trustchain.Front.Services;

namespace Trustchain.Front.Pages
{
    public partial class EditContract
    {
        [Inject] private AppState App { get; set; }
        [Inject] private NavigationManager Nav { get; set; }
        
        [Parameter] public string Id { get; set; }
        
        private Contract Contract { get; set; }
        

        protected override void OnInitialized()
        {
            Contract = GetContract();
        }

        private Contract GetContract()
        {
            var contract = App.GetContractById(Id);
            return contract;
        }
        
        private void SubmitEditContract(MouseEventArgs args)
        {
            App.UpdateContract(Contract);
            Nav.NavigateTo("/");
        }

        private void DeleteContract()
        {
            App.DeleteContract(Contract);
            Nav.NavigateTo("/");
        }
    }
}