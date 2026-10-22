static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        double successRate;

        if (speed == 0) {
            successRate = 0;
        } else if (speed >= 1 && speed <= 4) {
            successRate = 1.0;
        } else if (speed >= 5 && speed <= 8) {
            successRate = 0.9;
        } else if (speed == 9) {
            successRate = 0.8;
        } else {
            successRate = 0.77;
        }

        return successRate;
    }
    
    public static double ProductionRatePerHour(int speed)
    {
        double totalCarsPerHr = speed * 221;
        return totalCarsPerHr * SuccessRate(speed);
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        double prodRatePerHr = ProductionRatePerHour(speed);
        int prodRatePerHrInt = (int)(prodRatePerHr / 60);
        return prodRatePerHrInt;
    }
}
