using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // 인스펙터에서 수정 가능하도록 SerializeField를 사용하여 직렬화
    [SerializeField] private int attackPower = 10;    // 초기 공격력
    [SerializeField] private float autoAttackPower = 5f;    // 초기 자동 공격력
    [SerializeField] private int playerLevel = 1;     // 레벨
    [SerializeField] private float attackCooldown = 1.0f;  // 공격 쿨타임 (초)
    [SerializeField] private float autoAttackInterval = 2.0f;  // 자동 공격 간격 (초)

    private float lastAttackTime = 0f;  // 마지막 공격 시간

    // 자동 공격을 위한 코루틴
    private Coroutine autoAttackCoroutine;

    // 공격력을 증가시키는 함수
    public void IncreaseAttackPower(int amount)
    {
        attackPower += amount;
        Debug.Log("Attack Power: " + attackPower);
    }

    // 자동 공격력을 증가시키는 함수
    public void IncreaseAutoAttackPower(float amount)
    {
        autoAttackPower += amount;
        Debug.Log("Auto Attack Power: " + autoAttackPower);
    }

    // 자동 공격 딜레이를 줄이는 함수
    public void DecreaseAutoAttackInterval(float amount)
    {
        autoAttackInterval = Mathf.Max(0.1f, autoAttackInterval - amount);  // 최소 딜레이 0.1초로 제한
        Debug.Log("Auto Attack Interval: " + autoAttackInterval);
    }

    // 공격 함수
    public void Attack(TestEnemy target)
    {
        target.TakeDamage(attackPower);
        Debug.Log("Attacked enemy for " + attackPower + " damage.");
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
            // 공격 쿨타임이 지난 경우에만 공격
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

    // 게임 시작 시 기본 설정
    void Start()
    {
        attackPower = 10;
        autoAttackPower = 5f;
        playerLevel = 1;
        attackCooldown = 1.0f;
        autoAttackInterval = 2.0f;
    }

    // UI나 다른 시스템과 연결하여 스탯을 조정할 수 있게 할 수 있음
    void Update()
    {
        // 예시: 게임 진행 중 플레이어 스탯을 조정하는 로직 (UI 버튼 등으로 호출)
        if (Input.GetKeyDown(KeyCode.Space))  // Space 키를 누르면 공격 (예시)
        {
            // 예시로 적을 공격하는 부분 (Enemy 스크립트는 따로 구현 필요)
            // Attack(enemy);  // 실제로 적 객체를 넘겨줘야 합니다.
        }
    }
}



