using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapone : MonoBehaviour
{
    public WeaponeData weaponeData;  // ��ũ���ͺ� ������Ʈ�� ����

    void Start()
    {
        Debug.Log("Character Name: " + weaponeData.weaponeName);
        Debug.Log("CritChance: " + weaponeData.critChance);
        Debug.Log("Attack Power: " + weaponeData.attackPower);
    }
}

