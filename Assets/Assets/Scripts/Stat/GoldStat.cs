public class GoldStat : StatBase
{
    public GoldStat(PlayerData data) : base(data) { }

    public override void Upgrade()
    {
        if (playerData.gold >= 100)
        {
            playerData.gold -= 100;
            playerData.goldBonusUpgrade++;
        }
    }

    public void Gold()
    {
        playerData.gold += playerData.goldBonusUpgrade;
    }
}
