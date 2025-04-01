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

    // UI 업데이트를 위해 MonsterStatusUI에 데이터를 전달
    public void SetMonsterData(MonsterData data)
    {
        monsterData = data;
        currentHP = monsterData.monsterHP;

        if (monsterStatusUI == null)
        {
            monsterStatusUI = FindObjectOfType<MonsterStatusUI>(); 
        }

        if (monsterStatusUI != null)
        {
            monsterStatusUI.SetMonsterData(monsterData);
        }
    }

    // 몬스터가 피해를 입는 함수
    public void TakeDamage(int damage)
    {
        animator.SetTrigger("isDamage");

        // 체력 감소 
        currentHP = Mathf.Max(currentHP - damage, 0);

        // UI 업데이트
        if (monsterStatusUI != null)
        {
            monsterStatusUI.UpdateHP(currentHP);
        }

        // 체력이 0 이하이면 사망 처리
        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        StageManager.Instance.OnMonsterKilled();

        // 처치보상 골드 지급
        GameManager.Instance.playerData.gold += monsterData.rewardGold;
        
        // 오브젝트 삭제
        Destroy(gameObject);
    }
}
