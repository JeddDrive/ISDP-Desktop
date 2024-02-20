using System;

namespace JeddoreISDPDesktop.Helper_Classes
{
    //public static helper class
    public static class DayOfWeekCalculator
    {
        //private ftn for calculating the offset (int) of days based on the current and desired day of week
        private static int CalculateOffset(DayOfWeek currentDay, DayOfWeek desiredDay)
        {
            // currentDayInt is current day of week and 0 <= c < 7
            // desiredDayInt is desired day of the week and 0 <= d < 7
            int currentDayInt = (int)currentDay;
            int desiredDayInt = (int)desiredDay;
            int offset = (7 - currentDayInt + desiredDayInt) % 7;

            //return the offset (int)
            return offset == 0 ? 7 : offset;
        }

        //public function to get the next ship date
        //need to send in a desired day of week
        public static DateTime getNextShipDate(DayOfWeek desiredDay)
        {
            //DayOfWeek testObj = DayOfWeek.Sunday;

            //get the current date and time, now is a datetime obj
            DateTime now = DateTime.Now.Date;

            //calculate the offset based on the current day of week and desired day of week
            int offset = CalculateOffset(now.DayOfWeek, desiredDay);

            //getting the next ship date
            //gets the number of days from today (based on the offset)
            DateTime nextShipDate = now.AddDays(offset);

            //return the next ship date
            return nextShipDate;
        }
    }
}
