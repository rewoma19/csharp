static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        return DateTime.Parse(appointmentDateDescription);
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        DateTime todaysDate = DateTime.Now;
        return appointmentDate < todaysDate;
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        bool isAfternoon = false;
        TimeSpan timeOfTheDay = appointmentDate.TimeOfDay;
        TimeSpan afternoonStart = new TimeSpan(12, 0, 0);
        TimeSpan afternoonEnd = new TimeSpan(18, 0, 0);

        if (timeOfTheDay >= afternoonStart && timeOfTheDay < afternoonEnd) {
            isAfternoon = true;
        }

        return isAfternoon;
    }

    public static string Description(DateTime appointmentDate)
    {
        string customTime = appointmentDate.ToString("M/d/yyyy h:mm:ss tt");
        string dateDescription = $"You have an appointment on {customTime}.";
        return dateDescription;
    }

    public static DateTime AnniversaryDate()
    {
        int year = DateTime.Now.Year;
        return new DateTime(year, 9, 15, 0, 0, 0);
    }
}
