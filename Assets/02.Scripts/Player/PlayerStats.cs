using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // ���� ������
    [SerializeField] private int attackPower = 10;    // �ʱ� ���ݷ�
    [SerializeField] private float autoAttackPower = 5f;    // �ʱ� �ڵ� ���ݷ�
    [SerializeField] private int playerLevel = 1;     // ����
    [SerializeField] private float attackCooldown = 1.0f;  // ���� ��Ÿ�� (��)
    [SerializeField] private float autoAttackInterval = 2.0f;  // �ڵ� ���� ���� (��)

    private float lastAttackTime = 0f;  // ������ ���� �ð�
    private Coroutine autoAttackCoroutine;

    // ���ݷ� ���� ��ȯ�ϴ� �Լ�
    public int GetAttackPower()
    {
        return attackPower;
    }

    // �ڵ� ���ݷ� ���� ��ȯ�ϴ� �Լ�
    public float GetAutoAttackPower()
    {
        return autoAttackPower;
    }

    // �ڵ� ���� ���� ���� ��ȯ�ϴ� �Լ�
    public float GetAutoAttackInterval()
    {
        return autoAttackInterval;
    }

    // ���ݷ� ���� �Լ�
    public void IncreaseAttackPower(int amount)
    {
        attackPower += amount;
    }

    // �ڵ� ���ݷ� ���� �Լ�
    public void IncreaseAutoAttackPower(float amount)
    {
        autoAttackPower += amount;
    }

    // �ڵ� ���� ���� ���� �Լ�
    public void DecreaseAutoAttackInterval(float amount)
    {
        autoAttackInterval = Mathf.Max(0.1f, autoAttackInterval - amount);  // �ּ� 0.1�ʷ� ����
    }

    // ���� �Լ�
    public void Attack(TestEnemy target)
    {
        target.TakeDamage(attackPower);
    }

    // �ڵ� ���� ����
    public void StartAutoAttack(TestEnemy target)
    {
        if (autoAttackCoroutine == null)
        {
            autoAttackCoroutine = StartCoroutine(AutoAttack(target));
        }
    }

    // �ڵ� ���� �ڷ�ƾ
    private IEnumerator AutoAttack(TestEnemy target)
    {
        while (true)
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                Attack(target);  // �ڵ� ����
                lastAttackTime = Time.time;
            }
            yield return new WaitForSeconds(autoAttackInterval);  // ���� �ð� �� �ٽ� ����
        }
    }

    // �ڵ� ���� ���߱�
    public void StopAutoAttack()
    {
        if (autoAttackCoroutine != null)
        {
            StopCoroutine(autoAttackCoroutine);
            autoAttackCoroutine = null;
        }
    }

    // ���� ���� �� �ʱ�ȭ
    void Start()
    {
        attackPower = 10;
        autoAttackPower = 5f;
        playerLevel = 1;
        attackCooldown = 1.0f;
        autoAttackInterval = 2.0f;
    }
}




