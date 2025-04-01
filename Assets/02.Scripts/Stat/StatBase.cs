public abstract class StatBase
{
    public PlayerData playerData;
    public PlayerStat playerStat;

    public StatBase(PlayerData data, PlayerStat stat)
    {
        playerData = data;
        playerStat = stat;
    }

    public abstract void Upgrade();
}
