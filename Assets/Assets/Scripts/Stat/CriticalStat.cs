public class CriticalStat : StatBase
{
    public CriticalStat(PlayerData data) : base(data) { }

    public override void Upgrade()
    {
        if (playerData.gold >= 100)
        {
            playerData.gold -= 100;
            playerData.criticalUpgrade++;
            playerData.critical += playerData.critical * (playerData.criticalUpgrade / 10);
        }
    }
}
