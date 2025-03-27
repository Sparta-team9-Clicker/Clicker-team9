public class CriticalDamageStat : StatBase
{
    public CriticalDamageStat(PlayerData data) : base(data) { }

    public override void Upgrade()
    {
        if (playerData.gold >= 100)
        {
            playerData.gold -= 100;
            playerData.criticalDamageUpgrade++;
            playerData.criticalDamage += playerData.criticalDamage * (playerData.criticalDamageUpgrade / 10);
        }
    }
}
