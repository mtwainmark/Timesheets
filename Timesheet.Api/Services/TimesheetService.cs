using System.Collections.Generic;
using Timesheet.Api.Models;

namespace Timesheet.Api.Services
{
    public class TimesheetService
    {
        public bool TrackTime(TimeLog timeLog)
        {
            Timesheets.TimeLogs.Add(timeLog);

            return true;
        }
    }

    public static class Timesheets
    {
        static Timesheets()
        {
            TimeLogs = new List<TimeLog>();
        }

        public static List<TimeLog> TimeLogs { get; set; }
    }
}
