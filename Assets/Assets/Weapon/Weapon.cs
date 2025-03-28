using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapon Data", order = 1)]
public class Weapon : ScriptableObject
{
    public string weaponName;  // 무기 이름
    public int attackPower;    // 공격력
    public float critChance;  // 공격 속도
    public Sprite weaponIcon;  // 무기 아이콘
}
