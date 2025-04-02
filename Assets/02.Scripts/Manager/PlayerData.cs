[System.Serializable]
public class PlayerData
{
    public int stage;
    public int attackPower;
    public int criticalDamage;
    public float critical;
    public int gold;
    public int goldBonusUpgrade;
    public int attackUpgrade;
    public int criticalUpgrade;
    public int criticalDamageUpgrade;
    public bool Eqiup;
    public int weaponUpgrade;

    public PlayerData(int stage, int attackPower, int criticalDamage, float critical, int gold, int goldBonusUpgrade,int attackUpgrade, int criticalUpgrade, int criticalDamageUpgrade, bool eqiup, int weaponUpgrade)
    {
        this.stage = stage;
        this.attackPower = attackPower;
        this.criticalDamage = criticalDamage;
        this.critical = critical;
        this.gold = gold;
        this.goldBonusUpgrade = goldBonusUpgrade;
        this.attackUpgrade = attackUpgrade;
        this.criticalUpgrade = criticalUpgrade;
        this.criticalDamageUpgrade = criticalDamageUpgrade;
        Eqiup = eqiup;
        this.weaponUpgrade = weaponUpgrade;
    }
}
