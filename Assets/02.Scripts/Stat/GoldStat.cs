public class GoldStat : StatBase
{
    public GoldStat(PlayerData data, PlayerStat stat) : base(data, stat) { }

    public override void Upgrade()
    {
        int totalCost = playerStat.TotalCost(playerData.goldBonusUpgrade);

        if (playerData.gold >= totalCost)
        {
            playerData.gold -= totalCost;
            playerData.goldBonusUpgrade++;
        }
    }

    public void Gold()
    {
        playerData.gold += playerData.goldBonusUpgrade;
    }
}
