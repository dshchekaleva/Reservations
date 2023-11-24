using ReservationsApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ReservationsApp.Components
{
    public partial class PopupEdit : ComponentBase
    {
        private ElementReference dialogElement;
        private int hour;
        private DateTime date;
        private CalendarEvent Event { get; set; } = new();
        private List<int> AvailableHours { get; set; } = new List<int> { 9, 10, 11, 12, 13, 14, 15, 16, 17 };

        [Inject]
        private IReservationService service { get; set; }

        [Inject]
        private IJSRuntime jsRuntime { get; set; }

        [Parameter]
        public EventCallback onSaveButtonClicked { get; set; }
        public async Task ShowPopupAsync(CalendarEvent eventToEdit)
        {
            date = eventToEdit.Start.Date;
            hour = eventToEdit.Start.Hour;
            Event = eventToEdit;
            StateHasChanged();
            await jsRuntime.InvokeVoidAsync("showPopup", dialogElement);
        }

        public async Task SaveAndClosePopupAsync()
        {
            if (Event.Status == CalendarEventStatus.Deleted)
            {
                service.RemoveReservations(Guid.Parse(Event.Identifier));
            }
            if (Event.Status == CalendarEventStatus.Modified)
            {
                Event.Start = new DateTime(date.Year, date.Month, date.Day, hour, 0, 0);
                service.UpdateReservations(Event);
            }
            await jsRuntime.InvokeVoidAsync("closePopup", dialogElement);
            await onSaveButtonClicked.InvokeAsync();
        }

        public async Task ClosePopupAsync()
        {
            Event.Status = CalendarEventStatus.Original;
            await jsRuntime.InvokeVoidAsync("closePopup", dialogElement);
        }

        private void EditEvent()
        {
            Event.Status = CalendarEventStatus.Modified;
        }

        private void DeleteEvent()
        {
            Event.Status = CalendarEventStatus.Deleted;
        }

        private bool HideEvent()
        {
            return Event.Status == CalendarEventStatus.Deleted;
        }

        private bool HideEdit()
        {
            return Event.Status == CalendarEventStatus.Original;
        }

        private bool Hide()
        {
            return Event.Status == CalendarEventStatus.Modified;
        }

        private bool HideButtons()
        {
            return Event.Start < DateTime.Now;
        }
    }
}
