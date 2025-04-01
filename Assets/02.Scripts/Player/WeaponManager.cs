using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Weapon weapon;  // 무기 데이터
    public int currentUpgradeLevel;

    void Start()
    {
        currentUpgradeLevel = weapon.currentUpgradeLevel;
        DisplayWeaponStats();
    }

    public void UpgradeWeapon()
    {
        if (weapon.currentUpgradeLevel < weapon.weaponStats.maxUpgradeLevel)
        {
            weapon.currentUpgradeLevel++;
            DisplayWeaponStats();
        }
        else
        {
            Debug.Log("Max upgrade level reached!");
        }
    }

    void DisplayWeaponStats()
    {
        int attackPower = weapon.GetAttackPower();
        float critChance = weapon.GetCritChance();
        Debug.Log($"{weapon.weaponName} (Level {weapon.currentUpgradeLevel}): Attack Power = {attackPower}, Crit Chance = {critChance * 100}% ");
    }


}

