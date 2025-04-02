public class GoldStat : StatBase
{
    public GoldStat(PlayerData data, PlayerStat stat) : base(data, stat) { }

    public override void Upgrade() // ��� ȹ�淮 ���׷��̵�
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
        if (playerData.gold <= 2000000000)
            playerData.gold += (int)(playerData.goldBonusUpgrade * 0.5f); // 1���� 0.5�� ȹ��
    }
}
