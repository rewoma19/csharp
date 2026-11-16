static class GameMaster
{
    public static string Describe(Character character)
    {
        return $"You're a level {character.Level} {character.Class} with {character.HitPoints} hit points.";
    }

    public static string Describe(Destination destination)
    {
        return $"You've arrived at {destination.Name}, which has {destination.Inhabitants} inhabitants.";
    }

    public static string Describe(TravelMethod travelMethod)
    {
        return $"You're traveling to your destination {(travelMethod == TravelMethod.Walking ? "by" : "on")} {travelMethod.ToString().ToLowerInvariant()}.";
    }

    public static string Describe(Character character, Destination destination, TravelMethod travelMethod)
    {
        return $"{Describe(character)} {Describe(travelMethod)} {Describe(destination)}";
    }

    public static string Describe(Character character, Destination destination)
    {
        return Describe(character, destination, TravelMethod.Walking);
    }
}

class Character
{
    public string Class { get; set; } = string.Empty;
    public int Level { get; set; }
    public int HitPoints { get; set; }
}

class Destination
{
    public string Name { get; set; } = string.Empty;
    public int Inhabitants { get; set; }
}

enum TravelMethod
{
    Walking,
    Horseback
}
