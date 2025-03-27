public class CriticalDamageStat : StatBase
{
    public int needGold = 100;
    public CriticalDamageStat(PlayerData data) : base(data) { }

    public override void Upgrade()
    {
        if (playerData.gold >= 100)
        {
            playerData.gold -= 100;
            needGold += 100;
            playerData.criticalDamageUpgrade++;
            playerData.criticalDamage += playerData.criticalDamage * (playerData.criticalDamageUpgrade / 10);
        }
    }
}
