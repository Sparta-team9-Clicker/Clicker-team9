using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Weapon weapon;  // 무기 데이터

    private void Start()
    {
        DisplayWeaponStats();
    }

    public void UpgradeWeapon()
    {
        if (weapon == null || weapon.weaponStats == null)
        {
            Debug.LogWarning("무기나 무기 스탯 정보가 없습니다.");
            return;
        }

        // 강화 가능 여부 확인
        if (weapon.currentUpgradeLevel >= weapon.weaponStats.maxUpgradeLevel)
        {
            Debug.Log("최대 강화 레벨에 도달했습니다.");
            return;
        }

        weapon.currentUpgradeLevel++;
        Debug.Log($"무기 강화 성공! 현재 레벨: {weapon.currentUpgradeLevel}");
        DisplayWeaponStats();
    }

    public void DisplayWeaponStats()
    {
        if (weapon == null || weapon.weaponStats == null)
        {
            Debug.LogWarning("무기 정보가 없습니다.");
            return;
        }

        GameManager.Instance.playerData.attackPower += 10;
        GameManager.Instance.playerData.critical += 1;

        //int attackPower = weapon.GetAttackPower();
        //float critChance = weapon.GetCritChance();

        //Debug.Log($"{weapon.weaponName} (Lv. {weapon.currentUpgradeLevel})\n" +
        //          $"공격력: {attackPower}, 치명타 확률: {critChance * 100:F1}%");
    }
}



