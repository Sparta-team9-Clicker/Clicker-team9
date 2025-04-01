using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Weapon weapon;  // ���� ������

    private void Start()
    {
        DisplayWeaponStats();
    }

    public void UpgradeWeapon()
    {
        if (weapon == null || weapon.weaponStats == null)
        {
            Debug.LogWarning("���⳪ ���� ���� ������ �����ϴ�.");
            return;
        }

        // ��ȭ ���� ���� Ȯ��
        if (weapon.currentUpgradeLevel >= weapon.weaponStats.maxUpgradeLevel)
        {
            Debug.Log("�ִ� ��ȭ ������ �����߽��ϴ�.");
            return;
        }

        weapon.currentUpgradeLevel++;
        Debug.Log($"���� ��ȭ ����! ���� ����: {weapon.currentUpgradeLevel}");
        DisplayWeaponStats();
    }

    public void DisplayWeaponStats()
    {
        if (weapon == null || weapon.weaponStats == null)
        {
            Debug.LogWarning("���� ������ �����ϴ�.");
            return;
        }

        GameManager.Instance.playerData.attackPower += 10;
        GameManager.Instance.playerData.critical += 1;

        //int attackPower = weapon.GetAttackPower();
        //float critChance = weapon.GetCritChance();

        //Debug.Log($"{weapon.weaponName} (Lv. {weapon.currentUpgradeLevel})\n" +
        //          $"���ݷ�: {attackPower}, ġ��Ÿ Ȯ��: {critChance * 100:F1}%");
    }
}



