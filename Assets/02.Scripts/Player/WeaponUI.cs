using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public PlayerInventory playerInventory;  // �÷��̾� �κ��丮
    public Button equipButton;  // ���� ���� ��ư
    public Weapon weapon;  // ������ ����

    public GameObject weaponIcon;  // ���� ������

   
    void Start()
    {
        equipButton.onClick.AddListener(OnEquipWeapon);
        
    }

    void OnEquipWeapon()
    {
        if (weapon != null)
        {
            playerInventory.EquipWeapon(weapon);
        }
        else
        {

        }
    }

    
}

