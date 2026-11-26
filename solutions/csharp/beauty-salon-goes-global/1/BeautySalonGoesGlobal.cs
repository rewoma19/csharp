using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime();
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        DateTime appointment = DateTime.Parse(appointmentDateDescription, CultureInfo.InvariantCulture);

        bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        string timeZoneId = location switch
        {
            Location.NewYork => isWindows ? "Eastern Standard Time" : "America/New_York",
            Location.London => isWindows ? "GMT Standard Time" : "Europe/London",
            Location.Paris => isWindows ? "W. Europe Standard Time" : "Europe/Paris",
            _ => throw new ArgumentOutOfRangeException(nameof(location))
        };

        TimeZoneInfo salonTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

        return TimeZoneInfo.ConvertTimeToUtc(appointment, salonTimeZone);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        return alertLevel switch
        {
            AlertLevel.Early => appointment.AddDays(-1),
            AlertLevel.Standard => appointment.AddMinutes(-105),
            AlertLevel.Late => appointment.AddMinutes(-30),
            _ => throw new ArgumentOutOfRangeException(nameof(alertLevel))
        };
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        string timeZoneId = location switch
        {
            Location.NewYork => isWindows ? "Eastern Standard Time" : "America/New_York",
            Location.London => isWindows ? "GMT Standard Time" : "Europe/London",
            Location.Paris => isWindows ? "W. Europe Standard Time" : "Europe/Paris",
            _ => throw new ArgumentOutOfRangeException(nameof(location))
        };

        TimeZoneInfo salonTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

        bool isDayLightSaving = salonTimeZone.IsDaylightSavingTime(dt);
        bool wasDayLightSaving = salonTimeZone.IsDaylightSavingTime(dt.AddDays(-7));
        return isDayLightSaving != wasDayLightSaving;
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        string cultureName = location switch
        {
            Location.NewYork => "en-US",
            Location.London => "en-GB",
            Location.Paris => "fr-FR",
            _ => throw new ArgumentOutOfRangeException(nameof(location))
        };

        CultureInfo culture = CultureInfo.GetCultureInfo(cultureName);

        bool isValid = DateTime.TryParse(dtStr, culture, DateTimeStyles.None, out DateTime parsedDate);

        return isValid ? parsedDate : DateTime.MinValue;
    }
}
