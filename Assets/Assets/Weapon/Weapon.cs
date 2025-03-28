using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapon Data", order = 1)]
public class Weapon : ScriptableObject
{
    public string weaponName;  // ���� �̸�
    public int attackPower;    // ���ݷ�
    public float critChance;  // ���� �ӵ�
    public Sprite weaponIcon;  // ���� ������
}
