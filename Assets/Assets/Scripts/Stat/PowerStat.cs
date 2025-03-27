public class PowerStat : StatBase
{
    public int powerNeedGold = 100;
    public int equipPower = 10;

    public PowerStat(PlayerData data) : base(data) { }

    public override void Upgrade()
    {
        if (playerData.gold >= powerNeedGold)
        {
            playerData.gold -= powerNeedGold;
            powerNeedGold += 100;
            playerData.attackUpgrade++;

            if (playerData.Eqiup)
            {
                playerData.attackPower += equipPower;
                if (playerData.attackUpgrade >= 2)
                    playerData.attackPower += 10;
            }
            else
            {
                playerData.attackPower += 10;
            }
        }
    }
}
