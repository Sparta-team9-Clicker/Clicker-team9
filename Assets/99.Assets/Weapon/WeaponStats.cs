using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponStats", menuName = "Weapon/WeaponStats", order = 1)]
public class WeaponStats : ScriptableObject
{
    public int baseAttackPower;    // 기본 공격력
    public float upgradeMultiplier; // 강화 배율 (예: 1.1 = 매 단계마다 10% 증가)
    public int maxUpgradeLevel;    // 최대 강화 단계
  

    // 강화된 공격력 계산
    public int GetAttackPowerAtLevel(int upgradeLevel)
    {
        if (upgradeLevel < 0) upgradeLevel = 0;  // 최소 강화 단계
        if (upgradeLevel > maxUpgradeLevel) upgradeLevel = maxUpgradeLevel;  // 최대 강화 단계 제한

        return Mathf.FloorToInt(baseAttackPower * Mathf.Pow(upgradeMultiplier, upgradeLevel));
    }

        
}


