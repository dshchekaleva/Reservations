using ReservationsApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ReservationsApp.Components
{
    public partial class PopupAdd : ComponentBase
    {
        private ElementReference dialogElement;
        private int hour;
        private string userId = string.Empty;
        private DateTime date;
        private string validationMessage = string.Empty;

        [Inject]
        private IReservationService service { get; set; }
        [Inject]
        private IJSRuntime jsRuntime { get; set; }
        private List<int> AvailableHours { get; set; } = new List<int> { 9, 10, 11, 12, 13, 14, 15, 16, 17 };

        [Parameter]
        public EventCallback onSaveButtonClicked { get; set; }

        public async Task ShowPopupAsync(DateTime chosenDate, string id)
        {
            userId = id;
            date = chosenDate;
            hour = 0;
            validationMessage = string.Empty;
            StateHasChanged();
            await jsRuntime.InvokeVoidAsync("showPopup", dialogElement);
        }

        public async Task SaveAndClosePopupAsync()
        {
            if (hour > 0)
            {
                if (IsValid())
                {
                    await AddEvent();
                    await jsRuntime.InvokeVoidAsync("closePopup", dialogElement);
                    await jsRuntime.InvokeVoidAsync("showSucess");
                }
                else 
                {
                    validationMessage = "It's not allowed to add event in the past.";
                }
            }
            await onSaveButtonClicked.InvokeAsync();
        }

        public async Task ClosePopupAsync()
        {
            await jsRuntime.InvokeVoidAsync("closePopup", dialogElement);
        }

        private async Task AddEvent()
        {
            var time = new DateTime(date.Year, date.Month, date.Day, hour, 0, 0);
            await service.AddReservation(userId, time);
        }

        private bool IsValid()
        {
            if (date.Date == DateTime.Today)
                return hour > DateTime.Now.Hour;
            return true;
        }
    }
}
