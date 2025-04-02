public class PowerStat : StatBase
{
    public int equipPower = 10;

    public PowerStat(PlayerData data, PlayerStat stat) : base(data, stat) { }

    public override void Upgrade() // 파워 업그레이드
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
