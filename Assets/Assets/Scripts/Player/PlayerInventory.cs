using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Weapon> inventory = new List<Weapon>();  // �÷��̾� �κ��丮
    public Weapon equippedWeapon;  // ������ ����

    void Start()
    {
        Weapon exampleWeapon = Resources.Load<Weapon>("Weapons/ExampleWeapon"); // ��� Ȯ��
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

