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

