using System.Collections;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Weapon weapon;  // ���� ������

    public GameObject panel; // �� ���� �ǳ�
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
            return;
        }

        // ��ȭ ���� ���� Ȯ��
        //if (GameManager.Instance.playerData.weaponUpgrade >= weapon.weaponStats.maxUpgradeLevel)
        //{
        //    Debug.Log("�ִ� ��ȭ ������ �����߽��ϴ�.");
        //    return;
        //}        

        GameManager.Instance.playerData.weaponUpgrade++;
        //weapon.currentUpgradeLevel++;
        DisplayWeaponStats();
    }

    public void DisplayWeaponStats()
    {
        if (weapon == null || weapon.weaponStats == null)
        {
            return;
        }               
               
        //int attackPower = weapon.GetAttackPower();
        //float critChance = weapon.GetCritChance();

        //Debug.Log($"{weapon.weaponName} (Lv. {weapon.currentUpgradeLevel})\n" +
        //          $"���ݷ�: {attackPower}, ġ��Ÿ Ȯ��: {critChance * 100:F1}%");
    }   
}



