using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // 스탯 변수들
    [SerializeField] private int attackPower = 10;    // 초기 공격력
    [SerializeField] private float autoAttackPower = 5f;    // 초기 자동 공격력
    [SerializeField] private int playerLevel = 1;     // 레벨
    [SerializeField] private float attackCooldown = 1.0f;  // 공격 쿨타임 (초)
    [SerializeField] private float autoAttackInterval = 2.0f;  // 자동 공격 간격 (초)

    private float lastAttackTime = 0f;  // 마지막 공격 시간
    private Coroutine autoAttackCoroutine;

    // 공격력 값을 반환하는 함수
    public int GetAttackPower()
    {
        return attackPower;
    }

    // 자동 공격력 값을 반환하는 함수
    public float GetAutoAttackPower()
    {
        return autoAttackPower;
    }

    // 자동 공격 간격 값을 반환하는 함수
    public float GetAutoAttackInterval()
    {
        return autoAttackInterval;
    }

    // 공격력 증가 함수
    public void IncreaseAttackPower(int amount)
    {
        attackPower += amount;
    }

    // 자동 공격력 증가 함수
    public void IncreaseAutoAttackPower(float amount)
    {
        autoAttackPower += amount;
    }

    // 자동 공격 간격 감소 함수
    public void DecreaseAutoAttackInterval(float amount)
    {
        autoAttackInterval = Mathf.Max(0.1f, autoAttackInterval - amount);  // 최소 0.1초로 제한
    }

    // 공격 함수
    public void Attack(TestEnemy target)
    {
        target.TakeDamage(attackPower);
    }

    // 자동 공격 시작
    public void StartAutoAttack(TestEnemy target)
    {
        if (autoAttackCoroutine == null)
        {
            autoAttackCoroutine = StartCoroutine(AutoAttack(target));
        }
    }

    // 자동 공격 코루틴
    private IEnumerator AutoAttack(TestEnemy target)
    {
        while (true)
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                Attack(target);  // 자동 공격
                lastAttackTime = Time.time;
            }
            yield return new WaitForSeconds(autoAttackInterval);  // 일정 시간 후 다시 공격
        }
    }

    // 자동 공격 멈추기
    public void StopAutoAttack()
    {
        if (autoAttackCoroutine != null)
        {
            StopCoroutine(autoAttackCoroutine);
            autoAttackCoroutine = null;
        }
    }

    // 게임 시작 시 초기화
    void Start()
    {
        attackPower = 10;
        autoAttackPower = 5f;
        playerLevel = 1;
        attackCooldown = 1.0f;
        autoAttackInterval = 2.0f;
    }
}




