using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // �÷��̾��� ���� ����
    public int attackPower = 10;    // �ʱ� ���ݷ�
    public int playerLevel = 1;     // ����
    public float attackCooldown = 1.0f;  // ���� ��Ÿ�� (��)

    private float lastAttackTime = 0f;  // ������ ���� �ð�

    // ���ݷ��� ������Ű�� �Լ�
    public void IncreaseAttackPower(int amount)
    {
        attackPower += amount;
        Debug.Log("Attack Power: " + attackPower);
    }

    // ���� �Լ�
    public void Attack(Enemy target)
    {
        // ���� ��Ÿ���� ���� ��쿡�� ����
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            target.TakeDamage(attackPower);
            lastAttackTime = Time.time;
            Debug.Log("Attacked enemy for " + attackPower + " damage.");
        }
    }

    // ���� ���� �� �⺻ ����
    void Start()
    {
        // ����: ���� ���� �� ���ݷ��� 10���� ����
        attackPower = 10;
        playerLevel = 1;
    }

    // UI�� �ٸ� �ý��۰� �����Ͽ� ������ ������ �� �ְ� �� �� ����
    void Update()
    {
        // ����: ���� ���� �� �÷��̾� ������ �����ϴ� ���� (UI ��ư ������ ȣ��)
        if (Input.GetKeyDown(KeyCode.Space))  // Space Ű�� ������ ���� (����)
        {
            // ���÷� ���� �����ϴ� �κ� (Enemy ��ũ��Ʈ�� ���� ���� �ʿ�)
            // Attack(enemy);  // ������ �� ��ü�� �Ѱ���� �մϴ�.
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))  // �� ȭ��ǥ�� ������ ���ݷ� ����
        {
            IncreaseAttackPower(5);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))  // ������ ȭ��ǥ�� ������ ���� ����
        {
            playerLevel++;
            Debug.Log("Player Level: " + playerLevel);
        }
    }
}

