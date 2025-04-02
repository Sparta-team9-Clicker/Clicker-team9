using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapon Data", order = 1)]
public class Weapon : ScriptableObject
{
    public string weaponName;  // 무기 이름
    public Sprite weaponIcon;  // 무기 아이콘
    

    public void Update()
    {
        
    }

    
}


