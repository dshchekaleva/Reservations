using ReservationsApp.Components;

namespace ReservationsApp.Services
{
public interface IReservationService
{
Task<List<CalendarEvent>> GetCalendarEvents(DateTime startDate, DateTime endDate, bool showMode);
Task<string> AddReservation(string userId, DateTime start);
void RemoveReservations(Guid eventIds);
void UpdateReservations(CalendarEvent events);
}
}
