public class PowerStat : StatBase
{
    public int equipPower = 10;

    public PowerStat(PlayerData data, PlayerStat stat) : base(data, stat) { }

    public override void Upgrade()
    {
        int totalCost = playerStat.TotalCost(playerData.attackUpgrade);

        if (playerData.gold >= totalCost)
        {
            playerData.gold -= totalCost;
            playerData.attackUpgrade++;
            playerData.attackPower += 10;
        }
    }
}
