using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StageType
{
    Easy,
    Normal,
    Hard
}

[CreateAssetMenu(fileName = "MonsterDataTable", menuName = "Data/MonsterTable")]
public class MonsterDataTable : ScriptableObject
{
    public MonsterData[] monsters;
}

[System.Serializable]
public class MonsterData
{
    public string monsterName;
    public StageType stageType;
    public int monsterHP;
    public int rewardGold;
    public GameObject monsterPrefab; 
}

