using ReservationsApp.Components;
using ReservationsApp.Data.Reservations;
using Microsoft.EntityFrameworkCore;
using ReservationsApp.Data.Application;

namespace ReservationsApp.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ReservationsContext _reservationContext;
        private readonly ApplicationDbContext _appContext;

        public ReservationService(
        ReservationsContext reservationContext,
        ApplicationDbContext appContext)
        {
            _appContext = appContext;
            _reservationContext = reservationContext;
        }

        public async Task<string> AddReservation(string userId, DateTime start)
        {
            var reservation = new Reservation
            {
                ReservationStart = start,
                UserId = userId
            };
            await _reservationContext.AddAsync(reservation);
            _reservationContext.SaveChanges();
            return reservation.Id.ToString();
        }

        public async Task<List<CalendarEvent>> GetCalendarEvents(DateTime startDate, DateTime endDate, bool showMode)
        {
            var events = await _reservationContext.Reservations.Where(x => x.ReservationStart > startDate && x.ReservationStart < endDate).ToListAsync();
            var userIds = events.Select(x => x.UserId).ToList();
            var users = await _appContext.Set<ApplicationUser>().Where(x => userIds.Contains(x.Id)).ToListAsync();

            return events.Join(users, ev => ev.UserId, user => user.Id, (ev, user) =>
            new CalendarEvent
            {
                Identifier = ev.Id.ToString(),
                Title = showMode ? "REZERVOVÁNO" : $"{user.FirstName} {user.LastName}",
                Start = ev.ReservationStart,
                End = ev.ReservationStart.AddHours(ev.ReservationLength)
            }).ToList();
        }

        public void RemoveReservations(Guid eventId)
        {
            var item = _reservationContext.Reservations.FirstOrDefault(x => x.Id == eventId);
            if (item != null)
            {
                _reservationContext.Remove(item);
                _reservationContext.SaveChanges();
            }
        }

        public void UpdateReservations(CalendarEvent modifiedEvent)
        {
            var item = _reservationContext.Reservations.FirstOrDefault(x => x.Id == Guid.Parse(modifiedEvent.Identifier));
            if (item != null)
            {
                item.ReservationStart = modifiedEvent.Start;
                _reservationContext.Update(item);
                _reservationContext.SaveChanges();
            }
        }
    }
}
