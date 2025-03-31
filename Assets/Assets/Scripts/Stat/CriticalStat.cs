public class CriticalStat : StatBase
{
    public int needgold = 100;
    public CriticalStat(PlayerData data) : base(data) { }

    public override void Upgrade()
    {
        if (playerData.gold >= needgold)
        {
            playerData.gold -= needgold;
            needgold += 100;
            playerData.criticalUpgrade++;
            playerData.critical += playerData.critical * (playerData.criticalUpgrade * 0.01f);
        }

        if (playerData.critical >= 100)
            playerData.critical = 100;       
    }
}
