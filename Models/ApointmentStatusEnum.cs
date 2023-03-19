namespace HospitalManagementAPI.Models
{
    public enum AppointmentStatusEnum
    {
        Booked,
        Attended,
        Expired,
        Cancelled
    }
    public static class AppointmentStatus
    {
        public static string GetStatus(int status)
        {
            switch (status)
            {
                case (int)AppointmentStatusEnum.Booked:
                    return "booked";
                case (int)AppointmentStatusEnum.Attended:
                    return "attended";
                case (int)AppointmentStatusEnum.Expired:
                    return "expired";
                case (int)(AppointmentStatusEnum.Cancelled):
                    return "cancelled";
                default:
                    return "";
            }
            return "";
        }
    }
}
