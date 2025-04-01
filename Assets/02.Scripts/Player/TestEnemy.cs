using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public int health = 100;  // 적의 체력

    // 적이 피해를 받는 함수
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemy took " + damage + " damage. Remaining health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    // 적이 사망하는 함수
    private void Die()
    {
        Debug.Log("Enemy has died.");
        Destroy(gameObject);  // 적 객체를 제거합니다.
    }
}

