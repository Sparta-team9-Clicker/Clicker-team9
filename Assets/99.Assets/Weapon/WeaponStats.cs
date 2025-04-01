using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponStats", menuName = "Weapon/WeaponStats", order = 1)]
public class WeaponStats : ScriptableObject
{
    public int baseAttackPower;    // �⺻ ���ݷ�
    public float upgradeMultiplier; // ��ȭ ���� (��: 1.1 = �� �ܰ踶�� 10% ����)
    public int maxUpgradeLevel;    // �ִ� ��ȭ �ܰ�
  

    // ��ȭ�� ���ݷ� ���
    public int GetAttackPowerAtLevel(int upgradeLevel)
    {
        if (upgradeLevel < 0) upgradeLevel = 0;  // �ּ� ��ȭ �ܰ�
        if (upgradeLevel > maxUpgradeLevel) upgradeLevel = maxUpgradeLevel;  // �ִ� ��ȭ �ܰ� ����

        return Mathf.FloorToInt(baseAttackPower * Mathf.Pow(upgradeMultiplier, upgradeLevel));
    }

        
}


