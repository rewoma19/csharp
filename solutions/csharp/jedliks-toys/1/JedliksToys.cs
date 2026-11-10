class RemoteControlCar
{
    private int _distance = 0;
    private int _battery = 100;
    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {_distance} meters";
    }

    public string BatteryDisplay()
    {
        string emptyDisplayMsg = "Battery empty";
        string finalDisplayMsg = _battery != 0 ? $"Battery at {_battery}%" : emptyDisplayMsg;
        return finalDisplayMsg;
    }

    public void Drive()
    {
        if (_battery > 0) {
            _distance += 20;
            _battery -= 1;
        }
    }
}
