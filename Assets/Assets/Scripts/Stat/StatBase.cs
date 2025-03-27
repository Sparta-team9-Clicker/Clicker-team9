public abstract class StatBase
{
    public PlayerData playerData;

    public StatBase(PlayerData data)
    {
        playerData = data;
    }

    public abstract void Upgrade();
}
