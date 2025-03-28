public class PowerStat : StatBase
{
    public int needGold = 100;
    public int equipPower = 10;

    public PowerStat(PlayerData data) : base(data) { }

    public override void Upgrade()
    {
        if (playerData.gold >= needGold)
        {
            playerData.gold -= needGold;
            needGold += 100;
            playerData.attackUpgrade++;
            playerData.attackPower += 10;
        }
    }
}
