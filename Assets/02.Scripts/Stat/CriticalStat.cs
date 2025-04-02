public class CriticalStat : StatBase
{
    public CriticalStat(PlayerData data, PlayerStat stat) : base(data, stat) { }

    public override void Upgrade() // 크리티컬 확률 업그레이드
    {
        int totalCost = playerStat.TotalCost(playerData.criticalUpgrade);

        if (playerData.gold >= totalCost)
        {
            playerData.gold -= totalCost;            
            playerData.criticalUpgrade++;
            playerData.critical += playerData.critical * (playerData.criticalUpgrade * 0.01f);
        }

        if (playerData.critical >= 100)
            playerData.critical = 100;       
    }
}
