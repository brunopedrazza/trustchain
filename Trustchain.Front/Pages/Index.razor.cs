using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Trustchain.Front.Data;

namespace Trustchain.Front.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject] private NavigationManager Nav { get; set; }
        private List<Contract> Contracts { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            Contracts = await GetContracts();
        }

        private async Task<List<Contract>> GetContracts()
        {
            var contracts = new List<Contract>();
            for (var i = 0; i < 300; i++)
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
                contracts.Add(contract);
            }

            return contracts;
        }

        private void EditContract(string id)
        {
            Nav.NavigateTo($"editcontract/{id}");
        }
    }
}