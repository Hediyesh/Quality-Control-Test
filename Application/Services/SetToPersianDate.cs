using System.Globalization;

namespace ControlService.ControlApplication.Services
{
    public class SetToPersianDate
    {
        public static string ToShamsiDate(DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();
            return $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00}";
        }

    }
}
