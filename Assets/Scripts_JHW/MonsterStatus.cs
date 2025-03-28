using UnityEditor.SceneManagement;
using UnityEngine;

public class MonsterStatus : MonoBehaviour
{
    public MonsterData monsterData;
    private int currentHP;
    public MonsterStatusUI monsterStatusUI;

    public void SetMonsterData(MonsterData data)
    {
        monsterData = data;
        currentHP = monsterData.monsterHP;
        Debug.Log("여기 실행");

        if (monsterStatusUI == null)
        {
            monsterStatusUI = FindObjectOfType<MonsterStatusUI>(); 
        }

        if (monsterStatusUI != null)
        {
            monsterStatusUI.SetMonsterData(monsterData);
            Debug.Log("이거 실행");
        }
    }

    public void TakeDamage(int damage)
    {
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
        //GameManager.Instance.AddGold(monsterData.rewardGold);
        StageManager.Instance.OnMonsterKilled();
        Destroy(gameObject);
    }
}
