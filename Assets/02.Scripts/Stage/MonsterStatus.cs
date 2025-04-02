using UnityEditor.SceneManagement;
using UnityEngine;

public class MonsterStatus : MonoBehaviour
{
    public MonsterData monsterData;
    public MonsterStatusUI monsterStatusUI;
    private Animator animator;
    private int currentHP;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    // 몬스터 체력 초기화 및 MonsterStatusUI에 데이터 전달 
    public void SetMonsterData(MonsterData data)
    {
        monsterData = data;
        currentHP = monsterData.monsterHP; // 몬스터 초기 체력 설정

        if (monsterStatusUI == null)
        {
            monsterStatusUI = FindObjectOfType<MonsterStatusUI>(); 
        }

        if (monsterStatusUI != null)
        {
            monsterStatusUI.SetMonsterDataUI(monsterData);
        }
    }

    // 몬스터가 피해를 입는 함수
    public void TakeDamage(int damage)
    {
        animator.SetTrigger("isDamage");
        currentHP = Mathf.Max(currentHP - damage, 0); // 체력 감소

        // UI 업데이트
        if (monsterStatusUI != null)
        {
            monsterStatusUI.UpdateHP(currentHP);
        }

        // 체력 0이하면 사망
        if (currentHP <= 0)
        {
            Die();
        }
    }

    // 몬스터 사망 처리 함수
    private void Die()
    {
        StageManager.Instance.OnMonsterKilled();
        GameManager.Instance.playerData.gold += monsterData.rewardGold; // 처치보상 골드 지급
        Destroy(gameObject);// 몬스터 오브젝트 삭제 
    }
}
