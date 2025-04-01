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
            Debug.LogError("Weapon not found!");
        }
    }

    public void AddWeapon(Weapon weapon)
    {
        if (weapon == null)
        {
            Debug.LogError("Weapon is null!");
            return;
        }

        if (!inventory.Contains(weapon))
        {
            inventory.Add(weapon);
            Debug.Log(weapon.weaponName + " added to inventory.");
        }
    }

    public void EquipWeapon(Weapon weapon)
    {
        if (inventory.Contains(weapon))
        {
            equippedWeapon = weapon;
            Debug.Log(weapon.weaponName + " equipped.");
        }
    }

    public void UnequipWeapon()
    {
        if (equippedWeapon != null)
        {
            Debug.Log(equippedWeapon.weaponName + " unequipped.");
            equippedWeapon = null;
        }
    }
}

