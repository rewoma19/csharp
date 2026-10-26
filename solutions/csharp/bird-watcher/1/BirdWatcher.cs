class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        int[] lastWeek = {0, 2, 5, 3, 7, 8, 4};
        return lastWeek;
    }

    public int Today()
    {
        return birdsPerDay[birdsPerDay.Length - 1];
    }

    public void IncrementTodaysCount()
    {
        birdsPerDay[birdsPerDay.Length - 1] += 1;
    }

    public bool HasDayWithoutBirds()
    {
        bool hasDayWithoutBirds = Array.IndexOf(birdsPerDay, 0) != -1;
        return hasDayWithoutBirds;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int firstDaysCt = 0;

        Span<int> days = birdsPerDay.AsSpan(0, numberOfDays);

        for (int i = 0; i < days.Length; i++) {
            firstDaysCt += birdsPerDay[i];
        }

        return firstDaysCt;
    }

    public int BusyDays()
    {
        int busyDaysCt = 0;

        foreach (int day in birdsPerDay) {
            if (day >= 5) {
                busyDaysCt += 1;
            }
        }

        return busyDaysCt;
    }
}
