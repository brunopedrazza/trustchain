using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Trustchain.Front.Data;

namespace Trustchain.Front.Pages
{
    public partial class EditContract
    {
        [Parameter] public string Id { get; set; }
        
        private Contract Contract { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Contract = await GetContract();
        }

        private async Task<Contract> GetContract()
        {
            var contract = new Contract
            {
                Id = Guid.NewGuid().ToString(),
                Owner = "teste",
                OwnerCompany = "owner company",
                Hired = "hired",
                HiredCompany = "hiredcompany",
                Value = "3224",
                ConclusionDate = "23/13/2020",
                JobApproved = true,
                JobDone = false
            };
            return contract;
        }
        
        private async Task SubmitEditContract(MouseEventArgs args)
        {
            Console.WriteLine(args);
            // Edit Contract
        }

        private async Task DeleteContract()
        {
            // Delete Contract
        }
    }
}