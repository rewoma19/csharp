class Lasagna
{
    public int ExpectedMinutesInOven() {
        return 40;
    }
    public int RemainingMinutesInOven(int minutesInOven) {
        return 40 - minutesInOven;
    }
    public int PreparationTimeInMinutes(int numOfLayers) {
        return numOfLayers * 2;
    }
    public int ElapsedTimeInMinutes(int numOfLayers, int minutesInOven) {
        int prepMinutes = PreparationTimeInMinutes(numOfLayers);
        return prepMinutes + minutesInOven;
    }
}
