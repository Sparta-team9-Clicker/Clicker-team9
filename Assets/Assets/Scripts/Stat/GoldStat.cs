public class GoldStat : StatBase
{
    public int needGold = 100;
    public GoldStat(PlayerData data) : base(data) { }

    public override void Upgrade()
    {
        if (playerData.gold >= needGold)
        {
            playerData.gold -= needGold;
            needGold += 100;
            playerData.goldBonusUpgrade++;
        }
    }

    public void Gold()
    {
        playerData.gold += playerData.goldBonusUpgrade;
    }
}
