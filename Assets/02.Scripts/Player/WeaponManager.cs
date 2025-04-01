using System.Collections;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Weapon weapon;  // 무기 데이터

    public GameObject panel; // 돈 부족 판넬
    public GameObject equippanel;
    public GameObject btns;
    
    private void Start()
    {
        //DisplayWeaponStats();
        equippanel.gameObject.SetActive(false);
        btns.gameObject.SetActive(true);
    }

    public void UpgradeWeapon()
    {
        if (weapon == null || weapon.weaponStats == null)
        {
            Debug.LogWarning("무기나 무기 스탯 정보가 없습니다.");
            return;
        }

        // 강화 가능 여부 확인
        //if (GameManager.Instance.playerData.weaponUpgrade >= weapon.weaponStats.maxUpgradeLevel)
        //{
        //    Debug.Log("최대 강화 레벨에 도달했습니다.");
        //    return;
        //}        

        GameManager.Instance.playerData.weaponUpgrade++;
        //weapon.currentUpgradeLevel++;
        Debug.Log($"무기 강화 성공! 현재 레벨: {GameManager.Instance.playerData.weaponUpgrade}");
        DisplayWeaponStats();
    }

    public void DisplayWeaponStats()
    {
        if (weapon == null || weapon.weaponStats == null)
        {
            Debug.LogWarning("무기 정보가 없습니다.");
            return;
        }               
               
        //int attackPower = weapon.GetAttackPower();
        //float critChance = weapon.GetCritChance();

        //Debug.Log($"{weapon.weaponName} (Lv. {weapon.currentUpgradeLevel})\n" +
        //          $"공격력: {attackPower}, 치명타 확률: {critChance * 100:F1}%");
    }   
}



