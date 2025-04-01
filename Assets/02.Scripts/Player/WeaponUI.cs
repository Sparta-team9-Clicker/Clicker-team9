using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public PlayerInventory playerInventory;  // 플레이어 인벤토리
    public Button equipButton;  // 무기 장착 버튼
    public Weapon weapon;  // 장착할 무기

    public GameObject weaponIcon;  // 무기 아이콘

   
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

