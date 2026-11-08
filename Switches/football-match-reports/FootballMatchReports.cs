public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        string playerPos;

        switch (shirtNum) {
            case 1:
                playerPos = "goalie";
                break;
            case 2:
                playerPos = "left back";
                break;
            case 3:
            case 4:
                playerPos = "center back";
                break;
            case 5:
                playerPos = "right back";
                break;
            case 6:
            case 7:
            case 8:
                playerPos = "midfielder";
                break;
            case 9:
                playerPos = "left wing";
                break;
            case 10:
                playerPos = "striker";
                break;
            case 11:
                playerPos = "right wing";
                break;
            default:
                playerPos = "UNKNOWN";
                break;
        }

        return playerPos;
    }

    public static string AnalyzeOffField(object report)
    {
        string description;

        switch (report) {
            case int supporters:
                description = $"There are {supporters} supporters at the match.";
                break;
            case string announcement:
                description = announcement;
                break;
            case Injury injury:
                description = $"Oh no! {injury.GetDescription()} Medics are on the field.";
                break;
            case Incident incident:
                description = incident.GetDescription();
                break;
            case Manager manager when manager.Club is null:
                description = manager.Name;
                break;
            case Manager manager:
                description = $"{manager.Name} ({manager.Club})";
                break;
            default:
                description = "";
                break;
        }

        return description;
    }
}
