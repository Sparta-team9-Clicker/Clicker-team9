using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapone", menuName = "Weapone Data", order = 1)]
public class WeaponeData : ScriptableObject
{
    public string weaponeName;
    public float critChance;
    public int attackPower;
}

