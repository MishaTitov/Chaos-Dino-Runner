public class SpeedDayNightGameMode : GameMode
{
    public override void SetGameMode(DinoManager dinoManager = null)
    {
        DayNightManager.instance.dayDuration = 2f;
    }

    public override void DisableGameMode()
    {
        DayNightManager.instance.dayDuration = 30f;
    }
}
