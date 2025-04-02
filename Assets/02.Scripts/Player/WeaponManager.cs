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

  
        //int attackPower = weapon.GetAttackPower();
        //float critChance = weapon.GetCritChance();

        //Debug.Log($"{weapon.weaponName} (Lv. {weapon.currentUpgradeLevel})\n" +
        //          $"공격력: {attackPower}, 치명타 확률: {critChance * 100:F1}%");    
}



