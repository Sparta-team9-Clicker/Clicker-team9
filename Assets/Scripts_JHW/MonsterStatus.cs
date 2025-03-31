using UnityEditor.SceneManagement;
using UnityEngine;

public class MonsterStatus : MonoBehaviour
{
    public MonsterData monsterData;
    private int currentHP;
    public MonsterStatusUI monsterStatusUI;
    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

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

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("isDamage");
        currentHP = Mathf.Max(currentHP - damage, 0);

        if (monsterStatusUI != null)
        {
            monsterStatusUI.UpdateHP(currentHP);
        }

        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{monsterData.monsterName}이(가) 사망했습니다.");
        StageManager.Instance.OnMonsterKilled();
        GameManager.Instance.playerData.gold += monsterData.rewardGold;
        Destroy(gameObject);
    }
}
