using Microsoft.AspNetCore.Components;
using System.Reflection.Metadata;

namespace BlazorApp1.Components.Pages
{
    public partial class Test
    {
        private string textChanged = string.Empty;
        private string companyName = string.Empty;
        private string address = string.Empty;
        private string CAP = string.Empty;
        private string city = string.Empty;
        private string originCode = string.Empty;

        [Parameter]
        public required string TextToBeChanged { get; set; }

        [Inject]
        IClipboardService ClipboardService { get; set; }

        private void ChangeText()
        {
            string[] splittedString = this.TextToBeChanged.Split(",");

            this.companyName = splittedString[0].Trim();
            this.city = splittedString[1].Trim();

            string temp = splittedString[2];

            this.CAP = temp.Substring(temp.Length - 5, 5).Trim();
            this.originCode = temp.Substring(temp.Length - 8, 2).Trim();
            this.address = temp.Substring(0, temp.Length - 8).Trim();

            this.textChanged = string.Concat(this.companyName, "\r\n", this.address, "\r\n", this.CAP, "\t", this.city, "\t", this.originCode);
        }

        private async Task SaveInClipboard() 
        {            
            await ClipboardService.CopyToClipboard(this.textChanged);            
        }
    }
}