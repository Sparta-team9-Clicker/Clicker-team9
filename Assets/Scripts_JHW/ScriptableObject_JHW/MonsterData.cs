using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Monster",menuName ="New Monster")]
public class MonsterData : ScriptableObject
{
    [Header("Info")]
    public string monsterName;
    public float monsterHP;
    public GameObject monsterPrefab;
    public int rewardGold;
}
