using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // �ν����Ϳ��� ���� �����ϵ��� SerializeField�� ����Ͽ� ����ȭ
    [SerializeField] private int attackPower = 10;    // �ʱ� ���ݷ�
    [SerializeField] private float autoAttackPower = 5f;    // �ʱ� �ڵ� ���ݷ�
    [SerializeField] private int playerLevel = 1;     // ����
    [SerializeField] private float attackCooldown = 1.0f;  // ���� ��Ÿ�� (��)
    [SerializeField] private float autoAttackInterval = 2.0f;  // �ڵ� ���� ���� (��)

    private float lastAttackTime = 0f;  // ������ ���� �ð�

    // �ڵ� ������ ���� �ڷ�ƾ
    private Coroutine autoAttackCoroutine;

    // ���ݷ��� ������Ű�� �Լ�
    public void IncreaseAttackPower(int amount)
    {
        attackPower += amount;
        Debug.Log("Attack Power: " + attackPower);
    }

    // �ڵ� ���ݷ��� ������Ű�� �Լ�
    public void IncreaseAutoAttackPower(float amount)
    {
        autoAttackPower += amount;
        Debug.Log("Auto Attack Power: " + autoAttackPower);
    }

    // �ڵ� ���� �����̸� ���̴� �Լ�
    public void DecreaseAutoAttackInterval(float amount)
    {
        autoAttackInterval = Mathf.Max(0.1f, autoAttackInterval - amount);  // �ּ� ������ 0.1�ʷ� ����
        Debug.Log("Auto Attack Interval: " + autoAttackInterval);
    }

    // ���� �Լ�
    public void Attack(TestEnemy target)
    {
        target.TakeDamage(attackPower);
        Debug.Log("Attacked enemy for " + attackPower + " damage.");
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
            // ���� ��Ÿ���� ���� ��쿡�� ����
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

    // ���� ���� �� �⺻ ����
    void Start()
    {
        attackPower = 10;
        autoAttackPower = 5f;
        playerLevel = 1;
        attackCooldown = 1.0f;
        autoAttackInterval = 2.0f;
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
    }
}



