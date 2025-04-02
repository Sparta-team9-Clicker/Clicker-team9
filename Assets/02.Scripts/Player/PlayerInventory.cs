using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Weapon> inventory = new List<Weapon>();  // 플레이어 인벤토리
    public Weapon equippedWeapon;  // 장착된 무기

    void Start()
    {
        Weapon exampleWeapon = Resources.Load<Weapon>("Weapons/ExampleWeapon"); // 경로 확인
        if (exampleWeapon != null)
        {
            AddWeapon(exampleWeapon);
        }
        else
        {

        }
    }

    public void AddWeapon(Weapon weapon)
    {
        if (weapon == null)
        {
            return;
        }

        if (!inventory.Contains(weapon))
        {
            inventory.Add(weapon);
        }
    }

    public void EquipWeapon(Weapon weapon)
    {
        if (inventory.Contains(weapon))
        {
            equippedWeapon = weapon;
        }
    }

    public void UnequipWeapon()
    {
        if (equippedWeapon != null)
        {
            equippedWeapon = null;
        }
    }
}

