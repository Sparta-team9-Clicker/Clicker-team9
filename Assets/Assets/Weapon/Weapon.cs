using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapon Data", order = 1)]
public class Weapon : ScriptableObject
{
    public string weaponName;  // ���� �̸�
    public int attackPower;    // �⺻ ���ݷ�
    public float critChance;   // ũ��Ƽ�� Ȯ��
    public Sprite weaponIcon;  // ���� ������
    public int currentUpgradeLevel;  // ���� ��ȭ �ܰ�
    public WeaponStats weaponStats;  // �ɷ�ġ ���̺� ����

    // ��ȭ�� ���ݷ� ���
    public int GetAttackPower()
    {
        if (weaponStats != null)
        {
            return weaponStats.GetAttackPowerAtLevel(currentUpgradeLevel);
        }
        else
        {
            return attackPower;  // �⺻ ���ݷ� ��ȯ
        }
    }

    // ��ȭ�� ġ��Ÿ ���� ��� ���
    public float GetCritMultiplier()
    {
        if (weaponStats != null)
        {
            return weaponStats.GetCritMultiplierAtLevel(currentUpgradeLevel);
        }
        else
        {
            return 2.0f;  // �⺻ ġ��Ÿ ���� ��� (2��)
        }
    }

    // ũ��Ƽ�� Ȯ�� ��� (���÷� ��ȭ �ܰ迡 ���� �����ϵ��� ����)
    public float GetCritChance()
    {
        return critChance + (currentUpgradeLevel * 0.05f); // ���÷� �� ��ȭ �ܰ踶�� 5%�� ����
    }
}


