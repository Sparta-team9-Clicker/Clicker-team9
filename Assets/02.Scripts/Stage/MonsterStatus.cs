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

    // UI ������Ʈ�� ���� MonsterStatusUI�� �����͸� ����
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

    // ���Ͱ� ���ظ� �Դ� �Լ�
    public void TakeDamage(int damage)
    {
        animator.SetTrigger("isDamage");

        // ü�� ���� 
        currentHP = Mathf.Max(currentHP - damage, 0);

        // UI ������Ʈ
        if (monsterStatusUI != null)
        {
            monsterStatusUI.UpdateHP(currentHP);
        }

        // ü���� 0 �����̸� ��� ó��
        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        StageManager.Instance.OnMonsterKilled();

        // óġ���� ��� ����
        GameManager.Instance.playerData.gold += monsterData.rewardGold;
        
        // ������Ʈ ����
        Destroy(gameObject);
    }
}
