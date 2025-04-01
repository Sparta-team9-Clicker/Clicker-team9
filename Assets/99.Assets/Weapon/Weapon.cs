using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapon Data", order = 1)]
public class Weapon : ScriptableObject
{
    public string weaponName;  // 무기 이름
    public int attackPower;    // 기본 공격력
    public float critChance;   // 크리티컬 확률
    public Sprite weaponIcon;  // 무기 아이콘
    public int currentUpgradeLevel;  // 현재 강화 단계
    public WeaponStats weaponStats;  // 능력치 테이블 참조

    // 강화된 공격력 계산
    public int GetAttackPower()
    {
        if (weaponStats != null)
        {
            return weaponStats.GetAttackPowerAtLevel(currentUpgradeLevel);
        }
        else
        {
            return attackPower;  // 기본 공격력 반환
        }
    }


    // 크리티컬 확률 계산 (예시로 강화 단계에 따라 증가하도록 설정)
    public float GetCritChance()
    {
        return critChance + (currentUpgradeLevel * 0.05f); // 예시로 각 강화 단계마다 5%씩 증가
    }
}


