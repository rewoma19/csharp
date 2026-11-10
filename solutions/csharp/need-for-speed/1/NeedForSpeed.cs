class RemoteControlCar
{
    private int battery;
    private int speed;
    private int batteryDrain;
    private int distanceDriven = 0;

    public RemoteControlCar(int speed, int batteryDrain) {
        this.speed = speed;
        this.battery = 100;
        this.batteryDrain = batteryDrain;
    }

    public bool BatteryDrained()
    {
        return this.battery < this.batteryDrain;
    }

    public int DistanceDriven()
    {
        return this.distanceDriven;
    }

    public void Drive()
    {
        if (!BatteryDrained()) {
            this.distanceDriven += this.speed;
            this.battery -= this.batteryDrain;
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{

    private int distance;

    public RaceTrack(int distance) {
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while ((car.DistanceDriven() < this.distance) && !car.BatteryDrained()) {
            car.Drive();
        }

        return car.DistanceDriven() >= this.distance;
    }
}
