using Rubin2000.Models.Enums;
using System;

using static Rubin2000.Global.GeneralConstants;

namespace Rubin2000.Global
{
    public static class CommonMethods
    {
        public static bool IsToday(string date)
            => date == DateTime.UtcNow.Date.ToString(DateViewFormat);

        public static bool IsAppointmentApproved(string status)
            => status == AppointmentStatus.Approved.ToString();

        public static bool IsAppointmentPending(string status)
            => status == AppointmentStatus.Pending.ToString();
    }
}
