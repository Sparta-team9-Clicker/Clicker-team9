using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Monster",menuName ="New Monster")]
public class MonsterData : ScriptableObject
{
    [Header("Info")]
    [SerializeField] private string monsterName;
    [SerializeField] private int monsterHP;
    [SerializeField] private GameObject monsterPrefab;
}
