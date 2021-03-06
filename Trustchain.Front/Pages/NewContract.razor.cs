using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Trustchain.Front.Data;
using Trustchain.Front.Services;

namespace Trustchain.Front.Pages
{
    public partial class NewContract
    {
        [Inject] private NavigationManager Nav { get; set; }
        [Inject] private AppState App { get; set; }

        private EditContext EditContext { get; set; }
        private Contract Contract { get; set; }

        private DateTime ConclusionDateInput
        {
            get => DateTime.Parse(Contract?.ConclusionDate ?? DateTime.Now.ToString(CultureInfo.InvariantCulture));
            set => Contract.ConclusionDate = value.ToString(CultureInfo.InvariantCulture);
        }

        protected override void OnInitialized()
        {
            Contract = new Contract();
            EditContext = new EditContext(Contract);
        }

        private void AddContract()
        {
            App.AddContract(Contract);
            Nav.NavigateTo("/");
        }
    }
}