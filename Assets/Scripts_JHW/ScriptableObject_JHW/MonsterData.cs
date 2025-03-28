using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StageType
{
    Easy,
    Normal,
    Hard
}

[CreateAssetMenu(fileName ="Monster",menuName ="New Monster")]
public class MonsterData : ScriptableObject
{
    [Header("Info")]
    public string monsterName;
    public int monsterHP;
    public GameObject monsterPrefab;
    public int rewardGold;
    public StageType stageType;
}
