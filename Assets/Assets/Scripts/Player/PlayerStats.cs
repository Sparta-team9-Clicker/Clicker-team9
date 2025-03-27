using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // 플레이어의 스탯 변수
    public int attackPower = 10;    // 초기 공격력
    public int playerLevel = 1;     // 레벨
    public float attackCooldown = 1.0f;  // 공격 쿨타임 (초)

    private float lastAttackTime = 0f;  // 마지막 공격 시간

    // 공격력을 증가시키는 함수
    public void IncreaseAttackPower(int amount)
    {
        attackPower += amount;
        Debug.Log("Attack Power: " + attackPower);
    }

    // 공격 함수
    public void Attack(Enemy target)
    {
        // 공격 쿨타임이 지난 경우에만 공격
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            target.TakeDamage(attackPower);
            lastAttackTime = Time.time;
            Debug.Log("Attacked enemy for " + attackPower + " damage.");
        }
    }

    // 게임 시작 시 기본 설정
    void Start()
    {
        // 예시: 게임 시작 시 공격력을 10으로 설정
        attackPower = 10;
        playerLevel = 1;
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

        if (Input.GetKeyDown(KeyCode.UpArrow))  // 위 화살표를 누르면 공격력 증가
        {
            IncreaseAttackPower(5);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))  // 오른쪽 화살표를 누르면 레벨 증가
        {
            playerLevel++;
            Debug.Log("Player Level: " + playerLevel);
        }
    }
}

