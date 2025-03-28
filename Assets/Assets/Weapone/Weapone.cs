using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapone : MonoBehaviour
{
    public WeaponeData weaponeData;  // 스크립터블 오브젝트를 참조

    void Start()
    {
        Debug.Log("Character Name: " + weaponeData.weaponeName);
        Debug.Log("CritChance: " + weaponeData.critChance);
        Debug.Log("Attack Power: " + weaponeData.attackPower);
    }
}

