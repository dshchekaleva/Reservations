namespace ReservationsApp.Components
{
    public class CalendarOptions
    {
        public string Id { get; set; } = string.Empty;
        public string DefaultView { get; set; } = CalendarView.DayGridMonth;
        public DateTime DefaultDate { get; set; } = DateTime.Now;
        public List<CalendarEvent> CalendarEvents { get; set; } = new();
    }

    public class CalendarEvent
    {
        public string Identifier { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Url { get; set; } = string.Empty;
        public CalendarEventStatus Status { get; set; }
    }

    public class CalendarView
    {
        public static string DayGridMonth = "dayGridMonth";
    }

    public enum CalendarEventStatus
    {
        Original = 0,
        Added = 1,
        Modified = 2,
        Deleted = 3
    }
}
