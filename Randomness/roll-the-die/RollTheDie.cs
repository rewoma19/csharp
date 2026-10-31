public class Player
{
    private readonly Random random = new Random();

    public int RollDie()
    {
        return random.Next(1, 19);
    }

    public double GenerateSpellStrength()
    {
        double min = 0.0;
        double max = 100.0;
        return random.NextDouble() * (max - min) + min;
    }
}
