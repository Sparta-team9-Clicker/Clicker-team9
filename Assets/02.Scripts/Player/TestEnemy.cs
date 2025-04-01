using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public int health = 100;  // ���� ü��

    // ���� ���ظ� �޴� �Լ�
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemy took " + damage + " damage. Remaining health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    // ���� ����ϴ� �Լ�
    private void Die()
    {
        Debug.Log("Enemy has died.");
        Destroy(gameObject);  // �� ��ü�� �����մϴ�.
    }
}

