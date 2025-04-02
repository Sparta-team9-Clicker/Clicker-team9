public class CriticalDamageStat : StatBase
{
    public CriticalDamageStat(PlayerData data, PlayerStat stat) : base(data, stat) { }

    public override void Upgrade() // ũ��Ƽ�� ������ ���׷��̵�
    {
        int totalCost = playerStat.TotalCost(playerData.criticalDamageUpgrade);

        if (playerData.gold >= totalCost)
        {
            playerData.gold -= totalCost;
            playerData.criticalDamageUpgrade++;
            playerData.criticalDamage += 5;
        }
    }
}
