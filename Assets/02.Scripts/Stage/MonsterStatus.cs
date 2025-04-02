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

    // ���� ü�� �ʱ�ȭ �� MonsterStatusUI�� ������ ���� 
    public void SetMonsterData(MonsterData data)
    {
        monsterData = data;
        currentHP = monsterData.monsterHP; // ���� �ʱ� ü�� ����

        if (monsterStatusUI == null)
        {
            monsterStatusUI = FindObjectOfType<MonsterStatusUI>(); 
        }

        if (monsterStatusUI != null)
        {
            monsterStatusUI.SetMonsterDataUI(monsterData);
        }
    }

    // ���Ͱ� ���ظ� �Դ� �Լ�
    public void TakeDamage(int damage)
    {
        animator.SetTrigger("isDamage");
        currentHP = Mathf.Max(currentHP - damage, 0); // ü�� ����

        // UI ������Ʈ
        if (monsterStatusUI != null)
        {
            monsterStatusUI.UpdateHP(currentHP);
        }

        // ü�� 0���ϸ� ���
        if (currentHP <= 0)
        {
            Die();
        }
    }

    // ���� ��� ó�� �Լ�
    private void Die()
    {
        StageManager.Instance.OnMonsterKilled();
        GameManager.Instance.playerData.gold += monsterData.rewardGold; // óġ���� ��� ����
        Destroy(gameObject);// ���� ������Ʈ ���� 
    }
}
