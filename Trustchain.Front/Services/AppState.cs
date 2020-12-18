using System;
using System.Collections.Generic;
using System.Linq;
using Trustchain.Front.Data;

namespace Trustchain.Front.Services
{
    public class AppState
    {
        public event Action OnChange;
        
        public AppState()
        {
            var contract = new Contract
            {
                Id = Guid.NewGuid().ToString(),
                Owner = "João Silva",
                OwnerCompany = "Argila S.A.",
                Hired = "Marcus Bezerra",
                HiredCompany = "Cimento Company",
                Value = "390",
                ConclusionDate = "12/11/2020",
                JobApproved = false,
                JobDone = true
            };
            var contract2 = new Contract
            {
                Id = Guid.NewGuid().ToString(),
                Owner = "Lucas Macedo",
                OwnerCompany = "Apple",
                Hired = "Neymar",
                HiredCompany = "Barcelona",
                Value = "7845",
                ConclusionDate = "4/05/2020",
                JobApproved = false,
                JobDone = false
            };
            var contract3 = new Contract
            {
                Id = Guid.NewGuid().ToString(),
                Owner = "Paulo Guedes",
                OwnerCompany = "Economia do Brasil",
                Hired = "Renato Aragão",
                HiredCompany = "Microsoft Corps",
                Value = "334",
                ConclusionDate = "12/09/2019",
                JobApproved = true,
                JobDone = true
            };
            var contract4 = new Contract
            {
                Id = Guid.NewGuid().ToString(),
                Owner = "Wellington Silva",
                OwnerCompany = "Dinheiro SA",
                Hired = "Guilherme Mendes",
                HiredCompany = "Piracibada Company",
                Value = "987",
                ConclusionDate = "12/12/2020",
                JobApproved = false,
                JobDone = true
            };
            
            Contracts = new List<Contract>();
            
            Contracts.Add(contract);
            Contracts.Add(contract2);
            Contracts.Add(contract3);
            Contracts.Add(contract4);
            
        }
        
        public List<Contract> Contracts { get; private set; }

        public void AddContract(Contract contract)
        {
            Contracts.Add(contract);
            NotifyStateChanged();
        }

        public void DeleteContract(Contract contract)
        {
            Contracts.Remove(contract);
            NotifyStateChanged();
        }
        
        public void UpdateContract(Contract contract)
        {
            var contract1 = Contracts.FirstOrDefault(c => c.Id == contract.Id);
            Contracts.Remove(contract1);
            Contracts.Add(contract);
            NotifyStateChanged();
        }

        public Contract GetContractById(string id)
        {
            return Contracts.FirstOrDefault(c => c.Id == id);
        }
        
        private void NotifyStateChanged() => OnChange?.Invoke();
        
    }
}